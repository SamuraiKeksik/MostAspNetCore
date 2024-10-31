using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostLib.Enums
{
    public enum TrailerAxesType : int
    {
        [Display(Name = "Одноосный")]
        OneAxle = 0,    //Одноосный прицеп

        [Display(Name = "Двухосный")]
        TwoAxle,        //Двухосный прицеп

        [Display(Name = "Трехосный")]
        ThreeAxle,      //Трехосный прицеп

        [Display(Name = "Четырехосный")]
        FourAxle,       //Четырехосный прицеп

        [Display(Name = "Пятиосный")]
        FiveAxle,       //Пятиосный прицеп

        [Display(Name = "Шестиосный")]
        SixAxle,        //Шестиосный прицеп
    }
}
