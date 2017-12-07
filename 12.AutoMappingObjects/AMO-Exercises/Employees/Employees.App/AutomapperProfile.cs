namespace Employees.App
{
    using AutoMapper;

    using Employees.DtoModels;
    using Employees.Models;

    public class AutomapperProfile : Profile //from AutoMapper
    {
        public AutomapperProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();
            this.CreateMap<ManagerDto, Employee>();
            this.CreateMap<Employee, ManagerDto>();

            this.CreateMap<Employee, EmployeePersonalDto>();
        }
    }
}
