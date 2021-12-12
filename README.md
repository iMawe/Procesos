# Sistema de Transporte


## Web Service Application: Implementación en Visual Studio 2019

Visual Studio 2019 nos permite crear de manera sencilla y rápida un Web Service, ya que cuenta con una plantilla predeterminada para el mismo. En el proyecto nosotros separaremos la aplicación en tres partes: Conexión a la BD Oracle 11g, creación de procedimientos, main de los Web Methods para el Web Service. 

## Comenzando 

Para iniciar recomendamos instalar todo lo necesario para que la subida del Web Service y la conexión con la BD Oracle 11g sea de manera optima:
1) Instalar ***ODAC for Visual Studio 2019***. Esta es una referencia que permite la conexión con la BD y también el uso de todas sus funciones.
2) Instalar ***Package Newtonsoft.Json***. Si en nuestra salida lo que queremos es un formato JSON, ya que al parecer es más manejable, podemos instalar esta pequeña referencia.
3) Para crear mi plantilla de Web Service en Visual Studio 2019 seguí el siguiente tutorial de Microsoft: https://support.microsoft.com/es-pe/help/308359/how-to-write-a-simple-web-service-by-using-visual-c-net


### WebService_Oracle_Connection:

Para poder acceder a todos los comandos que usamos en Visual Studio 2017 para conectarnos a la BD Oracle, primero importamos su referencia que descargamos. 
```
using System.Data.OracleClient;
```
Posteriormente creamos nuestra clase Oracle_Connection, junto con su constructor y un metodo por el cual vamos a establecer la conexión.
* "OracleConnection" creamos un nuevo objeto para poder conectarnos a nuestra BD Oracle.
* "oradb" es un string que debe de tener los siguientes datos necesariamente:
  - DATA SOURCE = localhost:1521/xe 
    - Ingresamos localhost con el puerto 1521 ya que ese puerto viene predeterminado para Oracle, si cambiaste el puerto, tienes que poner el nuevo que tu indicaste.
  - PERSIST SECURITY INFO = True
  - USER ID = TRANSPORTES
    - Ingresamos el usuario que se encuentra ligada a la conexión de la base de datos que realizamos en Oracle.
  - PASSWORD = 1234
    - Ingresamos el password del usuario que hemos ingresado anteriormente.
* Luego en nuestro objeto "oc" de conexión le decimos que la conexión recibe los parametros de nuestro string.
* Finalmente abrimos la conexión.
  
```
OracleConnection oc;
string oradb = "DATA SOURCE=localhost:1521/xe;PERSIST SECURITY INFO=True;USER ID=TRANSPORTE; PASSWORD=1234";
oc = new OracleConnection(oradb);
oc.Open();
```
### WebService_Procedimientos:

Como hemos podido ver en el .sql de procedimientos, tenemos un procedimiento para Insert, Update y Delete de la tabla Administrador y Clientes. 
Más con el Select solo llamamos a la sentencia. Para retornar el Select usamos el comando "DataSet". 
Para usar este comando necesitamos agregar una nueva referencia:
``` 
using System.Data;
```
Mientras si queremos retornar un string de formato JSON, tenemos que agregar la referencia que descargamos: 
```
using Newtonsoft.Json;
```
Comencemos a explicar un procedimiento que recibe parámetros (Insert,Update,Delete). Recordemos el procedimiento "NEW_ADMIN".
```
create or replace procedure InsertarMina (nommin in varchar2, logmin in varchar2, regID in integer, proID in integer, proveID in integer)
is
begin
insert into Minas (minaID, minaNombre, minaLogo, regionID, productoID, proveedorID)
values(MINA_SEQ.nextval, nommin, logmin, regID, proID, proveID);
EXCEPTION
  WHEN NO_DATA_FOUND THEN DBMS_OUTPUT.PUT_LINE('ERROR');

end;
```
Ahora utilizaremos este procedimiento en nuestro Web Service.
* Usamos "OracleParameter" para poder crear un parametro que recibe nuestro procedimiento. Luego le damos el tipo de dato con "OracleType y finalmente lo asignamos al nombre de nuestro paramentro.
* "OracleCommand" crea un nuevo comando, a este comando le damos el nombre de nuestro procedimiento en "CommandText", y posteriormente le indicamos que es un Procedure en "CommandType".
* Finalmente con "Parameters.Add" le asignamos los valores de nuestros parametros creados en la parte de arriba.
  - Tener en cuenta que "nommin", "logmin", "regID", "proID" y "proveID" tienen el mismo nombre en el procedimiento en Oracle.
* Ejecutamos el procedimiento con "ExecuteNonQuery".
* Cerramos la conexión con "Dispose" y finalmente retornamos la respuesta en el formato JSON.

```
public string Insertar_Min(OracleConnection conn, string mina_nombre, string mina_logo, decimal id_region, decimal id_producto, decimal id_proveedor)
        {
            OracleParameter param_nombre_mina = new OracleParameter();
            param_nombre_mina.OracleType = OracleType.VarChar;
            param_nombre_mina.Value = mina_nombre;

            OracleParameter param_logo_mina = new OracleParameter();
            param_logo_mina.OracleType = OracleType.VarChar;
            param_logo_mina.Value = mina_logo;

            OracleParameter param_id_region = new OracleParameter();
            param_id_region.OracleType = OracleType.Number;
            param_id_region.Value = id_region;

            OracleParameter param_id_producto = new OracleParameter();
            param_id_producto.OracleType = OracleType.Number;
            param_id_producto.Value = id_producto;

            OracleParameter param_id_proveedor = new OracleParameter();
            param_id_proveedor.OracleType = OracleType.Number;
            param_id_proveedor.Value = id_proveedor;


            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "INSERTARMINA";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("nommin", OracleType.VarChar).Value = param_nombre_mina.Value;
            cmd.Parameters.Add("logmin", OracleType.VarChar).Value = param_logo_mina.Value;
            cmd.Parameters.Add("regID", OracleType.Number).Value = param_id_region.Value;
            cmd.Parameters.Add("proID", OracleType.Number).Value = param_id_producto.Value;
            cmd.Parameters.Add("proveID", OracleType.Number).Value = param_id_proveedor.Value;
            cmd.ExecuteNonQuery();

            string respuesta = "Mina insertada";
            conn.Dispose();

            return JsonConvert.SerializeObject(respuesta, Newtonsoft.Json.Formatting.Indented);
        }
```
A diferencia de un procedimiento con parametros, si nosotros queremos hacer un Select, utilizaremos un DataSet.
* Al igual que el anterior creamos nuestro comando, sin embargo, la diferencia es que en "CommandText" le enviamos la sentencia del Select
* El "CommandType" ahora es .Text.
* Ahora creamos un DataSet. 
* Con "OracleDataAdapter" le enviamos nuestro nuestro cmd, que es nuestro comando, finalmente guardamos en da, nuestro DataSet que se llama "ds"
* Retornamos en formato JSON.
```
public string MinaList(OracleConnection conn)


        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            OracleParameter param_informe = new OracleParameter();
            param_informe.OracleType = OracleType.Cursor;
            cmd.CommandText = "MINALIST";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("cursor_a", OracleType.Cursor).Direction = ParameterDirection.Output;

            DataSet ds = new DataSet();
            OracleDataAdapter oa = new OracleDataAdapter(cmd);
            oa.Fill(ds);

            return JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);

        }
```

### WebService_Main:

Para poder crear un nuevo método en nuestro Web Service, es con la sentencia: [WebMethod].
* Como vemos al separar por clases tanto la conexión como los procedimientos, en este main del Web Service, solo las instanciamos.
```
[WebMethod]
        public string Mina_Insert(string nombremina, string logomina, Decimal idregion, Decimal idproducto, Decimal idproveedor)
        {
            Oracle_Connection conn = new Oracle_Connection();
            conn.EstablecerConnection();

            Procedure pc = new Procedure();

            return pc.Insertar_Min(conn.GetConexion(), nombremina, logomina, idregion, idproducto, idproveedor);
        }
```


