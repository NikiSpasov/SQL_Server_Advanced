namespace ExternalFormatProcesiingLab
{
    using System.Security.Permissions;

    internal class StationDto
    {    /*
        "id": 5,
        "route_id": 1,
        "code": 2985,
        "point_id": 105,
        "name": "Лъвов мост",
        "latitude": 42.705369,
        "longitude": 23.323891
        */
        
        public int RouteId { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }

    }

}