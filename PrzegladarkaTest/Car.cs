using System.Collections.Generic;

namespace PrzegladarkaTest
{
    public class Car
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public string ProductionYearFrom { get; set; }
        public string ProductionYearTo { get; set; }
        public List<Engine> Engines { get; set; }
    }
}