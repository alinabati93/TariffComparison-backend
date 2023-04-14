namespace TariffComparison.Model
{
    public class TariffDefinition
    {
        public string Name { get; set; }
        public int Type { get; set; }
        public int? BaseCost { get; set; }
        public int? IncludedKwh { get; set; }
        public int? AdditionalKwhCost { get; set; }
    }
}
