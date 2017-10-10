using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ExecutionMonitor
{
        

    public static class ViewModelHelper
    {
        public static bool ViewModelSetValue<T>(this INotifyPropertyChanged viewModel, string propName, ref T currValue, T value, PropertyChangedEventHandler eventHandler)
        {
            if (Equals(currValue, value))
            {
                return false;
            }

            currValue = value;
            viewModel.RaisePropertyChanged(propName, eventHandler);

            return true;
        }

        public static void RaisePropertyChanged(this INotifyPropertyChanged viewModel, string propName, PropertyChangedEventHandler eventHandler)
        {
            if (eventHandler != null)
            {
                eventHandler(viewModel, new PropertyChangedEventArgs(propName));
            }
        }
    }
}

