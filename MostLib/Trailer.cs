using Microsoft.AspNetCore.Identity;
using MostLib.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MostLib
{
    public class Trailer
    {
        [Key]
        public Guid TrailerId { get; set; }

        [Required(ErrorMessage = "Не указана марка прицепа!")]
        [MaxLength(20)]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Не указана модель прицепа!")]
        [MaxLength(20)]
        public string Model { get; set; }

        public DateTime? ReleaseDate { get; set; } //Дата производства

        [Required(ErrorMessage = "Не указан VIN номер прицепа!")]
        [RegularExpression("/\b[(A-H|J-N|P|R-Z|0-9)]{17}\b/gm",
            ErrorMessage = "Введен неправильный формат VIN номера!")]
        public string VinNumber { get; set; } // Идентификационный номер прицепа

        [Required(ErrorMessage = "Не указаны номера прицепа!")]
        [RegularExpression("/^[АВЕКМНОРСТУХ]\\d{3}(?<!000)[АВЕКМНОРСТУХ]{2}\\d{2,3}$/ui",
            ErrorMessage = "Введен неправильный формат номера!")]
        public string LicensePlateNumber { get; set; }

        [Required(ErrorMessage = "Не указан тип прицепа!")]
        public TrailerType TrailerTypeId { get; set; }   //Тип прицепа (открытый, закрытый, рефрижератор и т.д.

        [Required(ErrorMessage = "Не указана грузоподъемность прицепа!")]
        public double MaxWeight { get; set; }

        [Required(ErrorMessage = "Не указана ширина прицепа!")]
        public double Length { get; set; }

        [Required(ErrorMessage = "Не указана ширина прицепа!")]
        public double Width { get; set; }

        [Required(ErrorMessage = "Не указана высота прицепа!")]
        public double Height { get; set; }

        [Required(ErrorMessage = "Не указан тип осей прицепа!")]
        public TrailerAxesType TrailerAxesTypeId { get; set; }  //Тип осей прицепа   

        [ForeignKey(nameof(ResponsibleDriver))]
        public Guid? ResponsibleDriverId { get; set; }
        public Driver? ResponsibleDriver { get; set; }  //Содержит ответственного водителя если такой есть

        [ForeignKey(nameof(CurrentRoute))]
        public Guid? CurrentRouteId { get; set; }   //Содержит маршрут в котором в настоящее время используется транспорт
        public Route? CurrentRoute { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public IdentityUser User { get; set; }  //Содержит пользователя, который добавил прицеп
    }
}
