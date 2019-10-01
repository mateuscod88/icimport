namespace PrzegladarkaTest
{
    public class Engine
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public EngineDetail EngineDetail { get; set; }
    }
    public class EngineDetail
    {
        public string ProductionFrom { get; set; }
        public string FuelType { get; set; }
        public string EngineTypeCode { get; set; }
    }
}