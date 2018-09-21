using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARCengine
{
    public enum FieldTypesEnum { Text, Number, DateTime, YesNo, Lookup };
    public enum FieldAlignmentEnum { Left, Center, Right };
    public enum SqlParamTypesEnum { String, Integer, DateTime, Boolean, Image };
    public enum DatabaseStateEnum { Initializing, Ready, ErrorInConnectionString, ErrorInDBStructure, Opened, Closed}
    public enum RefreshStateEnum { NeedsRefreshing, CurrentlyRefreshing, HasBeenRefreshed}

}
