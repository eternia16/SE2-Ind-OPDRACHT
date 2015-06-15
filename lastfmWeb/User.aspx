<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="lastfmWeb.User" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="jumbotron">
        <h1>Hello, <%: Session["gebruikernaam"]  %>!</h1>
        
        
        
    </div>
     <div>
         <asp:Button ID="btScrobbel" class="btn-success" runat="server" Text="Scrobbel registeren" Width="188px" />
         </div>

    <div>
         <asp:Button ID="btArtiest" class="btn-success" runat="server" Text="Artiesten" Width="188px" />
         </div>


        <div>
            <asp:TextBox ID="tbZoeken" runat="server" Width="485px"></asp:TextBox> <asp:Button ID="btZoeken" class="btn-success" runat="server" Text="Zoeken" Width="188px" OnClick="btZoeken_Click" />
         </div>

    <div>
        <h2>Je meest geluisterde muziek</h2>
        <asp:Repeater ID="rpScrobbels" runat="server">
                    <HeaderTemplate>
            <table border="1" width="100%">
<tr>
<th>Tracknaam</th>
<th>Keren geluistered</th>
</tr>
</HeaderTemplate>

<ItemTemplate>
<tr>
<td> <a href="<%# "Track.aspx?query=" + Eval("track_id") %>"> <%# Eval("naamTrack") %></a></td>
<td><%#Eval("scrobble_count")%></td>

</tr>
</ItemTemplate>


        </asp:Repeater>
    </div>
    </asp:Content>
