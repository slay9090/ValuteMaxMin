using System;

namespace ValuteMaxMin.DB
{
    class ExchangeData : IComparable<ExchangeData>
    {
        public string ValuteID { get; set; }
        public int NumCode { get; set; }
        public string CharCode { get; set; }
        public int Nominal { get; set; } // тут не забыть добавить проверку на ноль, что бы не случилось /0
        public string Name { get; set; }
        public double Value { get; set; }

        public int CompareTo(ExchangeData other)
        {
            return Value.CompareTo(other.Value);
        }
    }
}
