using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValuteMaxMin.Core
{
    class Exchange 
    {
// делить на номинал не забыть     
       public string MaxCost(List<DB.ExchangeData> ExchangeList)
        {
            var p = ExchangeList.Max(ExchangeData => ExchangeData.Value = ExchangeData.Value / Convert.ToDouble(ExchangeData.Nominal) );
          
            foreach (var s in ExchangeList)
            {
                if (s.Value >= p) {
                    return "================\nСамая дорогая валюта, номинал 1:1\n================" +
                        "\nValuteID: "+ s.ValuteID +", " +
                        "\nNumCode: "+s.NumCode+", " +
                        "\nCharCode: "+s.CharCode+", " +
                        "\nNominal: "+s.Nominal+", " +
                        "\nName: "+s.Name+", " +
                        "\nValue: "+ String.Format("{0:0.000000000}", s.Value) + "" +
                        "\n================\n";
                }
            
            }
            return p.ToString();
        }

       public string MinCost(List<DB.ExchangeData> ExchangeList)
        {
            var p = ExchangeList.Min(ExchangeData => ExchangeData.Value = ExchangeData.Value / Convert.ToDouble(ExchangeData.Nominal));

            foreach (var s in ExchangeList)
            {
                if (s.Value <= p)
                {
                    return "================\nСамая дешевая валюта, номинал 1:1\n================" +
                        "\nValuteID: " + s.ValuteID + ", " +
                        "\nNumCode: " + s.NumCode + ", " +
                        "\nCharCode: " + s.CharCode + ", " +
                        "\nNominal: " + s.Nominal + ", " +
                        "\nName: " + s.Name + ", " +
                        "\nValue: " + String.Format("{0:0.000000000}", s.Value) + "" +
                        "\n================\n";
                }
            }
            return p.ToString();
        }
    }
}
