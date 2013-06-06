﻿<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<NerdDinner2.Models.Dinner>" %>

<% if (Model.IsHostedBy(Context.User.Identity.Name)) { %>
        <% = Html.ActionLink("Edit Dinner", "Edit", new { id=Model.DinnerID }) %> |
        <% = Html.ActionLink("Delete Dinner", "Delete", new { id=Model.DinnerID}) %>
    <% } %>