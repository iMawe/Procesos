using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebApplication2
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        [WebMethod]
        public int Add(int x, int y)
        {
            return x + y;
        }
        [WebMethod]
        public int Sub(int x, int y)
        {
            return x - y;
        }
        [WebMethod]
        public int Mul(int x, int y)
        {
            return x * y;
        }
        [WebMethod]
        public int Div(int x, int y)
        {
            return x / y;
        }

        [WebMethod]
        public string Mina_Insert(string nombremina, string logomina, Decimal idregion, Decimal idproducto, Decimal idproveedor)
        {
            Oracle_Connection conn = new Oracle_Connection();
            conn.EstablecerConnection();

            Procedure pc = new Procedure();

            return pc.Insertar_Min(conn.GetConexion(), nombremina, logomina, idregion, idproducto, idproveedor);
        }

        [WebMethod]
        public string Insertar_Cliente(string nombrecli, string apellidocli, string direccioncli, string emailcli, string fechainicli)
        {
            Oracle_Connection conn = new Oracle_Connection();
            conn.EstablecerConnection();

            Procedure pc = new Procedure();

            return pc.Insertar_Client(conn.GetConexion(), nombrecli, apellidocli, direccioncli, emailcli, fechainicli);
        }

        [WebMethod]
        public string Insertar_Transporte(string nombretra, decimal id_region)
        {
            Oracle_Connection conn = new Oracle_Connection();
            conn.EstablecerConnection();

            Procedure pc = new Procedure();

            return pc.Insertar_Transport(conn.GetConexion(), nombretra, id_region);
        }

        [WebMethod]
        public string Insertar_Producto(string nombrepro, string pro_log)
        {
            Oracle_Connection conn = new Oracle_Connection();
            conn.EstablecerConnection();

            Procedure pc = new Procedure();

            return pc.Insertar_Product(conn.GetConexion(), nombrepro, pro_log);
        }

        [WebMethod]
        public string Actualizar_Nombre_Mina(decimal idmina, string nomMin)
        {
            Oracle_Connection conn = new Oracle_Connection();
            conn.EstablecerConnection();

            Procedure pc = new Procedure();

            return pc.Actualizar_Nombre_Min(conn.GetConexion(), idmina, nomMin);

        }

        [WebMethod]
        public string Actualizar_Nombre_Transporte(decimal idtra, string nomTra)
        {
            Oracle_Connection conn = new Oracle_Connection();
            conn.EstablecerConnection();

            Procedure pc = new Procedure();

            return pc.Actualizar_Nombre_Trans(conn.GetConexion(), idtra, nomTra);

        }

        [WebMethod]
        public string Delete_Cliente(decimal idcli)
        {
            Oracle_Connection conn = new Oracle_Connection();
            conn.EstablecerConnection();

            Procedure pc = new Procedure();

            return pc.Delete_Cli(conn.GetConexion(), idcli);

        }

        [WebMethod]
        public string Delete_Producto(decimal idpro)
        {
            Oracle_Connection conn = new Oracle_Connection();
            conn.EstablecerConnection();

            Procedure pc = new Procedure();

            return pc.Delete_Cli(conn.GetConexion(), idpro);

        }

        [WebMethod]
        public string Insertar_Administrador(string nombreadm, string contradm)
        {
            Oracle_Connection conn = new Oracle_Connection();
            conn.EstablecerConnection();

            Procedure pc = new Procedure();

            return pc.Insertar_Admi(conn.GetConexion(), nombreadm, contradm);
        }

        [WebMethod]
        public string Actualizar_Contra_Administrador(string nomadmi, string newcontra)
        {
            Oracle_Connection conn = new Oracle_Connection();
            conn.EstablecerConnection();

            Procedure pc = new Procedure();

            return pc.Actualizar_Contra_Admi(conn.GetConexion(), nomadmi, newcontra);

        }

        [WebMethod]
        public string Delete_Administrador(string nomadmi)
        {
            Oracle_Connection conn = new Oracle_Connection();
            conn.EstablecerConnection();

            Procedure pc = new Procedure();

            return pc.Delete_Admi(conn.GetConexion(), nomadmi);

        }



        [WebMethod]
        public string Insertar_Empresa(string nombreemp, decimal idtra, string direemp, string emaemp)
        {
            Oracle_Connection conn = new Oracle_Connection();
            conn.EstablecerConnection();

            Procedure pc = new Procedure();

            return pc.Insertar_Emp(conn.GetConexion(), nombreemp, idtra, direemp, emaemp);
        }

        [WebMethod]
        public string Actualizar_Direc_Empresa(string nombreemp, string newdirec)
        {
            Oracle_Connection conn = new Oracle_Connection();
            conn.EstablecerConnection();

            Procedure pc = new Procedure();

            return pc.Actualizar_Direc_Emp(conn.GetConexion(), nombreemp, newdirec);

        }

        [WebMethod]
        public string Delete_Empresa(string nombreemp)
        {
            Oracle_Connection conn = new Oracle_Connection();
            conn.EstablecerConnection();

            Procedure pc = new Procedure();

            return pc.Delete_Emp(conn.GetConexion(), nombreemp);

        }





        [WebMethod]
        public string Insertar_Boleto(string oriBole, string lleBole, string preBole, decimal tranID)
        {
            Oracle_Connection conn = new Oracle_Connection();
            conn.EstablecerConnection();

            Procedure pc = new Procedure();

            return pc.Insertar_Bol(conn.GetConexion(), oriBole, lleBole, preBole, tranID);
        }

        [WebMethod]
        public string Actualizar_Precio_Boleto(string oriBole, string newprecio)
        {
            Oracle_Connection conn = new Oracle_Connection();
            conn.EstablecerConnection();

            Procedure pc = new Procedure();

            return pc.Actualizar_Precio_Bol(conn.GetConexion(), oriBole, newprecio);

        }


        [WebMethod]
        public string Insertar_Proveedor(string nombreprov, string direprov)
        {
            Oracle_Connection conn = new Oracle_Connection();
            conn.EstablecerConnection();

            Procedure pc = new Procedure();

            return pc.Insertar_Prov(conn.GetConexion(), nombreprov, direprov);
        }

        [WebMethod]
        public string Actualizar_Direc_Proveedor(string nombreprov, string newdirec)
        {
            Oracle_Connection conn = new Oracle_Connection();
            conn.EstablecerConnection();

            Procedure pc = new Procedure();

            return pc.Actualizar_Direc_Prov(conn.GetConexion(), nombreprov, newdirec);

        }

        [WebMethod]
        public string Delete_Proveedor(string nombreprov)
        {
            Oracle_Connection conn = new Oracle_Connection();
            conn.EstablecerConnection();

            Procedure pc = new Procedure();

            return pc.Delete_Prov(conn.GetConexion(), nombreprov);

        }




        [WebMethod]
        public string Insertar_Region(string nombrereg)
        {
            Oracle_Connection conn = new Oracle_Connection();
            conn.EstablecerConnection();

            Procedure pc = new Procedure();

            return pc.Insertar_Reg(conn.GetConexion(), nombrereg);
        }

        [WebMethod]
        public string Delete_Region(string nombrereg)
        {
            Oracle_Connection conn = new Oracle_Connection();
            conn.EstablecerConnection();

            Procedure pc = new Procedure();

            return pc.Delete_Reg(conn.GetConexion(), nombrereg);

        }
        [WebMethod]
        public string Delete_Transporte(string nombretra)
        {
            Oracle_Connection conn = new Oracle_Connection();
            conn.EstablecerConnection();

            Procedure pc = new Procedure();

            return pc.Delete_Transport(conn.GetConexion(), nombretra);

        }

        [WebMethod]
        public string Listar_Mina()
        {
            Oracle_Connection conn = new Oracle_Connection();
            conn.EstablecerConnection();

            Procedure pc = new Procedure();

            return pc.MinaList(conn.GetConexion());

        }

        [WebMethod]
        public string Listar_Producto()
        {
            Oracle_Connection conn = new Oracle_Connection();
            conn.EstablecerConnection();

            Procedure pc = new Procedure();

            return pc.ProList(conn.GetConexion());

        }

    }
}
