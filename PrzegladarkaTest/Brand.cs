using System.Collections.Generic;

namespace PrzegladarkaTest
{
    public  class Brand
    {
        public string Name { get; set; }
        public string BrandICId { get; set; }
        public List<CarModel> Models { get; set; }
    }

}