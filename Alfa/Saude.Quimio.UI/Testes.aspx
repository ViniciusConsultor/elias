<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Testes.aspx.cs" Inherits="Saude.Quimio.UI.Testes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
        Text="Incluir" />
    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
        Text="Alterar" />
    <asp:Button ID="Button3" runat="server" onclick="Button3_Click" 
        Text="Excluir" />
    <asp:Button ID="Button4" runat="server" onclick="Button4_Click" 
        Text="Obter por ID" />
    <asp:Button ID="Button5" runat="server" onclick="Button5_Click" 
        Text="Obter com criterio" />
    <br />
    <asp:Button ID="Button6" runat="server" onclick="Button6_Click" 
        Text="Incluir em coleção " />
    <asp:Button ID="Button7" runat="server" onclick="Button7_Click" 
        Text="Excluir em coleção" />
</asp:Content>
