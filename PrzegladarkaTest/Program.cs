using System;
using System.Diagnostics;
using System.IO;

namespace PrzegladarkaTest
{
    class Program
    {
        static void Main(string[] args)
        {

            var icImporter = new ImporterIC();
            var cars = icImporter.GetCars();
            //var cars = icImporter.GetBrands();

            //icImporter.GetModelsByBrandId("5");
            //icImporter.GetEnginesByModelId("4955","5", "A3 (8P1)");
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
