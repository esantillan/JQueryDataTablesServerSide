using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JQueryDataTablesServerSide
{
    public class JQueryDataTablesResponse <T>
    {
        public int Draw { get; set; }
        public int RecordsTotal { get; set; }
        public int RecordsFiltered { get; set; }
        public int? Start { get; set; }
        public int Length { get; set; }
        public List<T> Data { get; set; }
        //public String Error { get; set; }
        public JQueryDataTablesResponse()
        {
         //Error = "Error de Prueba";   
        }

        public JQueryDataTablesResponse(int Draw
                                        , int RecordsTotal
                                        , int RecordsFiltered
                                        , int? Start
                                        , int Length
                                        , List<T> Data) :this()
        {
            this.Draw = Draw;
            this.RecordsTotal = RecordsTotal;
            this.RecordsFiltered = RecordsFiltered;
            this.Start = Start;
            this.Length = Length;
            this.Data = Data;
        }
    }
}
