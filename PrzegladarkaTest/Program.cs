using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace PrzegladarkaTest
{
    class Program
    {
        static async Task Main(string[] args)
        {

            var icImporter = new ImporterIC();
            var cars = await icImporter.GetCars();
            string output = JsonConvert.SerializeObject(cars);
            using (StreamWriter outputFile = new StreamWriter("WriteLines.txt"))
            {
                outputFile.WriteLine(output);
            }
            //var cars = icImporter.GetBrands();


            //icImporter.GetModelsByBrandId("5");
            //icImporter.GetEnginesByModelId("4955", "5", "A3 (8P1)");
            //var carList = icImporter.GetZastosowanie();
            //using (var sw = File.CreateText("Zastosowanie.txt"))
            //{
            //    foreach (var carItem in carList)
            //    {
            //        sw.WriteLine(carItem.Name);
            //        sw.WriteLine(carItem.Brand);
            //        foreach (var item in carItem.Engines)
            //        {
            //            sw.WriteLine($"{item.Name}({item.EngineDetail.EngineTypeCode}) {item.EngineDetail.ProductionFrom}");
            //        }
            //    }
            //}
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
