<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<NerdDinner2.Models.Dinner>" %>

<% if (Request.IsAuthenticated) { %>
        <% if (Model.IsUserRegistered(Context.User.Identity.Name)) { %>
            <p>
                You are registered for this event! :)
            </p>
        <% } %>
        <% else { %>

            <div id="rsvpmsg">
               <a id="RSVP" href="#">RSVP to dinner</a>
            </div>
    
            <script type="text/javascript">

                function AnimateRSVPMessage() {
                    $("#rsvpmsg").animate({ fontSize: "1.5em" }, 400);
                }

                $('#RSVP').click(
                    function () {
                        $('#rsvpmsg').load("/RSVP/Register/<%=Model.DinnerID%>");
                        AnimateRSVPMessage();
                    }
                );

            </script>
           <%-- = Ajax.ActionLink("RSVP to dinner", "Register", "RSVP", new { id = Model.DinnerID }, new AjaxOptions { UpdateTargetId = "rsvpmsg" }) --%>
        <% } %>
    <% } %>
    <% else { %>
        <a href="/Account/Logon">Logon</a> to RSVP for this event.
    <% } %>

