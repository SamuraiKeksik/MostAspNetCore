using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostLib.Enums
{
    public enum DriverLicenseCategory : int
    {
        A = 0,    //Мотоциклы
        A1,   //Легкие мотоциклы
        B,    //Легковые автомобили, небольшие грузовики (до 3,5 тонн)
        BE,   //Легковые автомобили с прицепом
        B1,   //Трициклы
        C,    //Грузовые автомобили (от 3,5 тонн)
        CE,   //Грузовые автомобили с прицепом
        C1,   //Средние грузовики (от 3,5 до 7,5 тонн)
        C1E,  //Средние грузовики с прицепом
        D,    //Автобусы
        DE,   //Автобусы с прицепом
        D1,   //Небольшие автобусы
        D1E,  //Небольшие автобусы с прицепом
        M,    //Мопеды
        Tm,   //Трамваи
        Tb,   //Троллейбусы
    }
}
