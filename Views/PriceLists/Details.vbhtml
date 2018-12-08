@ModelType PriceList
@Code
    ViewData("Title") = "Details"
End Code
<div class="jumbotron">
    <h2>Detaljer</h2>

    <div>

        <hr />
        <dl class="dl-horizontal">
            <dt>
                @Html.Label("Prislista namn")
            </dt>

            <dd>
                @Html.DisplayFor(Function(model) model.PriceListName)
            </dd>

        </dl>
    </div>
    <p>
        @Html.ActionLink("Redigera", "Edit", New With {.id = Model.PriceListID}) |
        @Html.ActionLink("Back to List", "Index")
    </p>
</div>