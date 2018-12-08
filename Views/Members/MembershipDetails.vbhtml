@ModelType BitLogTimeProject.Membership
    @Code
        ViewData("Title") = "MembershipDetails"
    End Code
        <h2>Användare detaljer</h2>

        <div>

            
            <dl class="dl-horizontal">

                <dt>
                    @Html.Label("Användarnamn")
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.UserName)
                </dd>

                <dt>
                    @Html.Label("Resistrerings datum")
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.CreateDate)
                </dd>

                <dt>
                    @Html.Label("Senaste inloggad")
                </dt>

                <dd>
                    
                    @Html.DisplayFor(Function(model) model.LastLoginDate)
                </dd>

                <dt>
                    @Html.Label("Senaste ändring av lösenord")
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.PasswordChangedDate)
                </dd>

            </dl>
        </div>
        <p>

            @Html.ActionLink("Back to List", "AllUsers")
        </p>
   