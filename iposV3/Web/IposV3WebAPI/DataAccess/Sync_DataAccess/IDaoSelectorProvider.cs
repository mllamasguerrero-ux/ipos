using IposV3.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IDaoSelectorProvider<T, P> where T : class where P : class
    {
        List<BaseSelector>? SelectForSelector(NpgsqlTransaction st, P param, KendoParams kendoParams);
        BaseSelector? SelectForSelectorItem(NpgsqlTransaction st, string claveValue, P param, KendoParams kendoParams);
        BaseSelector? SelectForSelectorItemById(NpgsqlTransaction st, long id, P param, KendoParams kendoParams);
    }
}
