using Microsoft.AspNetCore.Identity;
using MostLib.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MostLib
{
    public class Trailer
    {
        [Key]
        public Guid TrailerId { get; set; }

        [DisplayName("Марка")]
        [Required(ErrorMessage = "Не указана марка прицепа!")]
        [MaxLength(20)]
        public string Brand { get; set; }

        [DisplayName("Модель")]
        [Required(ErrorMessage = "Не указана модель прицепа!")]
        [MaxLength(20)]
        public string Model { get; set; }

        [DisplayName("Дата производства")]
        public DateTime? ReleaseDate { get; set; } //Дата производства

        [DisplayName("VIN номер")]
        [Required(ErrorMessage = "Не указан VIN номер прицепа!")]
        //[RegularExpression("/\b[(A-H|J-N|P|R-Z|0-9)]{17}\b/gm",
          //  ErrorMessage = "Введен неправильный формат VIN номера!")]
        public string VinNumber { get; set; } // Идентификационный номер прицепа

        [DisplayName("Номера прицепа")]
        [Required(ErrorMessage = "Не указаны номера прицепа!")]
        //[RegularExpression("/^[АВЕКМНОРСТУХ]\\d{3}(?<!000)[АВЕКМНОРСТУХ]{2}\\d{2,3}$/ui",
          //  ErrorMessage = "Введен неправильный формат номера!")]
        public string LicensePlateNumber { get; set; }

        [DisplayName("Тип прицепа")]
        [Required(ErrorMessage = "Не указан тип прицепа!")]
        public TrailerType TrailerTypeId { get; set; }   //Тип прицепа (открытый, закрытый, рефрижератор и т.д.

        [DisplayName("Максимальная грузоподъемность")]
        [Required(ErrorMessage = "Не указана грузоподъемность прицепа!")]
        public double MaxWeight { get; set; }

        [DisplayName("Длина")]
        [Required(ErrorMessage = "Не указана длина прицепа!")]
        public double Length { get; set; }

        [DisplayName("Ширина")]
        [Required(ErrorMessage = "Не указана ширина прицепа!")]
        public double Width { get; set; }

        [DisplayName("Высота")]
        [Required(ErrorMessage = "Не указана высота прицепа!")]
        public double Height { get; set; }

        [DisplayName("Тип осей прицепа")]
        [Required(ErrorMessage = "Не указан тип осей прицепа!")]
        public TrailerAxesType TrailerAxesTypeId { get; set; }  //Тип осей прицепа   

        [DisplayName("Ответственный водитель")]
        [ForeignKey(nameof(ResponsibleDriver))]
        public Guid? ResponsibleDriverId { get; set; }
        public Driver? ResponsibleDriver { get; set; }  //Содержит ответственного водителя если такой есть

        [DisplayName("Текущий маршрут")]
        [ForeignKey(nameof(CurrentRoute))]
        public Guid? CurrentRouteId { get; set; }   //Содержит маршрут в котором в настоящее время используется транспорт
        public Route? CurrentRoute { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public IdentityUser User { get; set; }  //Содержит пользователя, который добавил прицеп
    }
}
