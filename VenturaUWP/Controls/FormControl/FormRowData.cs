using System;
using System.Collections.Generic;

namespace Ventura.Controls
{
    internal class FormRowData
    {
        public bool IsLastRow = false;

        public List<FormFieldData> Fields { get; } = new List<FormFieldData>();

        public Double TotalRowHeight;
        public Double TotalRowWidth;
        //public Double OffsetY;

        //public int FieldSeparatorLineCount = 0;

        public int xFillerCount = 0;
        //public int FlexFieldCount = 0;



    }
}
