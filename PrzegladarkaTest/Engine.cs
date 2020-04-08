namespace PrzegladarkaTest
{
    public class Engine
    {
        public string Id { get; set; }
        public string Name { get; set; }
        //public EngineDetail EngineDetail { get; set; }
        public string Code { get; internal set; }
        public string DateFrom { get; internal set; }
        public string DatoTo { get; internal set; }
        public string Capacity { get; internal set; }
        public string HorsePower { get; internal set; }
        public string KWPower { get; internal set; }
        public string BodyType { get; internal set; }
        public string ModelId { get; internal set; }
        public string BrandId { get; internal set; }
        public string ModelName { get; internal set; }
    }
    public class EngineDetail
    {
        public string ProductionFrom { get; set; }
        public string FuelType { get; set; }
        public string EngineTypeCode { get; set; }
    }
}