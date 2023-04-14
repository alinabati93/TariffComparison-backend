using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TariffComparison.Model;

namespace TariffComparison.Service.Interface
{
    public interface ITariffService
    {
        /// <summary>
        /// Read all tariffs from the json file
        /// </summary>
        /// <returns></returns>
        public List<TariffDefinition> GetAll();
        /// <summary>
        /// Calculate annual costs in all tariffs
        /// </summary>
        /// <param name="input">Tariff Calculation Model to calculate all tariffs</param>
        /// <param name="tariffDefinitions">List of tariffs which you want to calculate annual costs with them</param>
        /// <returns></returns>
        public List<TariffViewModel> CalculateTariffAlgorithm(TariffCalculation input, List<TariffDefinition> tariffDefinitions);
    }
}
