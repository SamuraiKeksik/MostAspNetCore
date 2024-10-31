using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostLib.Enums
{
    public enum ProductPackageType : int
    {
        [Display(Name = "Коробка")]
        Box = 0,   //Коробка (например коробка упаковок с сахаром)

        [Display(Name = "Мешок")]
        Sack,  //Мешок (например мешок риса)

        
    }
}
