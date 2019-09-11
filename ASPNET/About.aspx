<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="ASPNET.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>

    
    <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <br /><br />
    <asp:Label ID="lblDesc" runat="server" Text="Description"></asp:Label>
    <asp:TextBox ID="txtDesc" runat="server"></asp:TextBox>
    <br /><br />
    <asp:Label ID="lblVendor" runat="server" Text="Vendor"></asp:Label>
    <asp:TextBox ID="txtVendor" runat="server"></asp:TextBox>
    <br /><br />
    <asp:Label ID="lblSKU" runat="server" Text="SKU"></asp:Label>
    <asp:TextBox ID="txtSKU" runat="server"></asp:TextBox>
    <br /><br />
    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
    &nbsp; &nbsp; 
    <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
    <br /><br />
    
    <asp:GridView ID="grdProducts" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None"
        DataKeyames ="ProductId" >
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:HyperLinkField DataTextField="Name" HeaderText="Name" DataNavigateUrlFields="ProductID" DataNavigateUrlFormatString="About.aspx?ProductID={0}" />
            <asp:BoundField DataField="Description" HeaderText="Description" />
            <asp:BoundField DataField="SKU" HeaderText="SKU" />
            <asp:BoundField DataField="Vendor" HeaderText="Vendor" />
        </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <SortedAscendingCellStyle BackColor="#FDF5AC" />
        <SortedAscendingHeaderStyle BackColor="#4D0000" />
        <SortedDescendingCellStyle BackColor="#FCF6C0" />
        <SortedDescendingHeaderStyle BackColor="#820000" />
</asp:GridView>

    <asp:HiddenField ID ="hdnProductId" runat="server" />
</asp:Content>
