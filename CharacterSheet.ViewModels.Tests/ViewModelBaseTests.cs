using Xunit;
using FsCheck;
using FsCheck.Xunit;
using System;
using System.ComponentModel;

namespace CharacterSheet.ViewModels.Tests
{
    public class ViewModelBaseTests
    {
        [Fact]
        public void ViewModelBase_Implement_INotifyPropertyChanged() =>
            Assert.IsAssignableFrom<INotifyPropertyChanged>(new ViewModelBase());

        [Property]
        public Property ViewModelBase_CanAlways_RaisePropertyChanged(string propertyName)
        {
            new ViewModelBase().RaisePropertyChanged(propertyName);
            return true.ToProperty();
        }

        [Property]
        public Property RaisePropertyChanged_MustRaise_PropertyChanged_With_PropertyName(string propertyName)
        {
            bool propertyChangedIsCalled = false;
            var viewModelBase = new ViewModelBase();
            viewModelBase.PropertyChanged += (sender, args) => 
            {
                propertyChangedIsCalled = true;
                Assert.Equal(propertyName, args.PropertyName);
            };

            viewModelBase.RaisePropertyChanged(propertyName);

            return propertyChangedIsCalled.ToProperty();
        }

        [Property]
        public Property ViewModelBase_Can_SetValue_WhileRaising_PropertyChanged(int value, int newValue, string propertyName)
        {
            if (value == newValue)
                return true.ToProperty();

            bool propertyChangedIsCalled = false;
            var viewModelBase = new ViewModelBase();
            viewModelBase.PropertyChanged += (sender, args) =>
            {
                propertyChangedIsCalled = true;
            };

            viewModelBase.SetValue(ref value, newValue, propertyName);

            return (value == newValue && propertyChangedIsCalled).ToProperty();
        }

        [Property]
        public Property ViewModelBase_Can_SetValue_WithReferenceTypeToo(string value, string newValue, string propertyName)
        {
            if (value == newValue)
                return true.ToProperty();

            bool propertyChangedIsCalled = false;
            var viewModelBase = new ViewModelBase();
            viewModelBase.PropertyChanged += (sender, args) =>
            {
                propertyChangedIsCalled = true;
            };

            viewModelBase.SetValue(ref value, newValue, propertyName);

            return (value == newValue && propertyChangedIsCalled).ToProperty();
        }

        [Property]
        public Property SetValue_ShouldNotRaisePropertyChanged_When_ValueAndNewValue_AreTheSame(string value, string propertyName)
        {
            bool propertyChangedIsCalled = false;
            var viewModelBase = new ViewModelBase();
            viewModelBase.PropertyChanged += (sender, args) =>
            {
                propertyChangedIsCalled = true;
            };
            string initialValue = value == null ? null : new string(value);
            viewModelBase.SetValue(ref initialValue, value, propertyName);

            return (string.Equals(initialValue, value) && !propertyChangedIsCalled).ToProperty();
        }

        [Property]
        public Property SetValue_Should_ReturnTrue_WhenValueIsSet(int value, int newValue, string propertyName)
        {
            bool propertyChangedIsCalled = false;
            var viewModelBase = new ViewModelBase();
            viewModelBase.PropertyChanged += (sender, args) =>
            {
                propertyChangedIsCalled = true;
            };

            var result = viewModelBase.SetValue(ref value, newValue, propertyName);

            return (propertyChangedIsCalled && result)
                .Or(!propertyChangedIsCalled && !result);
        }
    }
}
