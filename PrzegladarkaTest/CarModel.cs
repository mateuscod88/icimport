using System;
using System.Collections.Generic;
using System.Text;

namespace PrzegladarkaTest
{
    public class CarModel
    {
        public string DateTo { get; internal set; }
        public string DateFrom { get; internal set; }
        public string Name { get; internal set; }
        public string BrandName { get; internal set; }
        public string BrandId { get; internal set; }
        public string ModelId { get; internal set; }
        public List<Engine> Engines { get; set; }
    }
}
