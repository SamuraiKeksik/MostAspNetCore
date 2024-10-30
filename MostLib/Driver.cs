using Microsoft.AspNetCore.Identity;
using MostLib.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MostLib
{
    public class Driver
    {
        [Key]
        public Guid DriverId { get; set; }

        [Required(ErrorMessage = "Не указано ФИО водителя!")]
        [MaxLength(100, ErrorMessage = "Максимальная длина ФИО - 100 символов!")]
        [DisplayName("ФИО")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Не указана дата рождения водителя!")]
        [DisplayName("Дата рождения")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Не указан номер телефона водителя!")]
        //[RegularExpression("/(?:\\+|\\d)[\\d\\-\\(\\) ]{9,}\\d/g")]
        [DisplayName("Номер телефона")]
        public string PhoneNumber { get; set; }

        [DisplayName("Электронная почта")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Не указан номер водительского удостоверения!")]
        //[RegularExpression("\"^[A-Z]{2}[0-9]{2}[A-Z]{2}[0-9]{4}$\"")]
        [DisplayName("Номер водительского удостоверения")]
        public string DriverLicenseNumber { get; set; }

        [Required(ErrorMessage = "Не указана дата истечения водительского удостоверения!")]
        [DisplayName("Дата истечения водительского удостоверения")]
        public DateTime DriverLicenseExpirationDate { get; set; }

        /*[Required(ErrorMessage = "Не указана категория водительского удостоверения!")]
        [DisplayName("Категория водительского удостоверения")]
        public List<DriverLicenseCategory> DriverLicenseCategory { get; set; }*/

        [DisplayName("Фото")]
        public byte[]? Photo { get; set; }

        [DisplayName("Штрафы")]
        public List<Penalty> Penalties { get; set; } = new List<Penalty> { };

        [ForeignKey(nameof(CurrentRoute))]
        [DisplayName("Дата рождения")]
        public Guid? CurrentRouteId { get; set; }   //Содержит маршрут в котором в настоящее время используется транспорт
        public Route? CurrentRoute { get; set; }

        [Required]
        public IdentityUser User { get; set; }  //Содержит пользователя, который добавил водителя

    }
}
