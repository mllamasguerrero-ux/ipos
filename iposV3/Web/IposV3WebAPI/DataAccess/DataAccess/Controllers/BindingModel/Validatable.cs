
using Controllers.BindingModel;
using IposV3.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MvvmFramework
{
    public class Validatable : INotifyDataErrorInfo, INotifyPropertyChanged, IAcceptPendingChange
    {
        private readonly Dictionary<string, List<string?>> errors = new Dictionary<string, List<string?>>();

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged = delegate { };
        private object threadLock = new object();

        public IEnumerable GetErrors(string? propertyName)
        {
            if (propertyName == null)
                return Enumerable.Empty<string>();

            return errors.ContainsKey(propertyName) ? errors[propertyName] : Enumerable.Empty<string?>();
        }

        public bool HasErrors
        {
            get { return errors.Count > 0; }
        }



        private void ValidateProperty(string? propertyName)
        {
            if (propertyName == null)
                return;

            lock (threadLock)
            {
                var results = new List<ValidationResult>();
                ValidationContext context = new ValidationContext(this) { MemberName = propertyName };

                object? value = GetType().GetProperty(propertyName)?.GetValue(this, null);

                Validator.TryValidateProperty(value, context, results);
                CustomTryValidateProperty(value, context, results);

                if (results.Any())
                {
                    errors[propertyName] = results.Select(c => c.ErrorMessage).ToList();
                }
                else
                {
                    errors.Remove(propertyName);
                }
                //ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("HasErrors"));
                OnErrorsChanged(propertyName);
            }

        }

        public void OnErrorsChanged(string propertyName)
        {

            if(ErrorsChanged != null)
                ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
            if(PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("HasErrors"));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public event AcceptPendingChangeHandler? PendingChange;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            ValidateProperty(propertyName);
        }


        //protected virtual bool RaiseAcceptPendingChange(
        //    object newValue, object oldValue, [CallerMemberName] string? propertyName = null)
        //{
        //    var e = new AcceptPendingChangeEventArgs(propertyName ?? "", newValue, oldValue);
        //    PendingChange?.Invoke(this, e);
        //    return !e.CancelPendingChange;
        //}

        protected virtual bool RaiseAcceptPendingChange(
            object? newValue, object? oldValue, [CallerMemberName] string? propertyName = null)
        {
            var e = new AcceptPendingChangeEventArgs(propertyName ?? "", newValue ?? DBNull.Value, oldValue ?? DBNull.Value);
            PendingChange?.Invoke(this, e);
            return !e.CancelPendingChange;
        }



        public void Validate()
        {
            lock (threadLock)
            {
                var validationContext = new ValidationContext(this, null, null);
                var validationResults = new List<ValidationResult>();
                Validator.TryValidateObject(this, validationContext, validationResults, true);

                //clear all previous errors
                var propNames = errors.Keys.ToList();
                errors.Clear();
                propNames.ForEach(pn => OnErrorsChanged(pn));

                HandleValidationResults(validationResults);
            }
        }

        private void HandleValidationResults(List<ValidationResult> validationResults)
        {
            //Group validation results by property names
            var resultsByPropNames = from res in validationResults
                                     from mname in res.MemberNames
                                     group res by mname into g
                                     select g;

            //add errors to dictionary and inform  binding engine about errors
            foreach (var prop in resultsByPropNames)
            {
                var messages = prop.Select(r => r.ErrorMessage).ToList();
                errors.Add(prop.Key, messages);
                OnErrorsChanged(prop.Key);
            }
        }


        protected virtual bool CustomTryValidateProperty(object? value, ValidationContext validationContext, ICollection<ValidationResult> validationResults)
        {
            return true;
        }

        protected void AddValidationResultToCollection(string errorMessage, ICollection<ValidationResult> validationResults)
        {
            if (validationResults == null)
                validationResults = new List<ValidationResult>();

            validationResults.Add(new ValidationResult(errorMessage));
        }

        public void PutTemporalValidationError(string propertyName, string errorMessage)
        {
            errors[propertyName] = new List<string?>() { errorMessage };
        }



    }
}
