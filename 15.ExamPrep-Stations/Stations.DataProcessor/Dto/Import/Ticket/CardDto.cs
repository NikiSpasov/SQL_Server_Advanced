namespace Stations.DataProcessor.Dto.Import.Ticket
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;

    [XmlType("Card")]
    public class CardDto
    {
        [Required]
        [XmlAttribute("Name")]
        public string Name { get; set; }       
    }
}