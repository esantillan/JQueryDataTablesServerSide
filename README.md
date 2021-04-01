# JQueryDataTablesServerSide
"Solucion de VisualStudio" para .NetFramework que permite utilizar la paginacion y ordenacion de [JQueryDataTables](https://datatables.net/) con paginación del lado del servidor

* Añadir primero la referencia al proyecto (dentro de la solucion de VisualStudio)
* "importar" con 
 ```C#
using JQueryDataTablesServerSide;
```

y podría utilizarse de la siguiente manera:
```C#
[WebMethod]
public static JQueryDataTablesResponse<IDTO> TransaccionesGiros(JQueryDataTablesRequest columnsFilters)//@SEE devuelve un objeto que implemente la interfaz IDTO (ficticia) pero puede ser cualquier Objeto
{
    GiroDAO dao = new GiroDAO();
    JQueryDataTablesResponse<IDTO> response = new JQueryDataTablesResponse<IDTO>();

    response.Draw = columnsFilters.Draw;
    response.Start = columnsFilters.Start;
    response.Length = columnsFilters.Length;
    response.Data = dao.List(columnsFilters);

    Dictionary<String, int> count = dao.ListCount(columnsFilters);
    response.RecordsTotal = count["RecordsTotal"];
    response.RecordsFiltered = count["RecordsFiltered"];

    return response;
}
```

## Notas

El código de Ejemplo es de una página de ASP
