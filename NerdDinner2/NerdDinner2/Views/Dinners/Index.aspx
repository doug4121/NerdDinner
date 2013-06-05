<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<NerdDinner2.PaginatedList<NerdDinner2.Models.Dinner>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Upcoming Dinners
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>UpComing Dinners</h2>

<ul>
    <% foreach(var dinner in Model)
       { %>
        <li>
            <a href ="/Dinners/Details/<% =dinner.DinnerID %>">
                <% = Html.Encode(dinner.Title) %>
            </a>
            on
            <% = Html.Encode(dinner.EventDate.ToShortDateString()) %>
            @
            <% = Html.Encode(dinner.EventDate.ToShortTimeString()) %>
        </li>
    <% } %>
</ul>

    <% if (Model.HasPreviousPage) { %>
        <%=Html.RouteLink("<<<", "UpcomingDinners", new { page = (Model.PageIndex-1) }) %>
    <% } %>
    
    <% if (Model.HasNextPage) { %>
        <%=Html.RouteLink(">>>", "UpcomingDinners", new { page = (Model.PageIndex+1) }) %>
    <% } %>

</asp:Content>
