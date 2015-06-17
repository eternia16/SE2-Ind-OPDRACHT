<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="scrobble.aspx.cs" Inherits="lastfmWeb.scrobble" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:DropDownList ID="ddlTracks" runat="server"></asp:DropDownList>
    <asp:Button ID="btScrobble" runat="server" Text="Scrobble" OnClick="btScrobble_Click" />
</asp:Content>
