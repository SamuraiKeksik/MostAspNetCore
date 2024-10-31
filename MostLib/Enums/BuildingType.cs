using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostLib.Enums
{
    public enum BuildingType : int
    {
        [Display(Name = "Магазин")]
        Store = 0,    //Магазин

        [Display(Name = "Склад")]
        Warehouse,    //Склад
    }
}
