using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostLib.Enums
{
    public enum TransportType : int
    {
        [Display(Name = "Бортовой")]
        OnBoard = 0,      //Бортовой

        [Display(Name = "Низкорамный")]
        LowFrame,         //Низкорамный  

        [Display(Name = "Платформа")]
        Platform,         //Платформа

        [Display(Name = "Тентованый")]
        Awning,           //Тентованый

        [Display(Name = "Цельнометаличесий")]
        AllMetal,         //Цельнометаличесий

        [Display(Name = "Промтоварный")]
        IndustrialGoods,  //Промтоварный

        [Display(Name = "Изометрический")]
        Isometric,        //Изометрический

        [Display(Name = "Рефрижератор")]
        Refrigerator,     //Рефрижератор

        [Display(Name = "Цистерна")]
        Tank,             //Цистерна

        [Display(Name = "Строительная")]
        Construction,     //Строительная

        [Display(Name = "Спецтехника")]
        SpecialEquipment, //Спецтехника
    }
}
