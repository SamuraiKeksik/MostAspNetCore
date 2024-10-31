using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostLib.Enums
{
    public enum TrailerType
    {

        [Display(Name = "Бортовой")]
        OnBoard = 0,    //Бортовой

        [Display(Name = "Закрытый")]
        Closed,         //Закрытый

        [Display(Name = "Рефрижератор")]
        Refrigerator,   //Рефрижератор

        [Display(Name = "Тентованный")]
        Awning,         //Тентованный

        [Display(Name = "Специальный")]
        Special,        //Специальный
    }
}
