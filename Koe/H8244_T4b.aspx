<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="H8244_T4b.aspx.cs" Inherits="H8244_T4b" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" Runat="Server">
    <div>
        <asp:Label runat="server" Text="Nimi: " />
        <asp:TextBox runat="server" Text="Bill" ID="tbName" Width="200px" />
    </div>    
    <div>
        <asp:Label runat="server" Text="Pvm: " />
        <asp:TextBox runat="server" ID="tbDate" Width="200px" />
    </div>
    <div>
        <asp:Label runat="server" Text="Tunnit: " />
        <asp:TextBox runat="server" ID="tbHours" Width="200px" />
    </div>
    <asp:Button runat="server" ID="btnSave" Text="Kirjaa" OnClick="btnSave_Click" />
    <asp:Button runat="server" ID="btnGetEntries" Text="Hae kaikki merkinnät" OnClick="btnGetEntries_Click" />
    <div>
        <asp:Label runat="server" Text="Kirjausten lukumäärä: " />
        <asp:Label runat="server" ID="lblCount" />
        <asp:GridView runat="server" ID="gvEntries" />
        <asp:Label runat="server" Text="Total hours: " />
        <asp:Label runat="server" ID="lblHours" Text="0" />
    </div>
    
    <asp:Button runat="server" ID="btnSortButton" Text="Sort by date" Onclick="btnSortButton_Click" />
    <div>
        <asp:Label runat="server" Text="Hae nimellä:" />
        <asp:DropDownList runat="server" ID="ddlName" />
        <asp:Button runat="server" ID="btnSearchByName" Text="Hae" OnClick="btnSearchByName_Click" />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" Runat="Server">
    <asp:Label runat="server" ID="lblError" />
</asp:Content>

