using Microsoft.AspNetCore.Identity;
using MostLib.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MostLib
{
    public class Transport
    {
        [Key]
        public Guid TransportId { get; set; }

        [DisplayName("Марка")]
        [Required(ErrorMessage = "Не указана марка транспорта!")]
        [MaxLength(20)]
        public string Brand { get; set; }

        [DisplayName("Модель")]
        [Required(ErrorMessage = "Не указана модель транспорта!")]
        [MaxLength(20)]
        public string Model { get; set; }

        [DisplayName("Дата производства")]
        public DateTime? ReleaseDate { get; set; } //Дата производства

        [DisplayName("VIN номер")]
        [Required(ErrorMessage = "Не указан VIN номер транспорта!")]
        //[RegularExpression("/\b[(A-H|J-N|P|R-Z|0-9)]{17}\b/gm",
          //  ErrorMessage = "Введен неправильный формат VIN номера!")]
        public string VinNumber { get; set; } // Идентификационный номер транспортного средства

        [DisplayName("Номера транспорта")]
        [Required(ErrorMessage = "Не указаны номера транспорта!")]
       // [RegularExpression("/^[АВЕКМНОРСТУХ]\\d{3}(?<!000)[АВЕКМНОРСТУХ]{2}\\d{2,3}$/ui", 
            //ErrorMessage = "Введен неправильный формат номера!")]
        public string LicensePlateNumber { get; set; }

        [DisplayName("Пробег (КМ)")]
        public double? Mileage { get; set; } //Пробег транспорта

        [DisplayName("Вместимость топливного бака (Л)")]
        public int? MaxFuel { get; set; } //Максимальная вместимость бака в литрах

        [DisplayName("Тип транспорта")]
        [Required(ErrorMessage = "Не указан тип транспорта!")]
        public TransportType TransportTypeId { get; set; }  //Тип транспорта (бортовой, тентованный и т.д.)

        [DisplayName("Возможность прикрепления прицепа")]
        [Required(ErrorMessage = "Не указана возможность прикрепления прицепа!")]
        public bool CanAttachTrailer { get; set; } //Можно ли прикрепить прицеп

        [DisplayName("Максимальаня грузоподъемность")]
        [Required(ErrorMessage = "Не указана грузоподъемность транспорта!")]
        public double MaxWeight { get; set; }

        [DisplayName("Длина")]
        [Required(ErrorMessage = "Не указана длина транспорта!")]
        public double Length { get; set; }

        [DisplayName("Ширина")]
        [Required(ErrorMessage = "Не указана ширина транспорта!")]
        public double Width { get; set; }

        [DisplayName("Высота")]
        [Required(ErrorMessage = "Не указана высота транспорта!")]
        public double Height { get; set; }

        [DisplayName("Тип осей")]
        [Required(ErrorMessage = "Не указан тип осей транспорта!")]
        public TransportAxesType AxesTypeId { get; set; } //Тип осей транспорта

        [DisplayName("Ответственный за тронспорт водитель")]
        [ForeignKey(nameof(ResponsibleDriver))]
        public Guid? ResponsibleDriverId { get; set; }  //Содержит ответственного водителя если такой есть
        public Driver? ResponsibleDriver { get; set; }

        [DisplayName("Текущий маршрут")]
        [ForeignKey(nameof(CurrentRoute))]
        public Guid? CurrentRouteId { get; set; }   //Содержит маршрут в котором в настоящее время используется транспорт
        public Route? CurrentRoute { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public IdentityUser User { get; set; }  //Содержит пользователя, который добавил транспорт
    }
}
