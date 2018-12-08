@ModelType IEnumerable(Of AllPricesView)
@Code
    ViewData("Title") = "AllPrices"
End Code

<h2>Alla registrerade prislistor</h2>

<p>
    @Html.ActionLink("Registrera", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.Label("Prislista")
        </th>
        <th>
            @Html.Label("Användarnamn")
        </th>
        <th>
            @Html.Label("Timpris")
        </th>
        <th>
            @Html.Label("Timpris resa")
        </th>
        <th>
            @Html.Label("Km pris")
        </th>
        <th>
            @Html.Label("Provision")
        </th>
        <th></th>
    </tr>

    @For Each item In Model
        @<tr>

            <td>
                @Html.DisplayFor(Function(modelItem) item.PriceList.PriceListName)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.User.UserName)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.PricePerHour)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.TravelPrice)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.PricePerKm)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Commission)
            </td>
            <td>
                @*@Html.ActionLink("edit", "edit", New With {.id = item.primarykey}) |
                @Html.ActionLink("details", "details", New With {.id = item.primarykey}) |*@
                @Html.ActionLink("Radera", "delete", New With {.id = item.PriceID})
            </td>
        </tr>
    Next

</table>
