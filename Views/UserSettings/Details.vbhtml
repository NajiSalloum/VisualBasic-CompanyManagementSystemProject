@ModelType UserSetting
@Code
    ViewData("Title") = "Details"
End Code

<h2>Detaljer</h2>

<div>
    
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.Label("Användare")
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.UserName)
        </dd>

        <dt>
            @Html.Label("Initialer")
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Initials)
        </dd>

        <dt>
            @Html.Label("Resues ID")
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ExtResourc)
        </dd>

        <dt>
            @Html.Label("Restids ID")
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ExtTravelTimeID)
        </dd>

        <dt>
            @Html.Label("Antal Km ID")
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ExtNoOfK)
        </dd>

        <dt>
            @Html.Label("Övriga Kostnader ID")
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ExtOtherExpencesID)
        </dd>

        <dt>
            @Html.Label("Aktiv Konsult")
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Active)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Ändra", "Edit", New With {.id = Model.UserSettingID}) |
    @Html.ActionLink("Tillbaka", "Index")
</p>
