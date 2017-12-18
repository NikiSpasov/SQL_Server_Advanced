
namespace FastFood.DataProcessor
{
    using System;
    using FastFood.Data;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using FastFood.DataProcessor.Dto.Import;
    using FastFood.Models;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public static class Deserializer
    {
        private const string FailureMessage = "Invalid data format.";
        private const string SuccessMessage = "Record {0} successfully imported.";

        public static string ImportEmployees(FastFoodDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var deserializedEmployees = JsonConvert.DeserializeObject<EmployeeDto[]>(jsonString);

            var validEmployees = new List<Employee>();

            var validPossitions = new List<Position>();

            Position position = null;

            foreach (var employeeDto in deserializedEmployees)
            {
                if (!IsValid(employeeDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                if (validPossitions.All(p => p.Name != employeeDto.Position))
                {
                    position = new Position()
                    {
                        Name = employeeDto.Position
                    };
                    validPossitions.Add(position);
                }

                position = validPossitions.SingleOrDefault(p => p.Name == employeeDto.Position);

                var validEmployee = new Employee
                {
                    Name = employeeDto.Name,
                    Age = employeeDto.Age,
                    Position = position
                }; //Mapper.Map<Employee>(employeeDto);

                validEmployees.Add(validEmployee);
                sb.AppendLine(string.Format(SuccessMessage, employeeDto.Name));
            }

            context.Employees.AddRange(validEmployees);
            context.SaveChanges();

            var result = sb.ToString();
            return result;
        }

        public static string ImportItems(FastFoodDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var deserializedItems = JsonConvert.DeserializeObject<ItemDto[]>(jsonString);

            var validItems = new List<Item>();

            var validCategories = new List<Category>();

            Category category = null;


            foreach (var itemDto in deserializedItems)
            {
                if (!IsValid(itemDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                if (validCategories.All(c => c.Name != itemDto.Category))
                {
                    category = new Category
                    {
                        Name = itemDto.Category
                    };
                    validCategories.Add(category);
                }
                else
                {
                    category = validCategories.SingleOrDefault(c => c.Name == itemDto.Category);
                }

                if (validItems.Any(i => i.Name == itemDto.Name))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                

                var validItem = new Item
                    {
                        Name = itemDto.Name,
                        Category = category,
                        Price = itemDto.Price
                    };

                validItems.Add(validItem);

                sb.AppendLine(string.Format(SuccessMessage, validItem.Name));           
            }

            context.Categories.AddRange(validCategories);

            context.Items.AddRange(validItems);

            var result = sb.ToString();

            return result;
        }

        public static string ImportOrders(FastFoodDbContext context, string xmlString)
        {
            throw new NotImplementedException();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);

            return isValid;
        }
    }
}