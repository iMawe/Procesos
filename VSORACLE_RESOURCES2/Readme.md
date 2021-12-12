# Web de Transporte

Ahora utilizaremos este procedimiento en nuestro Web Service(activo).
* Creamos un nuevo proyecto con una plantilla WebForm.
* Agregamos la referencia de nuestro WebService1.asmx para poder utilizar nuestros WebMethod.
* Finalmente agregamos en nuestro About.aspx.cs para tener la conexion del objeto.

```
 public partial class About : Page
    {
        WebApplicationMina.ServiceReference1.WebService1SoapClient obj = new WebApplicationMina.ServiceReference1.WebService1SoapClient();
    }
```
De la siguiente forma mostramos la lista de los datos que tenemos en una de nuestras listas principales.

```
protected void btnList_Click(object sender, EventArgs e)
        {
            String final;
            final = obj.Listar_Mina();
            //DataTable dt = (DataTable)JsonConvert.DeserializeObject(final,typeof(DataTable));
            DataTable ds = JObject.Parse(final)["Table"].ToObject<DataTable>();
            //GridView1.DataSource = ds;
            //GridView1.DataBind();

        }

        protected void BindGrid()
        {
            String final;
            final = obj.Listar_Mina();
            DataTable ds = JObject.Parse(final)["Table"].ToObject<DataTable>();
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
```

A diferencia de un WebMethod tenemos que realizar el llamado por cada boton y cada accion que le demos al usuario.

```
protected void Insert(object sender, EventArgs e)
        {
            string nombre = txtNomMina.Text;
            string logo = txtLogMina.Text;
            string regid = txtReg.Text;
            string proid = txtPro.Text;
            string provid = txtprov.Text;

            int p_regid = Int32.Parse(regid);
            int p_proid = Int32.Parse(proid);
            int p_provid = Int32.Parse(provid);

            obj.Mina_Insert(nombre, logo, p_regid, p_proid, p_provid);

            this.BindGrid();
        }
```

### About.aspx:

Copiamos y pegamos el codigo disponible en nuestro .aspx para poder tener la plantilla de la grilla.



