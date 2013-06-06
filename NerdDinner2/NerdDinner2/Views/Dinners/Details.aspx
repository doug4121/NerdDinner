<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<NerdDinner2.Models.Dinner>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
<script src="/Scripts/MicrosoftAjax.js" type="text/javascript"></script>
<script src="/Scripts/MicrosoftMvcAjax.js" type="text/javascript"></script>
<script src="/Scripts/jquery-1.7.1.js" type="text/javascript"></script>

<h2><% =Html.Encode(Model.Title) %></h2>

    <p>
        <strong>When:</strong>
        <% =Model.EventDate.ToShortDateString() %>
        
        <strong>@</strong>
        <% =Model.EventDate.ToShortTimeString() %>
    </p>
    <p>
        <strong>Where:</strong>
        <% =Html.Encode(Model.Address) %>,
        <% =Html.Encode(Model.Country) %>
    </p>
    <p>
        <strong>Description:</strong>
        <% =Html.Encode(Model.Description) %>
    </p>
    <p>
        <strong>Organizer</strong>
        <% =Html.Encode(Model.HostedBy) %>
        (<% =Html.Encode(Model.ContactPhone) %>)
    </p>
    
    <% Html.RenderPartial("RSVPStatus"); %>

    <% Html.RenderPartial("EditAndDeleteLinks"); %>

</asp:Content>
