using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace PrzegladarkaTest
{
    public class ImporterIC
    {
        public List<Car> GetCars()
        {
            var brands = GetBrands();
            foreach (var brand in brands)
            {
                //var models = GetModelsByBrandId(brand.BrandICId);
                var models = GetModelsByBrandId("5");

                foreach (var model in models)
                {
                    //var engines = GetEnginesByModelId(model.ModelId,model.BrandId,model.BrandName);
                    var engines = GetEnginesByModelId("4955", "5", "A3 (8P1)");

                }
            }
            return new List<Car>();
        }
        public List<Brand> GetBrands()
        {
            //HttpWebRequest webRequest = new HttpWebRequest();
            //webRequest.
            //RestClient client = new RestClient("https://e-katalog.intercars.com.pl/u/tecdoc/u_tecdoc_result.php");
            //RestRequest request = new RestRequest();
            //request.AddParameter("call", "marka_select");
            //request.AddParameter("wsk", "O");
            //request.AddHeader("Cache-Control", "no-cache");
            //request.AddHeader("Pragma", "no-cache");
            //request.AddHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
            //request.AddHeader("Accept-Encoding", "gzip, deflate, br");
            //request.AddHeader("Accept-Language", "pl,en-US;q=0.7,en;q=0.3");
            //request.AddHeader("Upgrade-Insecure-Requests", "1");
            //request.AddHeader("Connection", "keep-alive");




            //request.AddHeader("Cookie", "wit=KATALOG; chrst=utf-8; kraj=PL; f5_cspm=1234; f5avraaaaaaaaaaaaaaaa_session_=KBCCKGPDAJLODIBPCBANOKAAOPBIHDBDGLGCCFCPKNKAJOBLAIKEMEENNALMMHKADFIDJBIJLLLAJEBMADPADOJBMICBKDAKEDEGIGGCDACMOEKNEDDAHHOFIKBEBLGH; _ga=GA1.4.709208053.1580137613; _fbp=fb.2.1580137613388.872299162; u1=106657_O; u2=58252_O; lang=PL; wit=KATALOG; chrst=utf-8; kraj=PL; f5avraaaaaaaaaaaaaaaa_session_=MOGEDAOOBJELFDAKBNBLLPFOELKCMNMEHKMOJEPJPEAFGAJFMOFBHLGLHIANLLEMHOIDAFJBFLAKMACGHHBANMDBOILBOHACHLGAPGJOKJDAKMPLOOJGJABBIBPEMDGM; TS018b8814=01907be4dff28e5e3cb2cf6e87f0aaec47d92dc44fbf122429095143aa74bd04f238bb1ef1d942e2a692eb12859ab192ad7948127dbd621091ffa0ba8c166ebdb5b4eac860235ed9f519becd0bdc9e94e3592e4cf564466afc8624b5725a137897b3ca0195bcf269b0cad0c8297c6275d057da986bede2fe859cf00f506b2100fbd3a0446e248bd4e9fcb862eba97fb3fc340e9ba594072a18e936c8fe4b45c53c2b00a74168b80bf14187e52fe0c2c3835878ed2da203ebdd8e0a085a1e06e59bd3dea3b6; TS9a7c9db3027=0808d9cf08ab20005693e267e516c5155b972dfaca0d6fb3d410aed54047239f5fdd2ede5d02d30308c0675181113000f85ae32dc2de340341302fda2bac44748f326ced2b1b7142b8e166b58bbb8c5b72c5441983d77f20a3f92c482e14d52b; TS2c0aba38077=0808d9cf08ab280058aaa53d1a3cdce95cf0f2068c2443bc3ffdc57964aa32385b8daff02007947723d471e725ee17c208dd49acfe172000445331717978622a1f820029305e616a7c7431454f769795fec49b6e1cafa0cd; PHPSESSID=fo4nii28fukdtb3rt8fa7hp715; ickatalog=1; _gid=GA1.4.354354137.1586264153; TS00000000076=0808d9cf08ab2800700a438fd68158cda2622e5a409ff3c19784bbbe811744dfed688d2c51e2d0da5fc982b81ce7eeea089a687db309d000c48b61529dbe1f3a039e8e515a999c6130ec93863d6a5ab6fb97a17f0479943a4f7e692799a9410e10397584ff23346ec66d51d501f6e03b99c8d2ad57eda9289281c1fb3f7dadbd5dd93b44218ec41d594eb1be8aa4b262215f17525c10d3cad73e6fb2b306bcaf23760c9defc9927782fd91496b2d22314874fbb6f160583fd55af1590c276e3aa2f2d2cf834c4b47a5ece7f2561624622777205458188e0ad9bafb8a6f8f256f4424de456115d91cb4ad9d398721a3bed826a52bfcfe2af7146ef71fb8a2fd890f5be8bde138bd34; TSPD_101=0808d9cf08ab2800b1012e8c142fe6672bedc5d7e01284010b7c8c685aa512fa7758c74bfe2f053cc1035d580d2b548308b1ecc5d5051800267125a5be748b42485e816e9ec831a01e3bf81971ef214c; TSPD_101_DID=0808d9cf08ab2800700a438fd68158cda2622e5a409ff3c19784bbbe811744dfed688d2c51e2d0da5fc982b81ce7eeea089a687db306380042f131edb1c3adc306caaae718645ec5fbedf8233f39b9680a72322292a06f6f6183af43f805fd795adeed17ca90676a9c25172cb71fff0b; cookie_unia=1");
            //request.AddHeader("Host", "e-katalog.intercars.com.pl");




            //var response = client.Execute(request);
            string markaFilePath = @"C:\Custom\marka.txt";
            var markaFile = File.ReadAllLines(markaFilePath);
            var markaSplited = markaFile[0].Split("<li >");

            //var carsSplited = response.Content.Split("<li >");
            var carsSplited = markaSplited;
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
                    brands.Add(new Brand { Name = brandName, BrandICId = href });
                }

            }

            return brands;
        }
        public List<CarModel> GetModelsByBrandId(string brandId)
        {
            //RestClient client = new RestClient("https://e-katalog.intercars.com.pl/u/tecdoc/u_tecdoc_result.php");
            //RestRequest request = new RestRequest();
            //request.AddParameter("call", "model");
            //request.AddParameter("wsk", "O");
            //request.AddParameter("mar", brandId);


            //var response = client.Execute(request);
            //var modelsSplited = response.Content.Split("<li");
            string markaFilePath = @"C:\Custom\model.txt";
            var markaFile = File.ReadAllText(markaFilePath);
            var markaSplited = markaFile.Split("<li");
            var modelsSplited = markaSplited;
            var models = new List<string>();
            foreach (var item in modelsSplited)
            {

                if (item.Contains("ul"))
                {
                    if(item.IndexOf("model_") > -1)
                    {
                        var startIndex = item.IndexOf("model_");
                        var substr = item.Substring(startIndex);
                        var endIndex = substr.IndexOf("\"");
                        var modelId = substr.Substring(0, endIndex);
                        models.Add(modelId);
                    }
                }
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
            var cars = new List<CarModel>();
            //new CarModel { Name = models[i * 4], Brand = models[(i * 4) + 1], ProductionYearFrom = models[(i * 4) + 2], ProductionYearTo = models[(i * 4) + 3] }
            var car = new CarModel();
            car.BrandId = brandId;
            for (int i = 0; i < models.Count / 4; i++)
            {
                if( i < 4)
                {
                    continue;
                }
                if (models.Count - 1 == i)
                {
                    if (models[i].IndexOf(".") > -1 && models[i - 1].IndexOf(".") > -1)
                    {
                        car.DateTo = models[i];
                    }
                    else if (models[i].IndexOf(".") > -1)
                    {
                        car.DateFrom = models[i];

                    }
                    cars.Add(car);
                    continue;
                }
                
                if (models[i].IndexOf(".") > -1 && models[i - 2].IndexOf(".") > -1)
                {
                    car.DateTo = models[i];
                    cars.Add(car);
                    car = new CarModel { BrandId = brandId };

                }
                else if (models[i].IndexOf(".") > -1 && models[i + 2].IndexOf(".") > -1)
                {
                    car.DateFrom = models[i];
                }
                else if (models[i].IndexOf(".") > -1 && models[i + 2].IndexOf(".") == -1)
                {
                    car.DateFrom = models[i];
                    cars.Add(car);
                    car = new CarModel { BrandId = brandId };

                }
                else if (models[i-1].IndexOf(".") == -1 && models[i + 1].IndexOf(".") > -1)
                {
                    car.Name = models[i];

                }
                else if (models[i - 1].IndexOf(".") == -1 && models[i + 1].IndexOf(".") == -1 && models[i].IndexOf("model_") ==  -1)
                {
                    car.BrandName = models[i];

                }
                else if (models[i].IndexOf("model_") > -1)
                {
                    car.ModelId = models[i].Replace("model_", "");
                }

            }
            //foreach (var item in cars)
            //{
            //    Console.WriteLine($"Marka: {item.Name}>>Model: {item.Brand}>>Od: {item.ProductionYearFrom}--{item.ProductionYearTo}");
            //}
            return cars;
        }
        public List<Engine> GetEnginesByModelId(string modelId,string brandId,string modelName)
        {
            //RestClient client = new RestClient("https://e-katalog.intercars.com.pl/u/tecdoc/u_tecdoc_result.php");
            //RestRequest request = new RestRequest();
            //request.AddParameter("call", "typ");
            //request.AddParameter("model", modelId);
            //request.AddParameter("wsk", "O");
            var engineDataTypes = new List<string>
            {
                                   "tDatOd","tDatDo","tPoj","tKon","tKil","tRod"
            };

            //var response = client.Execute(request);
            //var EnginesSplited = response.Content.Split("<li >");
            string markaFilePath = @"C:\Custom\silniki.txt";
            var markaFile = File.ReadAllText(markaFilePath);
            var markaSplited = markaFile.Split("<li");
            var modelsSplited = markaSplited;
            string id = string.Empty;
            string engineName = string.Empty;
            string engineCode = string.Empty;
            string dateFrom = string.Empty;
            string dateTo = string.Empty;
            string engineCapacity = string.Empty;
            string engineHP = string.Empty;
            string engineKW = string.Empty;
            string carBody = string.Empty;
            List<Engine> engines = new List<Engine>();

            foreach (var model in modelsSplited)
            {
                var ind = model.IndexOf("<a class=\"ajax");
                var vm = model.IndexOf("vmiddle");
                if (model.IndexOf("<a class=\"ajax") > -1 && model.IndexOf("<small") > -1)
                {
                    var idIndex = model.IndexOf("kat(") + 4;
                    var idSubstring = model.Substring(idIndex);
                    var endIndex = idSubstring.IndexOf(");\"");
                    id = idSubstring.Substring(0, endIndex);

                    var engineNameIndex = idSubstring.IndexOf(";\">") + 3;
                    var engineNameSubstring = idSubstring.Substring(engineNameIndex);
                    var endEngineNameIndex = engineNameSubstring.IndexOf("</");
                    engineName = engineNameSubstring.Substring(0, endEngineNameIndex);
                    var engineCodeIndex = engineNameSubstring.IndexOf(";\">") + 3;
                    var engineCodeSubstring = engineNameSubstring.Substring(engineCodeIndex);
                    var endEngineCodeIndex = engineCodeSubstring.IndexOf("</");
                    engineCode = engineCodeSubstring.Substring(0, endEngineCodeIndex).Replace("Kod silnika: ","");
                }
                if (model.IndexOf("\"center\">") > -1)
                {

                    if (model.IndexOf("tDatOd") > -1)
                    {
                        dateFrom = getValue(model);
                    }
                    if (model.IndexOf("tDatDo") > -1)
                    {
                        dateTo = getValue(model);
                    }
                    if (model.IndexOf("tPoj") > -1)
                    {
                        engineCapacity = getValue(model);

                    }
                    if (model.IndexOf("tKon") > -1)
                    {
                        engineHP = getValue(model);

                    }
                    if (model.IndexOf("tKil") > -1)
                    {
                        engineKW = getValue(model);

                    }
                    if (model.IndexOf("tRod") > -1)
                    {
                        carBody = getValue(model);


                        engines.Add(new Engine
                        {
                            ModelName = modelName,
                            BrandId = brandId,
                            ModelId = modelId,
                            Id = id,
                            Name = engineName,
                            Code = engineCode,
                            DateFrom = dateFrom,
                            DatoTo = dateTo,
                            Capacity = engineCapacity,
                            HorsePower = engineHP,
                            KWPower = engineKW,
                            BodyType = carBody
                        });
                        id = string.Empty; 
                        engineName= string.Empty;
                        engineCode= string.Empty;
                        dateFrom= string.Empty; 
                        dateTo= string.Empty;
                        engineCapacity= string.Empty;
                        engineHP= string.Empty;
                        engineKW= string.Empty;
                        carBody = string.Empty;
                    }
                }
            }
            return engines;
        }
        private string getValue(string line)
        {
            var valueIndex = line.IndexOf("\"center\">") + 9;
            var valueSubstring = line.Substring(valueIndex);
            var endValueIndex = valueSubstring.IndexOf("</");
            var value  = valueSubstring.Substring(0,endValueIndex);
            return value;
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
                    engines.Add(new Engine { Name = modelName, Id = id, EngineDetail = detail });
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

            for (int i = 0; i < engineDetails.Length; i++)
            {
                if (engineDetails[i].Contains(productionFrom))
                {
                    var arrowStartIndex = engineDetails[i + 1].IndexOf(">");
                    var arrowEndIndex = engineDetails[i + 1].IndexOf("<");
                    engineDetail.ProductionFrom = engineDetails[i + 1].Substring(arrowStartIndex + 1, arrowEndIndex - arrowStartIndex - 1);
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
