<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="WebApplicationMina.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <div> 
    <link href="StyleSheet1.css" rel="stylesheet" />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" DataKeyNames="MINAID"
    OnRowDataBound="OnRowDataBound" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit"
    AllowPaging="true" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" OnRowUpdating="OnRowUpdating" OnRowDeleting="OnRowDeleting" EmptyDataText="No records has been added." OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="942px">
    <Columns>
    

        <asp:TemplateField HeaderText="ID" ItemStyle-Width="150" Visible="False">
        
            <ItemTemplate>
                <asp:Label ID="lblId" runat="server" Text='<%# Eval("MINAID") %>'></asp:Label>
            </ItemTemplate>
        
            <EditItemTemplate>
                <asp:TextBox ID="txtId" runat="server" Text='<%# Eval("MINAID") %>'></asp:TextBox>
            </EditItemTemplate>
        


        </asp:TemplateField>


        <asp:TemplateField HeaderText="Nombre" ItemStyle-Width="150">
            <ItemTemplate>
                <asp:Label ID="lblname" runat="server" Text='<%# Eval("MINANOMBRE") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtname" runat="server" Text='<%# Eval("MINANOMBRE") %>'></asp:TextBox>
            </EditItemTemplate>
    
        </asp:TemplateField>

    
        <asp:TemplateField HeaderText="Logo" ItemStyle-Width="150">
            <ItemTemplate>
                <asp:Label ID="lbllog" runat="server" Text='<%# Eval("MINALOGO") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtlog" runat="server" Text='<%# Eval("MINALOGO") %>'></asp:TextBox>
            </EditItemTemplate>
    
        </asp:TemplateField>
    



        <asp:TemplateField HeaderText="Region" ItemStyle-Width="150">
            <ItemTemplate>
                <asp:Label ID="lblreg" runat="server" Text='<%# Eval("REGIONNOMBRE") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtreg" runat="server" Text='<%# Eval("REGIONNOMBRE") %>'></asp:TextBox>
            </EditItemTemplate>




        </asp:TemplateField>
        <asp:TemplateField HeaderText="Producto" ItemStyle-Width="150">
            <ItemTemplate>
                <asp:Label ID="lblpro" runat="server" Text='<%# Eval("PRODUCTONOMBRE") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtpro" runat="server" Text='<%# Eval("PRODUCTONOMBRE") %>'></asp:TextBox>
            </EditItemTemplate>

        </asp:TemplateField>


         <asp:TemplateField HeaderText="Proveedor" ItemStyle-Width="150">
            <ItemTemplate>
                <asp:Label ID="lblprov" runat="server" Text='<%# Eval("PROVEEDORNOMBRE") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtprov" runat="server" Text='<%# Eval("PROVEEDORNOMBRE") %>'></asp:TextBox>
            </EditItemTemplate>

        </asp:TemplateField>


        <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true" ItemStyle-Width="150"/>

    </Columns>
       
    </asp:GridView>




<br>
        <br>
        <br>

<link href="StyleSheet1.css" rel="stylesheet" type="text/css">

<table style="margin: 0 auto;" border="0" cellpadding="0" cellspacing="0" style="border-collapse: collapse"  >

<tr>
    <td style="width: 150px">
        <b>Mina Nombre:<b/><br />
        <asp:TextBox ID="txtNomMina" runat="server" Width="140" />
    </td>

    <td style="width: 150px">
        <b>Mina Logo:<b/><br />
        <asp:TextBox ID="txtLogMina" runat="server" Width="140" />
    </td>
    
    <td style="width: 150px">
        <b>RegionID:<b/><br />
        <asp:TextBox ID="txtReg" runat="server" Width="140" />
    </td>

    <td style="width: 150px">
        <b>ProductoID:<b/><br />
        <asp:TextBox ID="txtPro" runat="server" Width="140" />
    </td>

    <td style="width: 150px">
        <b>ProveedorID:<b/><br />
        <asp:TextBox ID="txtprov" runat="server" Width="140" />
    </td>
 

    <td style="width: 100px">
        <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="Insert" class="boton" />
    </td>
</tr>
</table>


     </div> 



</asp:Content>
