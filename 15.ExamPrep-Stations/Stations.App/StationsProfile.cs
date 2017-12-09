using System.Linq;
using AutoMapper;

namespace Stations.App
{
    using Stations.DataProcessor.Dto.Import;
    using Stations.Models;

    public class StationsProfile : Profile
	{
		// Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
		public StationsProfile()
		{
		    this.CreateMap<StationDto, Station>();
		    this.CreateMap<SeatingClassDto, SeatingClass>();
		    this.CreateMap<TrainDto, Train>();
		}
	}
}
