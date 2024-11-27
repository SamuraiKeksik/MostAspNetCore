using Microsoft.AspNetCore.Identity;
using MostLib.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [DisplayName("Адрес")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Не указаны координаты здания!")]
        [DisplayName("Координаты")]
        public string Coordinates { get; set; }

        [Required(ErrorMessage = "Не указано название здания!")]
        [MaxLength(100, ErrorMessage = "Максимальная длина названия - 100!")]
        [DisplayName("Название здания")]
        public string BuildingName { get; set; }   //Название здания, например - Магазин "Магнит"

        [Required(ErrorMessage = "Не указан тип здания!")]
        [DisplayName("Тип здания")]
        public BuildingType BuildingTypeId { get; set; }

        [MaxLength(500, ErrorMessage = "Максимальная длина комментария - 500!")]
        [DisplayName("Примечание")]
        public string? Comment { get; set; }   //Примечание к строению, например - с какой стороны подъежать

        [Required]
        public IdentityUser User { get; set; }  //Содержит пользователя, который добавил здание

        [NotMapped]
        public string BuildingDescription { get { return $"{BuildingName} - {Address} - {Coordinates}"; } } //Свойство для возврата Имени с Адресом и Координатами в SelectItem
    }
}
