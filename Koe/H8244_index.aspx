<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="H8244_index.aspx.cs" Inherits="H8244_index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" Runat="Server">
    <h2>Janne Möttölä, H8244</h2>
    <asp:Image ID="myImage" runat="server" ImageUrl="~/img/mypic.png" Height="200px" />
    <div>
        <asp:LinkButton runat="server" ID="lbT2" PostBackUrl="~/H8244_T2.aspx" Text="Tehtävä 2" />
    </div>
    <div>
        <asp:LinkButton runat="server" ID="lbT3" PostBackUrl="~/H8244_T3.aspx" Text="Tehtävä 3" />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" Runat="Server">

</asp:Content>

