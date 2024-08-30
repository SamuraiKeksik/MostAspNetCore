using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostLib
{
    public class Penalty
    {
        [Key]
        public Guid PenaltyId { get; set; }

        [Required]
        public DateTime PenaltyDate { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(1000, ErrorMessage = "Максимальная длина описания - 1000 символов!")]
        public string Description { get; set; }

        [Required]
        [ForeignKey(nameof(Driver))]
        public Guid DriverId { get; set; }
        public Driver Driver { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public IdentityUser User { get; set; }  //Содержит пользователя, который добавил штраф

        /*[Required]
        public Route RouteId { get; set; }*/


    }
}
