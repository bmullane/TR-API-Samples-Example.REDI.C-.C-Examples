using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows.Threading;
using System.Windows.Input;
using System.Text;
using RediLib;

namespace ExecutionMonitor
{
    internal class ExecutionWindow : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public enum CacheControlActions
        {
            Snapshot = 1,
            Add = 4,
            Update = 5,
            Delete = 8
        }

        public enum WatchType
        {
            L1,
            L2,
            PANDL,
            FIRM,
            L1OPT,
            TimesAndSales,
            HistoricalTimesAndSales
        }

        #region Executions
        private ObservableCollection<Execution> _executions;
        public ObservableCollection<Execution> Executions
        {
            get { return _executions; }
            set { this.ViewModelSetValue("Executions", ref _executions, value, this.PropertyChanged);
            Console.WriteLine("ViewModelSetValue - Executions");
            }
        }
        #endregion

        public ExecutionWindow()
        {
            Executions = new MTObservableCollection<Execution>();
        }


        public class MTObservableCollection<T> : ObservableCollection<T>
        {
            public override event NotifyCollectionChangedEventHandler CollectionChanged;
            protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
            {
                NotifyCollectionChangedEventHandler CollectionChanged = this.CollectionChanged;
                if (CollectionChanged != null)
                    foreach (NotifyCollectionChangedEventHandler nh in CollectionChanged.GetInvocationList())
                    {
                        DispatcherObject dispObj = nh.Target as DispatcherObject;
                        if (dispObj != null)
                        {
                            Dispatcher dispatcher = dispObj.Dispatcher;
                            if (dispatcher != null && !dispatcher.CheckAccess())
                            {
                                dispatcher.BeginInvoke(
                                (Action)(() => nh.Invoke(this,
                                new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset))),
                                DispatcherPriority.DataBind);
                                continue;
                            }
                        }
                        nh.Invoke(this, e);
                    }
            }
        }
        

       

    }
}


