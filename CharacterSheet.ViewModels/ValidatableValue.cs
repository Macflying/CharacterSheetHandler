﻿using CharacterSheet.ViewModels;
using CharacterSheetHandler.Models.CollectionExtensions;
using CharacterSheetHandler.Models.Validations;
using FunctionalCSharp.Option;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace CharacterSheetHandler.ViewModels
{
    /// <summary>
    /// Class that can notify a view of changes to a value and errors linked to that value.
    /// </summary>
    /// <typeparam name="T">Le type de l'objet pouvant être validé.</typeparam>
    public class ValidatableValue<T> : IEquatable<ValidatableValue<T>>, INotifyDataErrorInfo
    {
        private readonly ViewModelBase _viewModel = new ViewModelBase();

        /// <summary>
        /// Should validation happens at every changes to the value ?
        /// </summary>
        private bool AutoValidation { get; }

        #region Value

        private T _innerValue;

        public T Value
        {
            get
            { return _innerValue; }
            set
            {
                if (_viewModel.SetValue(ref _innerValue, value) && AutoValidation)
                    Validate();
            }
        }

        #endregion Value

        #region Errors
        private List<string> _errors = new List<string>();

        public IEnumerable<string> Errors => _errors;

        public bool HasErrors => _errors.Any();

        public string FirstError => _errors.FirstOrDefault();

        public IEnumerable GetErrors(string propertyName) => _errors;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        #endregion Errors

        public IList<IValidationRule<T, string>> ValidationRules { get; } = new List<IValidationRule<T, string>>();

        #region Factory
        private ValidatableValue(bool autoValidation) => AutoValidation = autoValidation;

        /// <summary>
        /// Validation(s) will happens at every change on the value.
        /// </summary>
        public static ValidatableValue<T> AutoValidatingValue(IEnumerable<IValidationRule<T, string>> validationRules = null)
        {
            var vo = new ValidatableValue<T>(true);
            if (validationRules != null)
                vo.ValidationRules.AddRange(validationRules);
            return vo;
        }

        /// <summary>
        /// Client must trigger validation(s) manually.
        /// </summary>
        public static ValidatableValue<T> ManuallyValidatingValue(IEnumerable<IValidationRule<T, string>> validationRules = null)
        {
            var vo = new ValidatableValue<T>(false);
            if (validationRules != null)
                vo.ValidationRules.AddRange(validationRules);
            return vo;
        }
        #endregion Factory

        /// <summary>
        /// Check if the value verifies all validation rules.
        /// </summary>
        public bool Validate()
        {
            _errors.Clear();

            _errors.AddRange(
                ValidationRules
                .SelectOptional(v => v.Validate(Value)));

            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(nameof(Value)));
            _viewModel.RaisePropertyChanged(nameof(HasErrors));
            _viewModel.RaisePropertyChanged(nameof(FirstError));

            return !HasErrors;
        }

        #region Equality
        public static bool operator !=(ValidatableValue<T> vo1, ValidatableValue<T> vo2)
        {
            return !(vo1 == vo2);
        }

        public static bool operator ==(ValidatableValue<T> vo1, ValidatableValue<T> vo2)
        {
            if ((object)vo1 == null || (object)vo2 == null)
                return Object.Equals(vo1, vo2);
            return vo1.Equals(vo2);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            var objAsVO = obj as ValidatableValue<T>;

            return Equals(objAsVO);
        }

        public bool Equals(ValidatableValue<T> other)
        {
            #region Comparaison sur Value

            if (other == null) return false;
            if (!(other?.Value?.Equals(Value)).GetValueOrDefault()) return false;

            #endregion Comparaison sur Value

            #region Comparaison sur les règles de validation

            if (other.ValidationRules == null && ValidationRules == null) return true;
            if (other.ValidationRules.Count == 0 && ValidationRules.Count == 0) return true;
            if (other.ValidationRules.Count != ValidationRules.Count) return false;
            if (!other.ValidationRules.All(ValidationRules.Contains)) return false;

            #endregion Comparaison sur les règles de validation

            return true;
        }

        public override int GetHashCode()
        {
            int hash = 1;
            foreach (var item in ValidationRules)
                hash *= item.GetHashCode();

            return (Value?.GetHashCode()).GetValueOrDefault() ^ hash;
        }
        #endregion Equality

        public override string ToString() => Value?.ToString();

        public static implicit operator T(ValidatableValue<T> vo) => vo.Value;
    }
}
