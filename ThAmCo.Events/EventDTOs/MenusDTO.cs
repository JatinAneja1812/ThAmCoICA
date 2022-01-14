using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Events.EventDTOs
{
    public class MenusDTO
    {

        [Key]
        [DisplayFormat(NullDisplayText = "N/A")]
        public int MenuId { get; set; }
        [DisplayFormat(NullDisplayText = "N/A")]
        [Required]
        public string MenuName { get; set; }
    }
}
