<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistreerUser.aspx.cs" Inherits="lastfmWeb.RegistreerUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Welkom nieuwe gebruiker!</h1>



    </div>
    <table style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="* Gebruikersnaam: "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbGebruikersnaam" runat="server" width="250px"></asp:TextBox></td>
            <asp:RequiredFieldValidator runat="server" id="reqName" controltovalidate="tbGebruikersnaam" errormessage="Vul een naam in" />
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="* Wachtwoord: "></asp:Label>

            </td>
            <td>
                <input id="tbPassword" runat="server" type="password"  width="250px" />
                                <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator1" controltovalidate="tbPassword" errormessage="Vul een wachtwoord in"  />

            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="* Geboortedatum: "></asp:Label>
               
            </td>
            <td>
                <asp:Calendar ID="calGeboortedatum" runat="server" SelectionMode="DayWeek"></asp:Calendar>

            </td>
        </tr>
                <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Woonplaats"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbWoonplaats" runat="server" width="250px"></asp:TextBox></td>
        </tr>
                <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Straat"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbStraat" runat="server" width="250px"></asp:TextBox></td>
        </tr>
                <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Huisnummer"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbHuisnummer" runat="server" width="250px"></asp:TextBox></td>
        </tr>
                <tr>
            <td>
                <asp:Label ID="Label7" runat="server" Text="Postcode"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbPostcode" runat="server" width="250px"></asp:TextBox></td>
        </tr>
                <tr>
            <td>
                <asp:Label ID="Label8" runat="server" Text="Land"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbLand" runat="server" width="250px"></asp:TextBox></td>
        </tr>
          <tr>
        
              
            <td>
            </td>
            <td>
                <asp:Button ID="btGo" runat="server" Text="Registreer" OnClick="btGo_Click" /> </td>
        </tr>
    </table>

</asp:Content>
