@ModelType Subscription
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>Subscription</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Customer.ExtCustID)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Customer.ExtCustID)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.PeriodType.PeriodTypeName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PeriodType.PeriodTypeName)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Project.ProjectName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Project.ProjectName)
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
            @Html.DisplayNameFor(Function(model) model.PricePerHour)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PricePerHour)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.RegisteredDate)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.RegisteredDate)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Description)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Description)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.LastInvoiced)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.LastInvoiced)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.LockedToUser)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.LockedToUser)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.StartDate)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.StartDate)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.AutoDeb)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.AutoDeb)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Commission)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Commission)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.SubscriptionID }) |
    @Html.ActionLink("Back to List", "Index")
</p>
