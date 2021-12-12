using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.OracleClient;
using Newtonsoft.Json;
using System.Web;
using System.Data;

namespace WebApplication2
{
    public class Procedure
    {
        public Procedure()
        {

        }
        
        public string Admin_Login_Pro(OracleConnection conn, string usuario, string contrasena)
        {

            OracleParameter param_usuario = new OracleParameter();
            param_usuario.OracleType = OracleType.VarChar;
            param_usuario.Value = usuario;

            OracleParameter param_contrasena = new OracleParameter();
            param_contrasena.OracleType = OracleType.VarChar;
            param_contrasena.Value = contrasena;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "LOGIN";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("PV1", OracleType.VarChar).Value = param_usuario.Value;
            cmd.Parameters.Add("PV2", OracleType.VarChar).Value = param_contrasena.Value;
            cmd.Parameters.Add("PS1", OracleType.Int16).Direction = System.Data.ParameterDirection.Output;
            cmd.ExecuteNonQuery();

            string respuesta;
            respuesta = cmd.Parameters["PS1"].Value.ToString();
            conn.Dispose();

            return respuesta;
        }

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

        public string Insertar_Client(OracleConnection conn, string cli_nombre, string cli_apellido, string cli_direccion, string cli_email, string cli_fechaini)
        {
            OracleParameter param_cli_nombre = new OracleParameter();
            param_cli_nombre.OracleType = OracleType.VarChar;
            param_cli_nombre.Value = cli_nombre;

            OracleParameter param_cli_apellido = new OracleParameter();
            param_cli_apellido.OracleType = OracleType.VarChar;
            param_cli_apellido.Value = cli_apellido;

            OracleParameter param_cli_direccion = new OracleParameter();
            param_cli_direccion.OracleType = OracleType.VarChar;
            param_cli_direccion.Value = cli_direccion;

            OracleParameter param_cli_email = new OracleParameter();
            param_cli_email.OracleType = OracleType.VarChar;
            param_cli_email.Value = cli_email;

            OracleParameter param_cli_fechaini = new OracleParameter();
            param_cli_fechaini.OracleType = OracleType.VarChar;
            param_cli_fechaini.Value = cli_fechaini;


            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "INSERTARCLIENTE";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("nomcli", OracleType.VarChar).Value = param_cli_nombre.Value;
            cmd.Parameters.Add("apecli", OracleType.VarChar).Value = param_cli_apellido.Value;
            cmd.Parameters.Add("direccli", OracleType.VarChar).Value = param_cli_direccion.Value;
            cmd.Parameters.Add("emailcli", OracleType.VarChar).Value = param_cli_email.Value;
            cmd.Parameters.Add("fechainicli", OracleType.VarChar).Value = param_cli_fechaini.Value;
            cmd.ExecuteNonQuery();
           
            string respuesta = "Cliente insertado";
            conn.Dispose();

            return JsonConvert.SerializeObject(respuesta, Newtonsoft.Json.Formatting.Indented);
        }

        public string Insertar_Product(OracleConnection conn, string pro_nombre, string pro_logo)
        {
            OracleParameter param_pro_nombre = new OracleParameter();
            param_pro_nombre.OracleType = OracleType.VarChar;
            param_pro_nombre.Value = pro_nombre;

            OracleParameter param_pro_logo = new OracleParameter();
            param_pro_logo.OracleType = OracleType.VarChar;
            param_pro_logo.Value = pro_logo;


            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "INSERTARPRODUCTO";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("nompro", OracleType.VarChar).Value = param_pro_nombre.Value;
            cmd.Parameters.Add("logopro", OracleType.VarChar).Value = param_pro_logo.Value;
            cmd.ExecuteNonQuery();

            string respuesta = "Producto insertado";
            conn.Dispose();

            return JsonConvert.SerializeObject(respuesta, Newtonsoft.Json.Formatting.Indented);
        }

        public string Insertar_Transport(OracleConnection conn, string tra_nombre, decimal id_region)
        {
            OracleParameter param_tra_nombre = new OracleParameter();
            param_tra_nombre.OracleType = OracleType.VarChar;
            param_tra_nombre.Value = tra_nombre;

            OracleParameter param_tra_logo = new OracleParameter();
            param_tra_logo.OracleType = OracleType.Number;
            param_tra_logo.Value = id_region;


            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "INSERTARTRANSPORTE";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("nomtra", OracleType.VarChar).Value = param_tra_nombre.Value;
            cmd.Parameters.Add("regID", OracleType.Number).Value = param_tra_logo.Value;
            cmd.ExecuteNonQuery();

            string respuesta = "Transporte insertado";
            conn.Dispose();

            return JsonConvert.SerializeObject(respuesta, Newtonsoft.Json.Formatting.Indented);
        }

        public string Delete_Transport(OracleConnection conn, string nombretrans)
        {
            OracleParameter param_nom_tran = new OracleParameter();
            param_nom_tran.OracleType = OracleType.Number;
            param_nom_tran.Value = nombretrans;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETETRANSPORTE";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("us", OracleType.Number).Value = param_nom_tran.Value;

            cmd.ExecuteNonQuery();

            string respuesta = "Transporte borrado";
            conn.Dispose();

            return JsonConvert.SerializeObject(respuesta, Newtonsoft.Json.Formatting.Indented);
        }




        public string Actualizar_Nombre_Min(OracleConnection conn, decimal idmine, string nom)
        {
            OracleParameter param_id = new OracleParameter();
            param_id.OracleType = OracleType.Number;
            param_id.Value = idmine;

            OracleParameter param_nom = new OracleParameter();
            param_nom.OracleType = OracleType.VarChar;
            param_nom.Value = nom;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "ACTUALIZARNOMBREMINA";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("minaID", OracleType.Number).Value = param_id.Value;
            cmd.Parameters.Add("nomMin", OracleType.VarChar).Value = param_nom.Value;

            cmd.ExecuteNonQuery();

            string respuesta = "Nombre de mina actualizado";
            conn.Dispose();

            return JsonConvert.SerializeObject(respuesta, Newtonsoft.Json.Formatting.Indented);
        }

        public string Actualizar_Nombre_Trans(OracleConnection conn, decimal idtra, string nom)
        {
            OracleParameter param_id = new OracleParameter();
            param_id.OracleType = OracleType.Number;
            param_id.Value = idtra;

            OracleParameter param_nom = new OracleParameter();
            param_nom.OracleType = OracleType.VarChar;
            param_nom.Value = nom;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "ACTUALIZARNOMBRETRANSPORTE";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("traID", OracleType.Number).Value = param_id.Value;
            cmd.Parameters.Add("nomTra", OracleType.VarChar).Value = param_nom.Value;

            cmd.ExecuteNonQuery();

            string respuesta = "Nombre de transporte actualizado";
            conn.Dispose();

            return JsonConvert.SerializeObject(respuesta, Newtonsoft.Json.Formatting.Indented);
        }


        public string Delete_Cli(OracleConnection conn, decimal idcli)
        {
            OracleParameter param_id = new OracleParameter();
            param_id.OracleType = OracleType.Number;
            param_id.Value = idcli;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETECLIENTE";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("cliID", OracleType.Number).Value = param_id.Value;

            cmd.ExecuteNonQuery();

            string respuesta = "Cliente borrado";
            conn.Dispose();

            return JsonConvert.SerializeObject(respuesta, Newtonsoft.Json.Formatting.Indented);
        }

        public string Delete_Pro(OracleConnection conn, decimal idpro)
        {
            OracleParameter param_id = new OracleParameter();
            param_id.OracleType = OracleType.Number;
            param_id.Value = idpro;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETEPRODUCTO";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("cliID", OracleType.Number).Value = param_id.Value;

            cmd.ExecuteNonQuery();

            string respuesta = "Producto borrado";
            conn.Dispose();

            return JsonConvert.SerializeObject(respuesta, Newtonsoft.Json.Formatting.Indented);
        }

        public string Insertar_Admi(OracleConnection conn, string nombreadm, string contradm)
        {
            OracleParameter param_nombre_admi = new OracleParameter();
            param_nombre_admi.OracleType = OracleType.VarChar;
            param_nombre_admi.Value = nombreadm;

            OracleParameter param_contra_admi = new OracleParameter();
            param_contra_admi.OracleType = OracleType.VarChar;
            param_contra_admi.Value = contradm;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "INSERTARADMIN";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("us", OracleType.VarChar).Value = param_nombre_admi.Value;
            cmd.Parameters.Add("contra", OracleType.VarChar).Value = param_contra_admi.Value;
            cmd.ExecuteNonQuery();

            string respuesta = "Administrador insertado";
            conn.Dispose();

            return JsonConvert.SerializeObject(respuesta, Newtonsoft.Json.Formatting.Indented);
        }


        public string Actualizar_Contra_Admi(OracleConnection conn, string nomadmi, string contradmi)
        {
            OracleParameter param_user_admi = new OracleParameter();
            param_user_admi.OracleType = OracleType.VarChar;
            param_user_admi.Value = nomadmi;

            OracleParameter param_contra_admi = new OracleParameter();
            param_contra_admi.OracleType = OracleType.VarChar;
            param_contra_admi.Value = contradmi;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "ACTUALIZARCONTRAADMIN";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("us", OracleType.Number).Value = param_user_admi.Value;
            cmd.Parameters.Add("contra", OracleType.VarChar).Value = param_contra_admi.Value;

            cmd.ExecuteNonQuery();

            string respuesta = "Contrasenia de Administrador actualizada";
            conn.Dispose();

            return JsonConvert.SerializeObject(respuesta, Newtonsoft.Json.Formatting.Indented);
        }

        public string Delete_Admi(OracleConnection conn, string nomadmi)
        {
            OracleParameter param_user_admi = new OracleParameter();
            param_user_admi.OracleType = OracleType.Number;
            param_user_admi.Value = nomadmi;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETEADMIN";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("us", OracleType.Number).Value = param_user_admi.Value;

            cmd.ExecuteNonQuery();

            string respuesta = "Administrador borrado";
            conn.Dispose();

            return JsonConvert.SerializeObject(respuesta, Newtonsoft.Json.Formatting.Indented);
        }


        public string Insertar_Emp(OracleConnection conn, string nombreemp, decimal idtra, string direemp, string emaemp)
        {
            OracleParameter param_nombre_emp = new OracleParameter();
            param_nombre_emp.OracleType = OracleType.VarChar;
            param_nombre_emp.Value = nombreemp;

            OracleParameter param_idtra = new OracleParameter();
            param_idtra.OracleType = OracleType.Number;
            param_idtra.Value = idtra;

            OracleParameter param_direc_emp = new OracleParameter();
            param_direc_emp.OracleType = OracleType.VarChar;
            param_direc_emp.Value = direemp;

            OracleParameter param_email_emp = new OracleParameter();
            param_email_emp.OracleType = OracleType.VarChar;
            param_email_emp.Value = emaemp;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "INSERTAREMPRESA";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("nomemp", OracleType.VarChar).Value = param_nombre_emp.Value;
            cmd.Parameters.Add("transid", OracleType.Number).Value = param_idtra.Value;
            cmd.Parameters.Add("direcemp", OracleType.VarChar).Value = param_direc_emp.Value;
            cmd.Parameters.Add("emailemp", OracleType.VarChar).Value = param_email_emp.Value;
            cmd.ExecuteNonQuery();

            string respuesta = "Empresa insertada";
            conn.Dispose();

            return JsonConvert.SerializeObject(respuesta, Newtonsoft.Json.Formatting.Indented);
        }


        public string Actualizar_Direc_Emp(OracleConnection conn, string nombreemp, string newdirec)
        {
            OracleParameter param_nombre_emp = new OracleParameter();
            param_nombre_emp.OracleType = OracleType.VarChar;
            param_nombre_emp.Value = nombreemp;

            OracleParameter param_direc_emp = new OracleParameter();
            param_direc_emp.OracleType = OracleType.VarChar;
            param_direc_emp.Value = newdirec;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "ACTUALIZARCONTRAADMIN";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("us", OracleType.Number).Value = param_nombre_emp.Value;
            cmd.Parameters.Add("direc", OracleType.VarChar).Value = param_direc_emp.Value;

            cmd.ExecuteNonQuery();

            string respuesta = "Direccion de Empresa actualizada";
            conn.Dispose();

            return JsonConvert.SerializeObject(respuesta, Newtonsoft.Json.Formatting.Indented);
        }

        public string Delete_Emp(OracleConnection conn, string nomemp)
        {
            OracleParameter param_nom_emp = new OracleParameter();
            param_nom_emp.OracleType = OracleType.Number;
            param_nom_emp.Value = nomemp;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETEADMIN";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("us", OracleType.Number).Value = param_nom_emp.Value;

            cmd.ExecuteNonQuery();

            string respuesta = "Empresa borrada";
            conn.Dispose();

            return JsonConvert.SerializeObject(respuesta, Newtonsoft.Json.Formatting.Indented);
        }


        public string Insertar_Bol(OracleConnection conn, string oriBole, string lleBole, string preBole, decimal tranID)
        {
            OracleParameter param_origen_boleto = new OracleParameter();
            param_origen_boleto.OracleType = OracleType.VarChar;
            param_origen_boleto.Value = oriBole;

            OracleParameter param_llegada_bole = new OracleParameter();
            param_llegada_bole.OracleType = OracleType.VarChar;
            param_llegada_bole.Value = lleBole;

            OracleParameter param_precio_boleto = new OracleParameter();
            param_precio_boleto.OracleType = OracleType.VarChar;
            param_precio_boleto.Value = preBole;

            OracleParameter param_idtra = new OracleParameter();
            param_idtra.OracleType = OracleType.Number;
            param_idtra.Value = tranID;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "INSERTARBOLETO";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("oriBol", OracleType.VarChar).Value = param_origen_boleto.Value;
            cmd.Parameters.Add("lleBol", OracleType.VarChar).Value = param_llegada_bole.Value;
            cmd.Parameters.Add("preBol", OracleType.VarChar).Value = param_precio_boleto.Value;
            cmd.Parameters.Add("transID", OracleType.Number).Value = param_idtra.Value;
            cmd.ExecuteNonQuery();

            string respuesta = "Boleto insertado";
            conn.Dispose();

            return JsonConvert.SerializeObject(respuesta, Newtonsoft.Json.Formatting.Indented);
        }


        public string Actualizar_Precio_Bol(OracleConnection conn, string oribol, string newprecio)
        {
            OracleParameter param_ori_boleto = new OracleParameter();
            param_ori_boleto.OracleType = OracleType.VarChar;
            param_ori_boleto.Value = oribol;

            OracleParameter param_precio_boleto = new OracleParameter();
            param_precio_boleto.OracleType = OracleType.VarChar;
            param_precio_boleto.Value = newprecio;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "ACTUALIZARPRECIOBOLETO";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("orig", OracleType.Number).Value = param_ori_boleto.Value;
            cmd.Parameters.Add("precio", OracleType.VarChar).Value = param_precio_boleto.Value;

            cmd.ExecuteNonQuery();

            string respuesta = "Precio de Boletos actualizado";
            conn.Dispose();

            return JsonConvert.SerializeObject(respuesta, Newtonsoft.Json.Formatting.Indented);
        }






        public string Insertar_Prov(OracleConnection conn, string nombreprov, string direprov)
        {
            OracleParameter param_nombre_prov = new OracleParameter();
            param_nombre_prov.OracleType = OracleType.VarChar;
            param_nombre_prov.Value = nombreprov;

            OracleParameter param_direc_prov = new OracleParameter();
            param_direc_prov.OracleType = OracleType.VarChar;
            param_direc_prov.Value = direprov;


            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "INSERTARPROVEEDOR";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("nomprov", OracleType.VarChar).Value = param_nombre_prov.Value;
            cmd.Parameters.Add("dirprov", OracleType.VarChar).Value = param_direc_prov.Value;
            cmd.ExecuteNonQuery();

            string respuesta = "Proveedor insertado";
            conn.Dispose();

            return JsonConvert.SerializeObject(respuesta, Newtonsoft.Json.Formatting.Indented);
        }


        public string Actualizar_Direc_Prov(OracleConnection conn, string nombreprov, string newdirec)
        {
            OracleParameter param_nombre_prov = new OracleParameter();
            param_nombre_prov.OracleType = OracleType.VarChar;
            param_nombre_prov.Value = nombreprov;

            OracleParameter param_direc_prov = new OracleParameter();
            param_direc_prov.OracleType = OracleType.VarChar;
            param_direc_prov.Value = newdirec;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "ACTUALIZARDIRECCIONPROVEE";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("us", OracleType.Number).Value = param_nombre_prov.Value;
            cmd.Parameters.Add("direc", OracleType.VarChar).Value = param_direc_prov.Value;

            cmd.ExecuteNonQuery();

            string respuesta = "Direccion de Proveedor actualizada";
            conn.Dispose();

            return JsonConvert.SerializeObject(respuesta, Newtonsoft.Json.Formatting.Indented);
        }

        public string Delete_Prov(OracleConnection conn, string nombreprov)
        {
            OracleParameter param_nom_prov = new OracleParameter();
            param_nom_prov.OracleType = OracleType.Number;
            param_nom_prov.Value = nombreprov;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETEPROVE";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("us", OracleType.Number).Value = param_nom_prov.Value;

            cmd.ExecuteNonQuery();

            string respuesta = "Proveedor borrado";
            conn.Dispose();

            return JsonConvert.SerializeObject(respuesta, Newtonsoft.Json.Formatting.Indented);
        }



        public string Insertar_Reg(OracleConnection conn, string nombrereg)
        {
            OracleParameter param_nombre_reg = new OracleParameter();
            param_nombre_reg.OracleType = OracleType.VarChar;
            param_nombre_reg.Value = nombrereg;


            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "INSERTARREGION";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("nomreg", OracleType.VarChar).Value = param_nombre_reg.Value;
            cmd.ExecuteNonQuery();

            string respuesta = "Region insertada";
            conn.Dispose();

            return JsonConvert.SerializeObject(respuesta, Newtonsoft.Json.Formatting.Indented);
        }

        public string Delete_Reg(OracleConnection conn, string nombrereg)
        {
            OracleParameter param_nom_reg = new OracleParameter();
            param_nom_reg.OracleType = OracleType.Number;
            param_nom_reg.Value = nombrereg;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETEREGION";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("us", OracleType.Number).Value = param_nom_reg.Value;

            cmd.ExecuteNonQuery();

            string respuesta = "Region borrada";
            conn.Dispose();

            return JsonConvert.SerializeObject(respuesta, Newtonsoft.Json.Formatting.Indented);
        }


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

        public string ProList(OracleConnection conn)


        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            OracleParameter param_informe = new OracleParameter();
            param_informe.OracleType = OracleType.Cursor;
            cmd.CommandText = "PROLIST";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("cursor_b", OracleType.Cursor).Direction = ParameterDirection.Output;

            DataSet ds = new DataSet();
            OracleDataAdapter oa = new OracleDataAdapter(cmd);
            oa.Fill(ds);

            return JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);

        }


    }
}