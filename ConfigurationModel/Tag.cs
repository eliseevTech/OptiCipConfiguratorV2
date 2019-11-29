using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationModel
{
    public class Tag
    {
        public class _TagName
        {
            public string Value { get; set; }
            public string Name { get; } = "Tag Name";
        }
        public _TagName TagName = new _TagName();

        public class _Address
        {
            public string Value { get; set; }
            public string Name { get; } = "Address";
        }
        public _Address Address = new _Address();

        public class _DataType
        {
            public string Value { get; set; }
            public string Name { get; } = "Data Type";
        }
        public _DataType DataType = new _DataType();

        public class _RespectDataType
        {
            public string Value { get; set; }
            public string Name { get; } = "Respect Data Type";
        }
        public _RespectDataType RespectDataType = new _RespectDataType();

        public class _ClientAccess
        {
            public string Value { get; set; }
            public string Name { get; } = "Client Access";
        }
        public _ClientAccess ClientAccess = new _ClientAccess();
        
        public class _ScanRate
        {
            public string Value { get; set; }
            public string Name { get; } = "Scan Rate";
        }
        public _ScanRate ScanRate = new _ScanRate();

        public class _Scaling
        {
            public string Value { get; set; }
            public string Name { get; } = "Scaling";
        }
        public _Scaling Scaling = new _Scaling();

        public class _RawLow
        {
            public string Value { get; set; }
            public string Name { get; } = "Raw Low";
        }
        public _RawLow RawLow = new _RawLow();

        public class _RawHigh
        {
            public string Value { get; set; }
            public string Name { get; } = "Raw High";
        }
        public _RawHigh RawHigh = new _RawHigh();

        public class _ScaledLow
        {
            public string Value { get; set; }
            public string Name { get; } = "Scaled Low";
        }
        public _ScaledLow ScaledLow = new _ScaledLow();

        public class _ScaledHigh
        {
            public string Value { get; set; }
            public string Name { get; } = "Scaled High";
        }
        public _ScaledHigh ScaledHigh = new _ScaledHigh();

        public class _ScaledDataType
        {
            public string Value { get; set; }
            public string Name { get; } = "Scaled Data Type";
        }
        public _ScaledDataType ScaledDataType = new _ScaledDataType();

        public class _ClampLow
        {
            public string Value { get; set; }
            public string Name { get; } = "Clamp Low";
        }
        public _ClampLow ClampLow = new _ClampLow();

        public class _ClampHigh
        {
            public string Value { get; set; }
            public string Name { get; } = "Clamp High";
        }
        public _ClampHigh ClampHigh = new _ClampHigh();

        public class _EngUnits
        {
            public string Value { get; set; }
            public string Name { get; } = "Eng Units";
        }
        public _EngUnits EngUnits = new _EngUnits();

        public class _Description
        {
            public string Value { get; set; }
            public string Name { get; } = "Description";
        }
        public _Description Description = new _Description();

        public class _NegateValue
        {
            public string Value { get; set; }
            public string Name { get; } = "Negate Value";
        }
        public _NegateValue NegateValue = new _NegateValue(); 

    }
}
