﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Alfa.Pet.Web._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:ScriptManager ID="sm" runat="server">
    </asp:ScriptManager>
    <h2>
        Welcome to ASP.NET!
    </h2>
    <p>
        To learn more about ASP.NET visit <a href="http://www.asp.net" title="ASP.NET Website">
            www.asp.net</a>.
    </p>
    <p>
        You can also find <a href="http://go.microsoft.com/fwlink/?LinkID=152368&amp;clcid=0x409"
            title="MSDN ASP.NET Docs">documentation on ASP.NET at MSDN</a>.
        <asp:UpdatePanel ID="up" runat="server">
            <ContentTemplate>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Listar" />
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Inserir" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </p>
</asp:Content>
