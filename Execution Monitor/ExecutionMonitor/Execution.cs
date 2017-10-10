using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ExecutionMonitor 
{
    class Execution : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private string _time;

        public string Time
        {
            get { return _time; }
            set { this.ViewModelSetValue("Time", ref _time, value, this.PropertyChanged); }

        }

        private string _brseq;

        public string BrSeq
        {
            get { return _brseq; }
            set { this.ViewModelSetValue("BrSeq", ref _brseq, value, this.PropertyChanged); }

        }

        private string _account;

        public string Account
        {
            get { return _account; }
            set { this.ViewModelSetValue("Account", ref _account, value, this.PropertyChanged); }

        }

        private string _side;

        public string Side
        {
            get { return _side; }
            set { this.ViewModelSetValue("Side", ref _side, value, this.PropertyChanged); }

        }

        public string _quantity;

        public string Quantity
        {
            get { return _quantity; }
            set { this.ViewModelSetValue("Quantity", ref _quantity, value, this.PropertyChanged); }
        }

        public string _execquantity;

        public string ExecQuantity
        {
            get { return _execquantity; }
            set { this.ViewModelSetValue("ExecQuantity", ref _execquantity, value, this.PropertyChanged); }
        }

        public string _symbol;

        public string Symbol
        {
            get { return _symbol; }
            set { this.ViewModelSetValue("Symbol", ref _symbol, value, this.PropertyChanged); }
        }

        public string _execpr;

        public string ExecPr
        {
            get { return _execpr; }
            set { this.ViewModelSetValue("ExecPr", ref _execpr, value, this.PropertyChanged); }
        }

        public string _exchange;

        public string Exchange
        {
            get { return _exchange; }
            set { this.ViewModelSetValue("Exchange", ref _exchange, value, this.PropertyChanged); }
        }

        public string _contra;

        public string Contra
        {
            get { return _contra; }
            set { this.ViewModelSetValue("Contra", ref _contra, value, this.PropertyChanged); }
        }

        public string _enteredtime;

        public string EnteredTime
        {
            get { return _enteredtime; }
            set { this.ViewModelSetValue("EnteredTime", ref _enteredtime, value, this.PropertyChanged); }
        }

        public string _tif;

        public string TIF
        {
            get { return _tif; }
            set { this.ViewModelSetValue("TIF", ref _tif, value, this.PropertyChanged); }
        }


    }
}
