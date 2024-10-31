using Microsoft.AspNetCore.Identity;
using MostLib.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MostLib
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }

        [DisplayName("Название товара")]
        [Required(ErrorMessage = "Не указано название товара!")]
        [MinLength(5, ErrorMessage = "Минимальная длина названия товара - 5 символов!")]
        [MaxLength(50, ErrorMessage = "Максимальная длина названия товара - 5 символов!")]
        public string ProductName { get; set; }

        [DisplayName("Тип упаковки")]
        [Required]
        public ProductPackageType ProductPackageTypeId { get; set; } = ProductPackageType.Box; //Тип упаковки товара (по умолчанию коробка)

        [DisplayName("Категория товара")]
        [Required]
        public ProductCategory ProductCategoryId { get; set; }

        [DisplayName("Торговая марка")]
        public string? Brand { get; set; } //Торговая марка товара

        [DisplayName("Описание")]
        public string? Description { get; set; } //Описание товара

        [DisplayName("Артикул")]
        [MaxLength(50)]
        public string? ArticleNumber { get; set; } //Артикул      

        [DisplayName("Хрупкий")]
        [Required]
        public bool IsFragile { get; set; } = false;  //Хрупкий ли товар

        [DisplayName("Необходим рефрижератор")]
        [Required]
        public bool NeedsRefrigerator { get; set; } = false;  //Нуждается ли товар в рефрижераторе

        [DisplayName("Длина")]
        [Required(ErrorMessage = "Не указана длина товара!")]
        public double Length { get; set; }  //Высота есть у всех продуктов

        [DisplayName("Ширина")]
        public double? Width { get; set; } = 0;   //Указывается если тип товара = коробка

        [DisplayName("Высота")]
        public double? Height { get; set; } = 0;  //Указывается если тип товара = коробка

        [DisplayName("Радиус")]
        public double? Radius { get; set; } = 0;  //Указывается если тип товара = мешок и рассчитывает ширину и длину

        [ForeignKey("User")]
        public string UserId { get; set; }
        public IdentityUser User { get; set; }  //Содержит пользователя, который добавил продукт

    }
}
