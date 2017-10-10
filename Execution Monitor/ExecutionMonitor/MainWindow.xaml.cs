using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RediLib;


namespace ExecutionMonitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly CacheControl execCache;
        ExecutionWindow ew;
        object exec_err;

        public enum CacheControlActions
        {
            Snapshot = 1,
            Add = 4,
            Update = 5,
            Delete = 8
        }


        public MainWindow()
        {
            ew = new ExecutionWindow();
            execCache = new CacheControl();
            execCache.CacheEvent += execCacheHandler;
            executionSubmit();
        

            InitializeComponent();
            DataContext = ew;
        }

        public static object GetCell(CacheControl cc, int row, string columnName, out int errorCode)
        {
            object value = null;
            object errCode = null;
            cc.GetCell(row, columnName, ref value, ref errCode);
            errorCode = (int)errCode;
            if (value != null)
            {
                return value;
            }
            return string.Empty;
        }
        
        public void executionSubmit()
        {
            object result = execCache.Submit("Message", "(msgtype == 14)", ref exec_err);
        }

        private void execCacheHandler(int action, int row)
        {
            string Time;
            string BrCode;
            string BrSeq;
            string Account;
            string Side;
            string Quantity;
            string ExecQuantity;
            string Symbol;
            string ExecPrice;
            string Exchange;
            string Contra;
            string EnteredTime;
            string TIF;

            int errCode;

            //Console.WriteLine("action: " + action.ToString() + "; row: " + row.ToString());

            if (row >= 0)
            {

                //Console.WriteLine("action: " + action.ToString());


                switch (action)
                {
                    case (int)CacheControlActions.Add:
                    case (int)CacheControlActions.Update:
                        try
                        {
                            Time = GetCell(execCache, row, "Side", out errCode).ToString().TrimStart();
                            BrCode = GetCell(execCache, row, "BranchCode", out errCode).ToString().TrimStart();
                            BrSeq = GetCell(execCache, row, "BranchSeq", out errCode).ToString().TrimStart();
                            Account = GetCell(execCache, row, "Account", out errCode).ToString().TrimStart();
                            Side = GetCell(execCache, row, "Side", out errCode).ToString().TrimStart();
                            Quantity = GetCell(execCache, row, "Quantity", out errCode).ToString().TrimStart();
                            ExecQuantity = GetCell(execCache, row, "ExecQuantity", out errCode).ToString().TrimStart();
                            Symbol = GetCell(execCache, row, "DisplaySymbol", out errCode).ToString().TrimStart();
                            ExecPrice = GetCell(execCache, row, "ExecPrice", out errCode).ToString().TrimStart();
                            Exchange = GetCell(execCache, row, "Exchange", out errCode).ToString().TrimStart();
                            Contra = GetCell(execCache, row, "Contra", out errCode).ToString().TrimStart();
                            EnteredTime = GetCell(execCache, row, "EnteredTime", out errCode).ToString().TrimStart();
                            TIF = GetCell(execCache, row, "TIF", out errCode).ToString().TrimStart();
                            //Console.WriteLine("5 - Time = "  + Time + ";BrSeq = " + BrSeq + ";row = " + row);

                            var Exec = new Execution();

                            Time = Time.Remove(0, 9);

                            BrSeq = BrCode + BrSeq;
                            Exec.Time = Time;
                            Exec.BrSeq = BrSeq;
                            Exec.Account = Account;
                            Exec.Side = Side;
                            Exec.Quantity = Quantity;
                            Exec.ExecQuantity = ExecQuantity;
                            Exec.Symbol = Symbol;
                            Exec.ExecPr = ExecPrice;
                            Exec.Exchange = Exchange;
                            Exec.Contra = Contra;
                            EnteredTime = EnteredTime.Remove(0, 9);
                            Exec.EnteredTime = EnteredTime;
                            Exec.TIF = TIF;

                            ew.Executions.Add(Exec);
                        }
                        catch
                        {

                        }
                        break;
                    case (int)CacheControlActions.Snapshot:
                        try
                        {
                            Console.WriteLine("Snapshot");
                            for (int i = 0; i < row; i++)
                            {
                                Console.WriteLine(i);
                                Time = GetCell(execCache, i, "Time", out errCode).ToString().TrimStart();
                                BrSeq = GetCell(execCache, i, "BranchSeq", out errCode).ToString().TrimStart();
                                BrCode = GetCell(execCache, i, "BranchCode", out errCode).ToString().TrimStart();
                                Account = GetCell(execCache, i, "TicketRef", out errCode).ToString().TrimStart();
                                Side = GetCell(execCache, i, "Side", out errCode).ToString().TrimStart();
                                Quantity = GetCell(execCache, i, "Quantity", out errCode).ToString().TrimStart();
                                ExecQuantity = GetCell(execCache, i, "ExecQuantity", out errCode).ToString().TrimStart();
                                Symbol = GetCell(execCache, i, "DisplaySymbol", out errCode).ToString().TrimStart();
                                ExecPrice = GetCell(execCache, i, "ExecPrice", out errCode).ToString().TrimStart();
                                Exchange = GetCell(execCache, i, "Exchange", out errCode).ToString().TrimStart();
                                Contra = GetCell(execCache, i, "Contra", out errCode).ToString().TrimStart();
                                EnteredTime = GetCell(execCache, i, "EnteredTime", out errCode).ToString().TrimStart();
                                TIF = GetCell(execCache, i, "TIF", out errCode).ToString().TrimStart();
                                Time = Time.Remove(0, 9);
                                //Console.WriteLine("1 - Time = " + Time + ";BrSeq = " + BrSeq + ";row = " + i);
                                var Exec = new Execution();
                                BrSeq = BrCode + BrSeq;
                                
                                Exec.Time = Time;
                                Exec.BrSeq = BrSeq;
                                Exec.Account = Account;
                                Exec.Side = Side;
                                Exec.Quantity = Quantity;
                                Exec.ExecQuantity = ExecQuantity;
                                Exec.Symbol = Symbol;
                                Exec.ExecPr = ExecPrice;
                                Exec.Exchange = Exchange;
                                Exec.Contra = Contra;
                                EnteredTime = EnteredTime.Remove(0, 9);
                                Exec.EnteredTime = EnteredTime;
                                Exec.TIF = TIF;
 
                                ew.Executions.Add(Exec);
                                //listView1.Items.Add(BrSeq);
                                
                            }
                        }
                        catch
                        {
                        }
                        break;
                   
                }
            }
        }
    }
}
