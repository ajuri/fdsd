<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="H8244_T3.aspx.cs" Inherits="H8244_T3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" Runat="Server">
    <div>
        <asp:Label runat="server" ID="lblHelp" />
    </div>
    <asp:Button runat="server" ID="btnGetCustomerData" Text="Hae asiakkaat" OnClick="btnGetCustomerData_Click" />
    <asp:DropDownList runat="server" ID="ddlCountrySelect" />
    <asp:GridView runat="server" ID="gvTest" />
    <asp:GridView runat="server" ID="gvCustomers" AutoGenerateColumns="false" >
        <Columns>
            <asp:BoundField HeaderText="Nimi" DataField="asnimi" />
            <asp:BoundField HeaderText="Maa" DataField="Maa" />
            <asp:BoundField HeaderText="Yhteyshenkilö" DataField="yhteyshlo" />
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" Runat="Server">    
    <div>
        <asp:Label runat="server" ID="lblError" />
    </div>
</asp:Content>

