<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="lastfmWeb.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div>
        <asp:Repeater ID="rpArtiest" runat="server">


            <HeaderTemplate>
            <table border="1" width="100%">
<tr>
<th>Artiest</th>
<th>geboortedatum</th>
<th>omschrijving</th>
</tr>
</HeaderTemplate>

<ItemTemplate>
<tr>
<td> <a href="<%# "Artiest.aspx?query=" + Eval("id") %>"> <%# Eval("naam") %></a></td>
<td><%#Eval("geboortedatum")%></td>
<td><%#Eval("omschrijving")%></td>

</tr>
</ItemTemplate>
        </asp:Repeater>

    </div>




        <div>
            <asp:Repeater ID="rpAlbums" runat="server">
                <HeaderTemplate>
            <table border="1" width="100%">
<tr>
<th>Naam</th>
<th>Artiest</th>
<th>releasedate</th>
<th>omschrijving</th>
</tr>
</HeaderTemplate>

<ItemTemplate>
<tr>
<td> <a href="<%# "Album.aspx?query=" + Eval("id") %>"> <%# Eval("naam") %></a></td>
<td><%#Eval("Artiest")%></td>
<td><%#Eval("releasedate")%></td>
<td><%#Eval("omschrijving")%></td>

</tr>
</ItemTemplate>
            </asp:Repeater>

    </div>







        <div>
            <asp:Repeater ID="rpTracks" runat="server">
                <HeaderTemplate>
            <table border="1" width="100%">
<tr>
<th>Naam</th>
<th>Artiest</th>
<th>album</th>
<th>omschrijving</th>
<th>tijdsduur</th>
<th>releasedate</th>
</tr>
</HeaderTemplate>

<ItemTemplate>
<tr>
<td> <a href="<%# "Tracks.aspx?query=" + Eval("id") %>"> <%# Eval("naam") %></a></td>
<td><%#Eval("artiest")%></td>
<td><%#Eval("album")%></td>
<td><%#Eval("omschrijving")%></td>
<td><%#Eval("tijdsduur_string")%></td>
<td><%#Eval("releasedate")%></td>


</tr>
</ItemTemplate>
            </asp:Repeater>

    </div>
</asp:Content>
