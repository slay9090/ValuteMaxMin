using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ValuteMaxMin.DB
{
    class DataStock
    {
        private DB.GetHttpData _gethttpdata;

        public DataStock(DB.GetHttpData getHttpData) {
            _gethttpdata = getHttpData;  
        }
     
        List<ExchangeData> ExchangeDataCollection = new List<ExchangeData>();

        public void CreateCollection(string xml) { 
              XDocument xdoc = XDocument.Parse(xml);
           
            foreach (XElement valuteElement in xdoc.Element("ValCurs").Elements("Valute"))
            {
              string idAttribute = (string)valuteElement.Attribute("ID");
                int numCodeElement = (int) valuteElement.Element("NumCode");
                string charCodeCodeElement = (string)valuteElement.Element("CharCode");
                int nominalCodeElement = (int)valuteElement.Element("Nominal");
                string nameCodeElement = (string)valuteElement.Element("Name");       
                double valueCodeElement = Convert.ToDouble(valuteElement.Element("Value").Value);


                if (numCodeElement != 0 && charCodeCodeElement !=null && nominalCodeElement !=0 && nameCodeElement !=null && valueCodeElement !=0 )
                {
                  //Console.WriteLine("ID: {0}", idAttribute);
                  // Console.WriteLine("NumCode: {0}", numCodeElement);
                  //  Console.WriteLine("CharCode: {0}", charCodeCodeElement);
                  //  Console.WriteLine("nominal: {0}", nominalCodeElement);
                  //  Console.WriteLine("Name: {0}", nameCodeElement);
                  //  Console.WriteLine("Value: {0}", valueCodeElement);

                      Add(idAttribute,numCodeElement,charCodeCodeElement,nominalCodeElement,nameCodeElement,valueCodeElement);

                }               
            }
          
        }

        private void Add(string ValuteID, int NumCode, string CharCode, int Nominal, string Name, double Value) {
  
            ExchangeDataCollection.Add(new ExchangeData {
                ValuteID = ValuteID,
                NumCode = NumCode,
                CharCode = CharCode,
                Nominal = Nominal,
                Name = Name,
                Value = Value

            });
               
        }

        public List<ExchangeData> GetList () {
               return ExchangeDataCollection;
        }
    }
}
