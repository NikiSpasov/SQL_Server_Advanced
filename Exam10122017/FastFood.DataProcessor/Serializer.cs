﻿using System;
using System.IO;
using FastFood.Data;

namespace FastFood.DataProcessor
{
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using FastFood.DataProcessor.Dto.Export;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportOrdersByEmployee(FastFoodDbContext context, string employeeName, string orderType)
        {
            var type = Enum.Parse<Models.Enums.OrderType>(orderType);

            var employee = context
                .Employees
                .Where(o => o.Name == employeeName)
                .Select(e => new
                {
                    e.Name,
                    Orders = e.Orders.Where(o => o.Type == type).Select(o => new
                    {
                        o.Customer,
                        Items = o.OrderItems.Select(oi => new
                        {
                            oi.Item.Name,
                            oi.Item.Price,
                            oi.Quantity
                        }).ToArray(),
                        TotalPrice = o.OrderItems.Sum(oi => oi.Item.Price * oi.Quantity)
                    })

                .OrderByDescending(o => o.TotalPrice)
                .ThenByDescending(o => o.Items.Length)
                .ToArray(),
             TotalMade = e.Orders
                .Where(o => o.Type == type)
                .Sum(o => o.OrderItems.Sum(oi => oi.Item.Price * oi.Quantity))
         })
         .SingleOrDefault();

            var json = JsonConvert.SerializeObject(employee, Formatting.Indented);

            return json;
        }

        public static string ExportCategoryStatistics(FastFoodDbContext context, string categoriesString)
        {
            var categories = categoriesString.Split(',');

            var categoryStatistics = context.Items
                .Where(i => categories.Any(c => c == i.Category.Name))
                .GroupBy(i => i.Category.Name)
                .Select(g => new CategoryDto
                {
                    Name = g.Key,
                    MostPopularItem = g.Select(i => new ItemDto
                        {
                            Name = i.Name,
                            TotalMade = i.OrderItems.Sum(oi => oi.Quantity * oi.Item.Price),
                            TimesSold = i.OrderItems.Sum(oi => oi.Quantity)
                        })
                        .OrderByDescending(i => i.TotalMade)
                        .ThenByDescending(i => i.TimesSold)
                        .First()
                })
                .OrderByDescending(dto => dto.MostPopularItem.TotalMade)
                .ThenByDescending(dto => dto.MostPopularItem.TimesSold)
                .ToArray();

            var serializer = new XmlSerializer(typeof(Dto.Export.CategoryDto[]), new XmlRootAttribute("Categories"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[] { new XmlQualifiedName("", "") });
            serializer.Serialize(new StringWriter(sb), categoryStatistics, namespaces);

            var result = sb.ToString();

            return result;
        }
    }
}