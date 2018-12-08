@ModelType DebitLine
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>DebitLine</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Customer.ExtCustID)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Customer.ExtCustID)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Project.ProjectName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Project.ProjectName)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DebDate)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DebDate)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.UserName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.UserName)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.NoOfHours)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.NoOfHours)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.NoOfTravelHours)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.NoOfTravelHours)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.NoOfKm)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.NoOfKm)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.OtherExpences)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.OtherExpences)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Description)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Description)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Invoiced)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Invoiced)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Regesterad)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Regesterad)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.PricePerHoure)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PricePerHoure)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.TravelPrice)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.TravelPrice)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.PricePerKm)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PricePerKm)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Status)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Status)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Comission)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Comission)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Subscription)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Subscription)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.CompanyCar)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CompanyCar)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.LineID }) |
    @Html.ActionLink("Back to List", "Index")
</p>
