using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop.Filters
{
    /// <summary>
    /// Этот класс содержит описание одного параметра фильтра: как он называется, в каких пределах изменяется, и т.д.
    /// Эта информация необходима для настройки графического интерфейса.
    /// </summary>
    public class ParameterInfo : Attribute
    {
        public string Name;
        public double DefaultValue;
        public double MinValue = 0;
        public double MaxValue = 10;
        public double Increment;
    }
}
