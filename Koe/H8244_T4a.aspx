<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="H8244_T4a.aspx.cs" Inherits="H8244_T4a" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" Runat="Server">
    <div>
        <asp:Label runat="server" ID="lblCount" />
    </div>
    <asp:Button runat="server" ID="btnGetAllRecords" Text="Hae kaikki levyt" OnClick="btnGetAllRecords_Click" />
    <div>
        <asp:Label runat="server" Text="Hae maasta: " />
        <asp:DropDownList runat="server" ID="ddlCountry" AutoPostBack="false" />
        <asp:Button runat="server" ID="btnGetRecordByCountry" Text="Hae" OnClick="btnGetRecordByCountry_Click" />
    </div>
    
    <asp:Button runat="server" ID="btnOrderByArtist" Text="Order by artist" OnClick="btnOrderByArtist_Click" />
    <asp:GridView runat="server" ID="gvRecords" AutoGenerateColumns="true" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" Runat="Server">
    <asp:Label runat="server" ID="lblError" />
</asp:Content>

