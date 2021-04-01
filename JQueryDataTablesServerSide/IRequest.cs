using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JQueryDataTablesServerSide
{
    public interface IRequest
    {
        Dictionary<String, String> ToDictionary();
    }
}
