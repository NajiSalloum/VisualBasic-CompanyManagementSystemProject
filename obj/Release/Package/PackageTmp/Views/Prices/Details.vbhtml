@ModelType Price
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>Price</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.PriceList.PriceListName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PriceList.PriceListName)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.User.UserName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.User.UserName)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.PricePerHour)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PricePerHour)
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
            @Html.DisplayNameFor(Function(model) model.Commission)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Commission)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.PriceID }) |
    @Html.ActionLink("Back to List", "Index")
</p>
