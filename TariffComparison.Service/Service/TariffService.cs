using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TariffComparison.Model;
using TariffComparison.Service.Interface;

namespace TariffComparison.Service.Service
{
    public class TariffService : ITariffService
    {
        public List<TariffDefinition> GetAll()
        {
            List<TariffDefinition> source = new List<TariffDefinition>();
            using (StreamReader r = new StreamReader("ExternalTarrifProvider/tariff.json"))
            {
                string json = r.ReadToEnd();
                if (!string.IsNullOrWhiteSpace(json))
                    source = JsonSerializer.Deserialize<List<TariffDefinition>>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }

            return source;
        }

        public List<TariffViewModel> CalculateTariffAlgorithm(TariffCalculation filters, List<TariffDefinition> tariffDefinitions)
        {
            var res = new List<TariffViewModel>();
            foreach (var item in tariffDefinitions)
            {
                var newResult = new TariffViewModel();
                newResult.Name = item.Name;

                switch (item.Type)
                {
                    case 1:
                        if (item.BaseCost.HasValue && item.AdditionalKwhCost.HasValue)
                        {
                            newResult.BaseCosts = item.BaseCost.Value * 12;
                            newResult.BaseCostsText = $"{newResult.BaseCosts}€ ({item.BaseCost}€ * 12month)";
                            newResult.ConsumptionCosts = filters.Consumption * item.AdditionalKwhCost.Value / 100;
                            res.Add(newResult);
                        }
                        break;
                    case 2:
                        if (item.BaseCost.HasValue && item.AdditionalKwhCost.HasValue && item.IncludedKwh.HasValue)
                        {
                            newResult.BaseCosts = item.BaseCost.Value;
                            newResult.BaseCostsText = $"{newResult.BaseCosts}€ (included {item.IncludedKwh}kwh annually)";
                            newResult.ConsumptionCosts = Math.Max(0, filters.Consumption - item.IncludedKwh.Value) * item.AdditionalKwhCost.Value / 100;
                            res.Add(newResult);
                        }
                        break;
                    default:
                        break;
                }
            }
            return res;
        }
    }
}
