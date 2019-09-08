using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValuteMaxMin
{
    class Program 
    {
        static void Main(string[] args)
        {
            Core.Exchange _exchange = new Core.Exchange();
            DB.GetHttpData getHttp = new DB.GetHttpData("http://www.cbr.ru/scripts/XML_daily.asp"); //откуда парсим данные
            DB.DataStock dataStock = new DB.DataStock(getHttp); // 
            dataStock.CreateCollection(getHttp.GetDocumentContents()); // создаем свою коллекцию
            Console.WriteLine(_exchange.MaxCost(dataStock.GetList())); // Max
            Console.WriteLine(_exchange.MinCost(dataStock.GetList())); // Min
            Console.ReadKey();
        }
      
    }
}
