using System.Text.Json.Serialization;

namespace TariffComparison.Model
{
    public class TariffViewModel
    {
        public string Name { get; set; }
        [JsonIgnore]
        public int BaseCosts { get; set; }
        public string BaseCostsText { get; set; }
        [JsonIgnore]
        public int ConsumptionCosts { get; set; }
        public string ConsumptionCostsText
        {
            get
            {
                return ConsumptionCosts + "€";
            }
        }
        [JsonIgnore]
        public int AnnualCosts
        {
            get
            {
                return BaseCosts + ConsumptionCosts;
            }
        }
        public string AnnualCostsText
        {
            get
            {
                return AnnualCosts + "€";
            }
        }
    }
}
