using AutoMapper;

namespace FastFood.App
{
    using FastFood.DataProcessor.Dto.Import;
    using FastFood.Models;

    public class FastFoodProfile : Profile
	{
		// Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
		public FastFoodProfile()
		{
		    this.CreateMap <EmployeeDto, Employee>();
		    this.CreateMap<Employee, EmployeeDto>();
		    this.CreateMap<ItemDto, Item>();

		}
	}
}
