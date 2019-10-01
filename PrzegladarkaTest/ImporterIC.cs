using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrzegladarkaTest
{
    public class ImporterIC
    {
        public List<Brand> GetBrands()
        {
            RestClient client = new RestClient("https://e-katalog.intercars.com.pl/u/tecdoc/u_tecdoc_result.php");
            RestRequest request = new RestRequest();
            request.AddParameter("call", "marka");
            request.AddParameter("wsk", "O");
            var response = client.Execute(request);
            var carsSplited = response.Content.Split("<li >");
            var brands = new List<Brand>();
            foreach (var item in carsSplited)
            {
                if (!item.Contains("ul"))
                {
                    var carWithoutTag = item.Substring(0, item.Length - 8);
                    var hrefStartIndex = carWithoutTag.LastIndexOf("/");
                    var hrefEndIndex = carWithoutTag.LastIndexOf("\"");
                    var href = carWithoutTag.Substring(hrefStartIndex + 1, hrefEndIndex - hrefStartIndex - 1);
                    var brandArrowEndSignIndex = carWithoutTag.LastIndexOf('>');
                    var brandArrowStartSignIndex = carWithoutTag.LastIndexOf('<');
                    var brandName = carWithoutTag.Substring(brandArrowEndSignIndex + 1, brandArrowStartSignIndex - brandArrowEndSignIndex - 1);
                    brands.Add(new Brand { Name = brandName });
                }

            }

            return brands;
        }
        public List<Car> GetModelsByBrandId(string brandId)
        {
            RestClient client = new RestClient("https://e-katalog.intercars.com.pl/u/tecdoc/u_tecdoc_result.php");
            RestRequest request = new RestRequest();
            request.AddParameter("call", "model");
            request.AddParameter("wsk", "O");
            request.AddParameter("mar", brandId);


            var response = client.Execute(request);
            var modelsSplited = response.Content.Split("<li");
            var models = new List<string>();
            foreach (var item in modelsSplited)
            {


                if (!item.Contains("ul"))
                {
                    if (item.IndexOf("<span>") > -1)
                    {
                        var spanStartIndex = item.IndexOf("<span>") > -1 ? item.IndexOf("<span>") : item.IndexOf("<span class=\"center\">");
                        var spanEndIndex = item.IndexOf("</span>");
                        var modelName = item.Substring(spanStartIndex + 6, spanEndIndex - spanStartIndex - 6);
                        models.Add(modelName);
                    }
                    else
                    {
                        var spanStartIndex = item.IndexOf("<span class=\"center\">");
                        var spanEndIndex = item.IndexOf("</span>");
                        var modelName = item.Substring(spanStartIndex + 21, spanEndIndex - spanStartIndex - 21);
                        models.Add(modelName);
                    }
                }
                if (item.Contains("</ul>"))
                {
                    var ulEndIndex = item.IndexOf("</ul>");
                    if (ulEndIndex > -1)
                    {
                        var itemWithoutUl = item.Substring(0, ulEndIndex);
                        if (item.IndexOf("<span>") > -1)
                        {
                            var spanStartIndex = item.IndexOf("<span>") > -1 ? item.IndexOf("<span>") : item.IndexOf("<span class=\"center\">");
                            var spanEndIndex = item.IndexOf("</span>");
                            var modelName = item.Substring(spanStartIndex + 6, spanEndIndex - spanStartIndex - 6);
                            models.Add(modelName);
                        }
                        else
                        {
                            var spanStartIndex = item.IndexOf("<span class=\"center\">");
                            var spanEndIndex = item.IndexOf("</span>");
                            var modelName = item.Substring(spanStartIndex + 21, spanEndIndex - spanStartIndex - 21);
                            models.Add(modelName);
                        }
                    }
                }



            }
            var cars = new List<Car>();
            for (int i = 0; i < models.Count / 4; i++)
            {
                if (models.Count / 4 > i + 3)
                {
                    cars.Add(new Car { Name = models[i * 4], Brand = models[(i * 4) + 1], ProductionYearFrom = models[(i * 4) + 2], ProductionYearTo = models[(i * 4) + 3] });

                }
            }
            foreach (var item in cars)
            {
                Console.WriteLine($"Marka: {item.Name}>>Model: {item.Brand}>>Od: {item.ProductionYearFrom}--{item.ProductionYearTo}");
            }
            return new List<Car>();
        }
        public List<Car> GetEnginesByModelId(string modelId)
        {
            RestClient client = new RestClient("https://e-katalog.intercars.com.pl/u/tecdoc/u_tecdoc_result.php");
            RestRequest request = new RestRequest();
            request.AddParameter("call", "typ");
            request.AddParameter("model", modelId);
            request.AddParameter("wsk", "O");

            var response = client.Execute(request);
            var EnginesSplited = response.Content.Split("<li >");

            return new List<Car>();
        }
        public List<Car> GetZastosowanie()
        {
            RestClient client = new RestClient("https://e-katalog.intercars.com.pl/u/u_karta_stosowanew.php");
            RestRequest request = new RestRequest();
            //request.AddParameter("artnr", "1410407");
            request.AddParameter("artnr", "1411184");

            request.AddParameter("call", "typ");
            request.AddParameter("wit", "KATALOG");
            request.AddParameter("wsk", "O");
            request.AddParameter("lang", "PL");


            var response = client.Execute(request);
            var EnginesSplited = response.Content.Split("<li");
            var carList = new List<Car>();
            Car car = null;
            List<Engine> engines = null;
            foreach (var item in EnginesSplited)
            {
                if (!item.Contains("<script") && !item.Contains("</a") && !item.Contains("id=\"mar"))
                {
                    if (engines != null)
                    {
                        car.Engines = engines;
                        carList.Add(car);
                        car = null;
                        engines = null;
                    }
                    var spanIndex = item.LastIndexOf("</span");

                    var itemWithoutSpan = item.Substring(0, spanIndex + 1);

                    var spanStartIndex = itemWithoutSpan.LastIndexOf(">");
                    var spanEndIndex = itemWithoutSpan.LastIndexOf("<");
                    var modelName = item.Substring(spanStartIndex + 1, spanEndIndex - spanStartIndex - 1);
                    if (car == null)
                    {
                        car = new Car();
                    }
                    car.Brand = modelName;
                }
                else if (item.Contains("</a") && !item.Contains("id=\"mar"))
                {
                    var spanIndex = item.LastIndexOf("</a");

                    var itemWithoutSpan = item.Substring(0, spanIndex + 1);

                    var spanStartIndex = itemWithoutSpan.LastIndexOf(">");
                    var spanEndIndex = itemWithoutSpan.LastIndexOf("<");
                    var modelName = item.Substring(spanStartIndex + 1, spanEndIndex - spanStartIndex - 1);
                    var idStartIndex = itemWithoutSpan.IndexOf("stypu(");
                    var withoutStypu = itemWithoutSpan.Substring(idStartIndex, itemWithoutSpan.Length - idStartIndex);
                    var commaEndIndex = withoutStypu.IndexOf(",");
                    var bracketStartIndex = withoutStypu.IndexOf("(");
                    var id = withoutStypu.Substring(bracketStartIndex + 1, commaEndIndex - bracketStartIndex - 1);
                    if (engines == null)
                    {
                        engines = new List<Engine>();
                    }
                    var detail = GetEngineDetails(id);
                    engines.Add(new Engine { Name = modelName, Id = id,EngineDetail = detail});
                }
                else if (item.Contains("id=\"mar"))
                {

                    var spanIndex = item.LastIndexOf("</span");

                    var itemWithoutSpan = item.Substring(0, spanIndex + 1);

                    var spanStartIndex = itemWithoutSpan.LastIndexOf(">");
                    var spanEndIndex = itemWithoutSpan.LastIndexOf("<");
                    var modelName = item.Substring(spanStartIndex + 1, spanEndIndex - spanStartIndex - 1);
                    if (engines != null)
                    {
                        car.Engines = engines;
                        carList.Add(car);
                        car = null;
                        engines = null;
                    }
                    if (car == null)
                    {
                        car = new Car();
                    }
                    car.Name = modelName;
                }
            }
            foreach (var carItem in carList)
            {
                Console.WriteLine(carItem.Name);
                Console.WriteLine(carItem.Brand);
                foreach (var item in carItem.Engines)
                {
                    Console.WriteLine($"{item.Name}");
                }
            }
            return carList;
        }

        public EngineDetail GetEngineDetails(string id)
        {
            RestClient client = new RestClient("https://e-katalog.intercars.com.pl/dynamic/uni/ws_szczegoly_typu_tecdoc.php");
            RestRequest request = new RestRequest();
            request.AddParameter("typ", id);
            request.AddParameter("wsk", "O");
            request.AddParameter("lang", "PL");


            var response = client.Execute(request);
            var EnginesSplited = response.Content.Split("<td");
            
            return GetEngineDetail(EnginesSplited);
        }
        private EngineDetail GetEngineDetail(string[] engineDetails)
        {
            var productionFrom = "Produkowany od:";
            var fuelType = "Paliwo:";
            var engineTypeCode = "Kody silnika:";
            var engineDetail = new EngineDetail();

            for (int i =0;i<engineDetails.Length;i++)
            {
                if (engineDetails[i].Contains(productionFrom))
                {
                    var arrowStartIndex = engineDetails[i + 1].IndexOf(">");
                    var arrowEndIndex = engineDetails[i + 1].IndexOf("<");
                    engineDetail.ProductionFrom = engineDetails[i+1].Substring(arrowStartIndex+1,arrowEndIndex - arrowStartIndex-1);
                }
                else if (engineDetails[i].Contains(fuelType))
                {
                    var arrowStartIndex = engineDetails[i + 1].IndexOf(">");
                    var arrowEndIndex = engineDetails[i + 1].IndexOf("<");
                    engineDetail.FuelType = engineDetails[i + 1].Substring(arrowStartIndex + 1, arrowEndIndex - arrowStartIndex - 1);

                }
                else if (engineDetails[i].Contains(engineTypeCode))
                {
                    var arrowStartIndex = engineDetails[i + 1].IndexOf(">");
                    var arrowEndIndex = engineDetails[i + 1].IndexOf("<");
                    engineDetail.EngineTypeCode = engineDetails[i + 1].Substring(arrowStartIndex + 1, arrowEndIndex - arrowStartIndex - 1);

                }
            }
            return engineDetail;
        }
}
}
