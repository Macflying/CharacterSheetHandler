using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CharacterSheet.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
        }

        public bool SetValue<T>(ref T fieldValue, T newValue, string propertyName)
        {
            if (!EqualityComparer<T>.Default.Equals(fieldValue, newValue))
            {
                fieldValue = newValue;
                RaisePropertyChanged(propertyName);
                return true;
            }
            return false;
        }
    }
}
