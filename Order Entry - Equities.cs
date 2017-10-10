/*
Disclaimer
  REDI Global Technologies LLC (“REDI”) may provide authorized users of the REDIPlus 
  System with various Application Programming Interface (“API”) tools.  By utilizing 
  API tools provided by REDI, THE USER OF THE API TOOLS UNDERSTANDS THAT USE OF SUCH 
  TOOLS MAY EFFECT LIVE TRADING.  The user of the API tools assumes all responsibility 
  for any action, or lack thereof, taken in a live trading environment including but 
  not limited to execution of orders, cancellation of orders, modification of orders, 
  analysis of market data, or the calculation of any position, order, complex order, 
  or spread.  REDI and its affiliates specifically disclaim all warranties for use of 
  API tools, express or implied, including implied warranties of merchantability and 
  fitness for a particular purpose, and any operation of the API tools with the REDI
  Plus System.  Neither REDI nor any of its affiliates warrants that the API tools 
  will be uninterrupted or error-free, or that defects in the foregoing can or will 
  be corrected. 
*/

using System;
using RediLib;

namespace OrderEntry
{
    class Program
    {
        static void Main(string[] args)
        {
          
            ORDER hOrder = new ORDER();
            Object err = null;
            Object result;

            hOrder.Side = "Buy";
            hOrder.Symbol = "ZVZZT";
            hOrder.Quantity = "1";
            hOrder.PriceType = "Market";
            hOrder.Exchange = "DEMO DMA";
            hOrder.TIF = "Day";
            hOrder.Account = "00999900";
            hOrder.Ticket = "Bypass";

            result = hOrder.Submit(err);

            System.Console.WriteLine(result + " " + err + hOrder.Ticket);
            System.Console.WriteLine(DateTime.Now.ToString("h:mm:ss.fff tt"));
            Console.ReadLine();

        }
    }
}
