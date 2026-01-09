//using BindingModels;
using Castle.Core.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Linq;
using IposV3.Extensions;

namespace IposV3.Model
{
    public class KendoParams
    {
        public int Take { get; set; } = 0;
        public int Skip { get; set; } = 0;
        public int Page { get; set; } = 0;
        public int PageSize { get; set; } = 0;
        public List<KendoSort>? Sort { get; set; }
        public KendoFilters? Filter { get; set; }

        //public string OriginalQuery { get; set; }

        public KendoGeneralFilter? GeneralFilter { get; set; }


        public KendoParams()
        {

        }

        public KendoParams(string? generalFilterValue, string? fieldsGeneralFilter): this()
        {

            GeneralFilter = new KendoGeneralFilter("", fieldsGeneralFilter != null ? fieldsGeneralFilter.Replace(" ","") : "");
        }


        public KendoParams(string? generalFilterValue, string? fieldsGeneralFilter, KendoFilters kendoFilters):this(generalFilterValue,fieldsGeneralFilter)
        {

            Filter = kendoFilters;
        }

        public string GetSortFields(string defaultSort)
        {
            var order = defaultSort;
            var sorts = new List<string>();

            if (Sort == null || !Sort.Any())
            {
                return order;
            }


            Sort.ForEach(x => { sorts.Add($"{x.Field} {x.Dir}"); });

            order = string.Join(",", sorts.ToArray());

            return order;
        }

        public void AddGeneralFilterToFilters()
        {

            if ((GeneralFilter?.Fields?.Count ?? 0) == 0)
                GeneralFilter!.Fields =  "".Split('|').ToList(); // ProductoBindingModel.GetFieldsForGeneralSearch().Split('|').ToList();

            if (Filter == null)
                Filter = new KendoFilters(new List<KendoFilter>() { }, "and");

            if (Filter!.Filters == null)
                Filter!.Filters = new List<KendoFilter>() { };

            Filter.Filters.Add(GeneralFilter!.ToKendoFilter()!);
        }

        public void RemoveAllGeneralFilterFromFilters()
        {
            if (Filter == null || Filter.Filters == null || Filter.Filters.Count == 0)
                return;

            Filter.Filters = Filter.Filters.Where(y => !y.IsGeneralFilter).ToList();

            if (Filter.Filters.Count() == 0)
                Filter = null;
        }


    }

    public class KendoSort
    {
        public string? Field { get; set; }
        public string? Dir { get; set; }

        public KendoNET.DynamicLinq.Sort ToKendoNetEquivalent()
        {
            return new KendoNET.DynamicLinq.Sort() { Field = this.Field, Dir = this.Dir};
        }
    }

    public class  KendoGeneralFilter
    {

        public KendoGeneralFilter()
        {

        }

        public KendoGeneralFilter(string value, string? FieldsSplit)
        {
            Value = value;
            if (FieldsSplit != null)
                Fields = FieldsSplit.Split('|').ToList();
            else
                Fields = new List<string>();
        }

        public string? Value { get; set; }
        public List<string>? Fields { get; set; }

        public KendoFilter? ToKendoFilter()
        {
            if (Value == null || Value.IsNullOrEmpty())
                return null;

            bool valorExacto = false;

            if(Value.Contains(" <(("))
            {
                var bufferSplit = Value.Replace("))>", "").Split(" <((");
                if (bufferSplit.Length >= 2)
                {
                    Value = bufferSplit[1].Trim();
                }
                else
                {
                    Value = bufferSplit[0].Trim();
                }
                valorExacto = true;
            }

            var kendoFilter = new KendoFilter();
            kendoFilter.Logic = "or";
            kendoFilter.IsGeneralFilter = true;
            if(Fields != null)
            {
                kendoFilter.Filters = new List<KendoFilter>();

                foreach (var field in Fields)
                {
                    kendoFilter.Filters.Add(new KendoFilter(Value, (valorExacto ? "eq" : "contains"), field.Replace(@"""", ""), "true", true));
                }
            }

            return kendoFilter;
        }
    }

    public class KendoFilter
    {
        public KendoFilter()
        {
            IsGeneralFilter = false;
        }


        public KendoFilter(string value, string _operator, string field, string ignoreCase, bool isGeneralFilter = false)
        {
            Value = value;
            Operator = _operator;
            Field = field;
            IgnoreCase = ignoreCase;
            IsGeneralFilter = isGeneralFilter;
        }

        public KendoNET.DynamicLinq.Filter ToKendoNetEquivalent()
        {
            return new KendoNET.DynamicLinq.Filter() { Field = this.Field, Value = this.Value, Operator = this.Operator, IgnoreCase = this.IgnoreCase, Logic = this.Logic, Filters = this.Filters?.Select(y => y.ToKendoNetEquivalent()) };
        }

        public string? Value { get; set; }
        public string? Operator { get; set; }
        public string? Field { get; set; }
        public string? IgnoreCase { get; set; }

        public List<KendoFilter>? Filters { get; set; }
        public string? Logic { get; set; }

        public bool IsGeneralFilter { get; set; }

    }

    public class KendoFilters
    {
        public List<KendoFilter>? Filters { get; set; }
        public string? Logic { get; set; }

        public KendoFilters()
        {
        }

        public KendoFilters(List<KendoFilter> filters, string logic)
        {
            this.Filters = filters;
            this.Logic = logic;
        }

        public KendoNET.DynamicLinq.Filter ToKendoNetEquivalent()
        {
            
            return new KendoNET.DynamicLinq.Filter() { Logic = this.Logic, Filters = this.Filters?.Select(y => y.ToKendoNetEquivalent()) };
        }

    }

    public class KendoSearch : KendoParams
    {
        public string? Query { get; set; }
    }

   
}