using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JQueryDataTablesServerSide
{
    public class JQueryDataTablesRequest : IRequest
    {
        /// <summary>
        /// Columnas de la tabla (incluidas las no visibles y/o no buscables u ordenables)
        /// </summary>
        public List<Column> Columns { get; set; }
        /// <summary>
        /// Variable utilizada por DataTables, la cual es un contador.
        /// Esto es para asegurarse de renderizar los datos de la última petición.
        /// 
        /// NOTA: Devolver el mismo valor recibido
        /// </summary>
        public int Draw { get; set; }
        /// <summary>
        /// Valor (Opcional) que indica a partir de qué fila se deberán
        /// devolver los registros (cota inferior para la paginación)
        /// </summary>
        public int Start { get; set; }
        /// <summary>
        /// Valor que indica a hasta qué fila se deberán
        /// devolver los registros (cota superior para la paginación)
        /// </summary>
        public int Length { get; set; }
        /// <summary>
        /// Indica por qué columna o Columas (si está habilitada el orden múltiple)
        /// se deben ordenar los resultados
        /// </summary>
        public List<ColumnOrder> Order { get; set; }
        /// <summary>
        /// [Search] es el valor del filtro general
        /// que viene por defecto con DataTables
        /// </summary>
        public SearchFilter Search { get; set; }
        /// <summary>
        /// Filtros extra (añadidos a la petición), que se añadirán
        /// a los parámetros proporcionados al momento de invocar
        /// a los Stored Procedures. Ejemplo:
        /// 
        /// "AdditionalFilters": {
	    ///     "FechaDesde": "01/02/2019",
	    ///     "FechaHasta": "28/02/2019",
        /// }
        /// </summary>
        public Dictionary<String,String> AdditionalFilters { get; set; }

        public JQueryDataTablesRequest()
        {
            AdditionalFilters = new Dictionary<String, String>();
            Columns = new List<Column>();
            Order = new List<ColumnOrder>();
            Search = new SearchFilter();
        }

        public Dictionary<String, String> ToDictionary()
        {
            Dictionary<String, String> result = new Dictionary<String, String>();

            // filtro general
            result.Add("Search", Search.Value);

            // filtros individuales de columnas
            foreach (Column column in Columns)
            {
                if(column.Searchable == true)
                {
                    result.Add(column.Name, column.Search.Value);
                }                
            }

            // filtros adicionales
            foreach (String key in AdditionalFilters.Keys)
            {
                result.Add(key, AdditionalFilters[key]);
            }

            // ordenacion
            byte count = 0;
            String OrderBy = "";
            foreach (ColumnOrder columnToOrder in Order)
            {
                OrderBy += (count > 0 ? ", " : "") + Columns[columnToOrder.Column].Name + " " + columnToOrder.Dir;
                count++;
            }
            result.Add("OrderBy", OrderBy);

            // paginacion
            result.Add("Start", Start.ToString());//@SEE puede ser nulo. En las pruebas que realicé, si es nulo, devuelve "" (String.Empty) pero si hay problemas, revisar esta línea en primer instancia
            result.Add("Length", Length.ToString());

            return result;
        }
    }
}
