using Microsoft.AspNetCore.Identity;
using MostLib.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MostLib
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }

        [Required(ErrorMessage = "Не указано название товара!")]
        [MinLength(5, ErrorMessage = "Минимальная длина названия товара - 5 символов!")]
        [MaxLength(50, ErrorMessage = "Максимальная длина названия товара - 5 символов!")]
        public string ProductName { get; set; }

        [Required]
        public ProductPackageType ProductPackageTypeId { get; set; } = ProductPackageType.Box; //Тип упаковки товара (по умолчанию коробка)

        [Required]
        public ProductCategory ProductCategoryId { get; set; }  

        public string? Brand { get; set; } //Торговая марка товара

        public string? Description { get; set; } //Описание товара

        [MaxLength(50)]
        public string? ArticleNumber { get; set; } //Артикул      

        [Required]
        public bool IsFragile { get; set; } = false;  //Хрупкий ли товар

        [Required]
        public bool NeedsRefrigerator { get; set; } = false;  //Нуждается ли товар в рефрижераторе

        [Required(ErrorMessage = "Не указана длина товара!")]
        public double Length { get; set; }  //Высота есть у всех продуктов

        public double? Width { get; set; } = 0;   //Указывается если тип товара = коробка

        public double? Height { get; set; } = 0;  //Указывается если тип товара = коробка

        public double? Radius { get; set; } = 0;  //Указывается если тип товара = мешок и рассчитывает ширину и длину

        [ForeignKey("User")]
        public string UserId { get; set; }
        public IdentityUser User { get; set; }  //Содержит пользователя, который добавил продукт

    }
}
