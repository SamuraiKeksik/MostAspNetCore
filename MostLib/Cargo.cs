using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostLib
{
    public class Cargo
    {
        public List<Product> ProductsList { get; set; }  //Список товаров в грузе
        public Building DestinationBuilding { get; set; }  //Точка назначения груза
    }
}
