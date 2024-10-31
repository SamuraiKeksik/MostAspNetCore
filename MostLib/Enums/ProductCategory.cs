using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostLib.Enums
{
    public enum ProductCategory : int
    {
        [Display(Name = "Продукты питания")]
        Food = 0,           //Продукты питания

        [Display(Name = "Одежда")]
        Clothes,            //Одежда

        [Display(Name = "Техника")]
        Technic,            //Техника

        [Display(Name = "Товары для детей")]
        ChildrenProducts,   //Товары для детей

        [Display(Name = "Товары для дома")]
        Household,          //Товары для дома

        [Display(Name = "Товары для спорта")]
        Sporting,           //Товары для спорта

        [Display(Name = "Товары для животных")]
        PetProducts,        //Товары для животных

        [Display(Name = "Товары для строительства")]
        Construction,       //Товары для строительства

        [Display(Name = "Книги")]
        Books,              //Книги

        [Display(Name = "Другое")]
        Other,              //Другое
    }
}
