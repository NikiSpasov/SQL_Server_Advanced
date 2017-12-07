namespace ExternalFormatProcesiingLab
{
    using ExternalFormatProcesiingLab.Data;
    using ExternalFormatProcessingLab.Data.Models;
    using System;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Runtime.Serialization.Json;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using Newtonsoft.Json;

    public class StartUp
    {
        public static void Main()
        {
            using (var context = new ProductsDbContext())
            {
                //XML:


                //CREATE XML Element manually:
                var xmlDoc = new XDocument();

                var books = new XElement("books");

                xmlDoc.Add(books);

                var bookDescription = new XElement("Descritpion", "very good book!");
                var bookTitle = new XElement("Title", "C#, Motha' Fuckkrs'");

                var book = new XElement("book", bookTitle,bookDescription);

                books.Add(book);

                xmlDoc.Save("demoXmlBooks.xml"); //to save it in a file!

                Console.WriteLine(books.Value.ToString());
                //string str =
                //    @"<?xml version=""1.0""?>
                //    <!-- comment at the root level -->
                //     <Root>
                //         <Child>Content</Child>
                //    </Root>";

                //XDocument doc = XDocument.Parse(str); //from string to XDoc

                //var xmlString = File.ReadAllText("someXmlFile.xml");

                //var xml = XDocument.Parse(xmlString);

                //var elements = xml.Root.Elements();

                //var windows = elements.Where(e => e.Element("Name")
                //.Value == "Window")
                //.Select(e => new
                //    {
                //        Name = e.Element("Name")?.Value,
                //        Description = e.Element("Desription")?.Value
                //    })
                //.ToArray();

                //foreach (var e in root)
                //{
                //    var name = e.Element("Name").Value; //case sensitive!

                //    Console.WriteLine(e.Name);

                //    e.SetElementValue("Name", "Niki"); //sets tne new value 
                //}



                //var product = new Product
                //{
                //    Name = "Tyre",
                //    Description = "makes the car go forw/backw",
                //    Manufacturer = new Manufacturer()
                //    {
                //        Name = "Michelin"
                //    }
                //};



                /* Example for working with REST.Api + JSON
                 * 
                 * 
                 * 
                Console.OutputEncoding = Encoding.UTF8;

                string json;
                using (var client = new WebClient())
                {
                    json = client.DownloadString("http://drone.sumc.bg/api/v1/metro/all");
                }

                var stations = JsonConvert.DeserializeObject<StationDto[]>(json);

                foreach (var station in stations)
                {
                    Console.WriteLine(station.Name);
                    Console.WriteLine(station.Code);
                    Console.WriteLine(station.RouteId);
                }

                //REMEMBER: For Cyrilic: 

                */



                //JSON:


                //var databaseInit = new DatabaseInitializer(context);

                //databaseInit.ResetDatabase();

                //var jsonObjDemo = JObject.Parse(@"{'products': [
                //{'name': 'Fruits', 'products': ['apple', 'banana']},
                //{'name': 'Vegetables', 'products': ['cucumber']}]}");

                //var products = jsonObjDemo["products"].Select(t =>
                //    string.Format("{0} ({1})",
                //        t["name"],
                //        string.Join(", ", t["products"])
                //    )).ToArray();

                //foreach (var p in products)
                //{
                //    Console.WriteLine(p);
                //}



                //JObject jsonArrayInside = JObject.Parse("{'Name': 'Pesho', 'Age': 15, 'RandomElements': [15, 2.3, 'Kiro']}");

                //var jObj = JObject.FromObject(product);
                ////you can:
                //jObj.ToString(Formatting.Indented);
                //how to read from a file:
                // var jObjFromFile = JObject.Parse(File.ReadAllText(@"c:\text.txt"));

                //foreach (var kvp in jsonArrayInside)
                //{
                //    var key = kvp.Key;
                //    var value = kvp.Value; //if you want to be only in specifit type:
                //           // = kvp.Value.ToObject<int>(); - ti will throw exept if value is string, etc. 

                //    Console.WriteLine($"The key is: {key} and the value is: {value}");
                //}
                //you can index it like:
                //json["products"].Select(t => t.String.Format("{0} ({1})",
                //t["name"],
                //string.Join(", ", c["products"]));

                //var jsonString = JsonConvert.SerializeObject(product, Formatting.Indented /*or .None*/, new JsonSerializerSettings()
                //{
                //    NullValueHandling = NullValueHandling.Ignore, /*or*/
                //    DefaultValueHandling = DefaultValueHandling.Ignore
                //});

                //var json = JObject.Parse(jsonString);

                //Jtoken is one value from a json object

                //var jsonString = SerializeObject(product); //don't

                //var parsedProduct = DeserializeObject<Product>(jsonString); //don't

                //Console.WriteLine(jsonString);



                //Console.WriteLine(jsonString);

                //var objProduct = JsonConvert.DeserializeObject<Product>(jsonString);
            }

            //how to deserialize anonymousType:

            //var obj = new
            //{
            //    Name = "Pesho",
            //    Age = 20, 
            //    Grades = new []
            //    {
            //        3.2,
            //        5.46,
            //        6.00
            //    }
            //};

            //var serializedObj = JsonConvert.SerializeObject(obj);

            //var template = new
            //{
            //    Name = string.Empty,
            //    Age = 0,
            //    Grades = new decimal[] {}
            //};

            // var deserilizedObj = JsonConvert.DeserializeAnonymousType(serializedObj, template);
        }

        //The right way is with library Json.Net!!!



        //this is stupid way for Serialization(from memory to file) and Deserizlization(from file to memory)
        // with Government/State Class - DataContractJsonDeSerializer

        private static T DeserializeObject<T>(string jsonString)
        {
            var jsonBytes = Encoding.UTF8.GetBytes(jsonString);

            using (var stream = new MemoryStream(jsonBytes))
            {
                var serializer = new DataContractJsonSerializer(typeof(T));
                var obj = (T)serializer.ReadObject(stream);
                return obj;
            }
        }

        //this is stupid way: // DataContractJsonSerializer
        private static string SerializeObject(Product product)
        {
            var jsonSerializer = new DataContractJsonSerializer(product.GetType());

            using (var stream = new MemoryStream())
            {
                jsonSerializer.WriteObject(stream, product);
                var result = Encoding.UTF8.GetString(stream.ToArray());

                return result;
            }
        }
    }
}
