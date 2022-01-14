using System;
using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Events.EventDTOs
{
    public class VenueDTO
    {
        [Key, MaxLength(5)]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Range(1, Int32.MaxValue)]
        public int Capacity { get; set; }

        [Range(0.0, Double.MaxValue)]
        public double CostPerHour { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public int? EventId { get; set; }
    }
}
