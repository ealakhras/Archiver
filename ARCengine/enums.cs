using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARCengine
{
    public enum FieldTypes { Text, Number, DateTime, YesNo, Lookup };
    public enum FieldAlignment { Left, Center, Right };
    public enum SqlParamTypes { String, Integer, DateTime, Boolean, Image };
}
