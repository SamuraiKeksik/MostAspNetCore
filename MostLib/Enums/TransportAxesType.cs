using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostLib.Enums
{
    public enum TransportAxesType : int
    {
        [Display(Name = "Двухосный")]
        TwoAxle = 0,    //Двухосный транспорт

        [Display(Name = "Трехосный")]
        ThreeAxle,      //Трехосный транспорт

        [Display(Name = "Четырехосный")]
        FourAxle,       //Четырехосный транспорт

        [Display(Name = "Пятиосный")]
        FiveAxle,       //Пятиосный транспорт

        [Display(Name = "Шестиосный")]
        SixAxle,        //Шестиосный транспорт
    }
}
