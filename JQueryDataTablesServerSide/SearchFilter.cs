using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JQueryDataTablesServerSide
{
    public class SearchFilter
    {
        public bool Regex { get; set; }
        public String Value { get; set; }

        public SearchFilter()
        {

        }
        public SearchFilter(  bool Regex
                            , String Value):this()
        {
            this.Regex = Regex;
            this.Value = Value;
        }
    }
}
