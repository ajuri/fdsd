<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="kuvat.aspx.cs" Inherits="kuvat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" Runat="Server">
    <asp:GridView runat="server" ID="gvPics" AutoGenerateColumns="false" OnRowCommand="gvPics_RowCommand">
        <Columns>
            <asp:BoundField HeaderText="Filename" DataField="Filename" />
            <asp:TemplateField HeaderText="Image">                     
                <ItemTemplate> 
                    <asp:Image runat="server" Height="100px" ImageUrl='<%# string.Format("~/pictures/{0}", Eval("Filename"))%>'/> 
                </ItemTemplate> 
            </asp:TemplateField> 
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button runat="server" CommandName="ShowPicture" CommandArgument='<%# Eval("Filename")%>' Text="Show" />
                </ItemTemplate> 
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    
    <asp:Image runat="server" ID="imgBig" Height="500px" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" Runat="Server">
</asp:Content>

