using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JQueryDataTablesServerSide
{
    public class Column
    {
        public String Data { get; set; }
        public String Name { get; set; }
        public bool Orderable { get; set; }
        public bool Searchable { get; set; }
        public SearchFilter Search { get; set; }//@SEE probar si funciona aunque las columnas no tengan filtros individuales
        
        public Column()
        {

        }

        public Column(  String Data
                        , String Name
                        , bool Orderable
                        , bool Searchable
                        ,SearchFilter Search):this()
        {
            this.Data = Data;
            this.Name = Name;
            this.Orderable = Orderable;
            this.Searchable = Searchable;
            this.Search = Search;
        }
    }
}
