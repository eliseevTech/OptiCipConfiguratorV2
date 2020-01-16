using EntityAccessOnFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCipAdministratorHelper2.View.OptiCipConfig.Main.Models
{
    public class LineTagFacade
    {
        public LineTag LineTag { get; set; }
        public Tag Tag { get; set; }

        /// <summary>
        /// Отдаем цвет в хексе
        /// </summary>
        public string HexColor { get { return ToHex(LineTag.Color); }  set { LineTag.Color = ToDec(value); }  }

        /// <summary>
        /// Функция для перевода из строки в хеш цвета
        /// 
        /// </summary>
        /// <param name="_Color">число в 10ичной системе но не более ffffff в 16ричной</param>
        /// <returns></returns>
        public string ToHex(int _Color)
        {
            //прибавляем число в  деситичной 16777216 в (16ичной 1 00 00 00)
            //что бы появились нули
            _Color += 16777216; //
            //переводим из 10ичной в 16ричную
            string HexTagColor = "#" + (_Color).ToString("X");
            //удаляем символ на позиции 1, то число которое мы прибавили в начале
            HexTagColor = HexTagColor.Remove(1, 1);
            //определяем цвета
            string HexTempColor1 = HexTagColor.Substring(1, 2);
            string HexTempColor2 = HexTagColor.Substring(3, 2);
            string HexTempColor3 = HexTagColor.Substring(5, 2);
            //переварачиваем Red и Blue
            HexTagColor = "#" + HexTempColor3 + HexTempColor2 + HexTempColor1;
            return HexTagColor;
        }

        /// <summary>
        /// перевод Hex В Dec с заменой R и B
        /// </summary>
        /// <param name="_Color">строка в формате #AABBCC</param>
        /// <returns></returns>
        public int ToDec(string _Color)
        {
            ///Если цвет меньше 6 символов, делаем белый.
            if (_Color.Length < 7)
            {
                _Color = "#FFFFFF";
            }
            //находим R G B
            string HexTempColor1 = _Color.Substring(1, 2);
            string HexTempColor2 = _Color.Substring(3, 2);
            string HexTempColor3 = _Color.Substring(5, 2);
            //ДЕлаем конкатенацию с R И G наоборот
            string HexTagColor = HexTempColor3 + HexTempColor2 + HexTempColor1;
            //возвращаем десячитное число
            return int.Parse(HexTagColor, System.Globalization.NumberStyles.HexNumber);
        }
        ///задать все нужные поля а потом передавть в модель для таблички
    }
}
