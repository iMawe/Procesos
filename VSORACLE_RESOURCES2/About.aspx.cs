using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WebApplicationMina
{
    public partial class About : Page
    {
        int a, b, c;
        WebApplicationMina.ServiceReference1.WebService1SoapClient obj = new WebApplicationMina.ServiceReference1.WebService1SoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid();
            }

        }

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

        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }

        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            int minaId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);

            string newnombre = (row.FindControl("txtname") as TextBox).Text;

            obj.Actualizar_Nombre_Mina(minaId, newnombre);

            GridView1.EditIndex = -1;
            this.BindGrid();
        }

        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            GridView1.EditIndex = -1;
            this.BindGrid();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int MINAid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            obj.Delete_Mina(MINAid);
            this.BindGrid();
        }


        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

            /*
            protected void btnList_Click(object sender, EventArgs e)
            {
                String obj_client;
                a = Convert.ToInt32(TextBoxf.Text);
                obj_client = obj.Cliente_Select_Full(a);
                DataTable ds = JObject.Parse(obj_client)["Table"].ToObject<DataTable>();
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }*/

        }
    }
}