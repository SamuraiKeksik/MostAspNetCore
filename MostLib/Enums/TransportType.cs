using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostLib.Enums
{
    public enum TransportType : int
    {
        OnBoard = 0,      //Бортовой
        LowFrame,         //Низкорамный  
        Platform,         //Платформа
        Awning,           //Тентованый
        AllMetal,         //Цельнометаличесий
        IndustrialGoods,  //Промтоварный
        Isometric,        //Изометрический
        Refrigerator,     //Рефрижератор
        Tank,             //Цистерна
        Construction,     //Строительная
        SpecialEquipment, //Спецтехника
    }
}
