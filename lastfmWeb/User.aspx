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
        <asp:TextBox ID="tbZoeken" runat="server" Width="485px"></asp:TextBox>
        <asp:Button ID="btZoeken" class="btn-success" runat="server" Text="Zoeken" Width="188px" OnClick="btZoeken_Click" />
        <br />
        <div runat="server" id="artiestDiv">
            <asp:Button ID="Button1" runat="server" Text="Artiest" Width="188px" />
        </div>
        <br />
        <div runat="server" id="AdministratorDiv">
            <asp:Button ID="Button2" runat="server" Width="188px" Text="Administrator" />
        </div>
        <br />
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
                    <td><a href="<%# "Track.aspx?query=" + Eval("track_id") %>"><%# Eval("naamTrack") %></a></td>
                    <td><%#Eval("scrobble_count")%></td>

                </tr>
            </ItemTemplate>


        </asp:Repeater>

        <asp:Repeater ID="rpShouts" runat="server">
            <HeaderTemplate>
                <table border="1" width="100%">
                    <tr>
                        <th>Van</th>
                        <th>wanneer</th>
                        <th>bericht</th>
                    </tr>
            </HeaderTemplate>

            <ItemTemplate>
                <tr>
                    <td><%# Eval("gebruikernaam") %></a></td>
                    <td><%#Eval("datum")%></td>
                    <td><%#Eval("tekst")%></td>

                </tr>
            </ItemTemplate>


        </asp:Repeater>
        <asp:TextBox ID="TextBox1" runat="server" Width="756px"></asp:TextBox><asp:Button ID="btPost" runat="server" Text="Button" />
    </div>
</asp:Content>
