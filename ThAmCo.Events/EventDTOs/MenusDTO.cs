using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
