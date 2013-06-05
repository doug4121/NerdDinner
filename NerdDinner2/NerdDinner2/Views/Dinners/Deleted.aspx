<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Dinner Deleted
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Dinner Deleted</h2>
    
    <div>
        <p>Your dinner was successfully deleted.</p>
    </div>
    
    <div>
        <p>
            <a href="/Dinners">Click for Upcoming Dinners</a>
        </p>
    </div>

</asp:Content>
