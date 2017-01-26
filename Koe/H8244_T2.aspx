<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="H8244_T2.aspx.cs" Inherits="H8244_T2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" Runat="Server">
    <asp:Button runat="server" ID="btnGetCountriesByPopulation" OnClick="btnGetBiggestCountriesByPopulation_Click" Text="Hae asukasluvultaan 10 suurinta" />
    <asp:Button runat="server" ID="btnGetCountriesByLifeExpectancy" OnClick="btnGetCountriesByLifeExpectancy_Click" Text="Hae eliniänennusteelta viisi pienintä" />
    <div>
        <asp:Label runat="server" Text="Etsi maata nimellä: " />
        <asp:TextBox runat="server" ID="tbSearch" Width="200px" />
        <asp:Button runat="server" ID="btnSearch" Text="Etsi" OnClick="btnSearch_Click" />
    </div>
    <div>
        <asp:Label runat="server" Text="Maiden määrä: " />
        <asp:Label runat="server" ID="lblCountryCount" />
    </div>
    <div>
        <asp:Label runat="server" Text="Asukkaiden määrä maissa yhteensä: " />
        <asp:Label runat="server" ID="lblPopulation" />
    </div>
    <asp:GridView runat="server" ID="gvCountries" AutoGenerateColumns ="false">
        <Columns>
            <asp:BoundField HeaderText="Nimi" DataField="Name" />
            <asp:BoundField HeaderText="Paikallinen nimi" DataField="LocalName" />
            <asp:BoundField HeaderText="Manner" DataField="Continent" />
            <asp:BoundField HeaderText="Päämies" DataField="HeadOfState" />
            <asp:BoundField HeaderText="Asukasmäärä" DataField="Population" />
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" Runat="Server">

</asp:Content>

