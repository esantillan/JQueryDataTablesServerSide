using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JQueryDataTablesServerSide
{
    public class ColumnOrder
    {
        public int Column { get; set; }
        public String Dir { get; set; }

        public ColumnOrder()
        {

        }
        public ColumnOrder(int Column
                            , String Dir):this()
        {
            this.Column = Column;
            this.Dir = Dir;
        }
    }
}
