@ModelType IEnumerable(Of PriceList)
@Code
    ViewData("Title") = "Index"
End Code
<div class="jumbotron">
    <h2>Prislistor</h2>

    <p>
        @Html.ActionLink("Lägg till ny prislista", "Create")
    </p>
    <table class="table">
        <tr>
            <th>
                @Html.Label("Prislista Namn")
            </th>
            <th></th>
        </tr>

        @For Each item In Model
            @<tr>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.PriceListName)
                </td>
                <td>
                    @Html.ActionLink("Ändra", "Edit", New With {.id = item.PriceListID}) |
                    @Html.ActionLink("Detaljer", "Details", New With {.id = item.PriceListID}) |
                    @Html.ActionLink("Radera", "Delete", New With {.id = item.PriceListID})
                </td>
            </tr>
        Next

    </table>
</div>