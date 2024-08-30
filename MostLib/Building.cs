using Microsoft.AspNetCore.Identity;
using MostLib.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostLib
{
    public class Building
    {
        [Key]
        public Guid BuildingId { get; set; }

        [Required(ErrorMessage = "Не указан адрес здания!")]
        [MaxLength(100, ErrorMessage = "Максимальная длина адреса - 100!")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Не указаны координаты здания!")]
        public string Coordinates { get; set; }

        [Required(ErrorMessage = "Не указано название здания!")]
        [MaxLength(100, ErrorMessage = "Максимальная длина названия - 100!")]
        public string BuildingName { get; set; }   //Название здания, например - Магазин "Магнит"

        [Required(ErrorMessage = "Не указан тип здания!")]
        public BuildingType BuildingTypeId { get; set; }

        [MaxLength(500, ErrorMessage = "Максимальная длина комментария - 500!")]
        public string? Comment { get; set; }   //Комментарий к строению, например - с какой стороны подъежать

        [Required]
        public IdentityUser User { get; set; }  //Содержит пользователя, который добавил здание

    }
}
