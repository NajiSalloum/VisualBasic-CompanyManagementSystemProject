@ModelType IEnumerable(Of DatesView)
@Code
ViewData("Title") = "Schedule"
End Code

<h2>Tillgänglighet</h2>

<table class="table" id="tblSchudle">
    <tr>
        <th>
            @Html.Label("Konsult")
        </th>
        <th>
            @Html.Label(Date.Today)
        </th>
        <th>
            @Html.Label(Date.Today.AddDays(1))
        </th>
        <th>
            @Html.Label(Date.Today.AddDays(2))
        </th>
        <th>
            @Html.Label(Date.Today.AddDays(3))
        </th>
        <th>
            @Html.Label(Date.Today.AddDays(4))
        </th>
        <th>
            @Html.Label(Date.Today.AddDays(5))
        </th>
        <th>
            @Html.Label(Date.Today.AddDays(7))
        </th>
        <th>
            @Html.Label(Date.Today.AddDays(8))
        </th>
        <th>
            @Html.Label(Date.Today.AddDays(9))
        </th>
        <th>
            @Html.Label(Date.Today.AddDays(10))
        </th>
        <th>
            @Html.Label(Date.Today.AddDays(11))
        </th>
        <th>
            @Html.Label(Date.Today.AddDays(12))
        </th>
        <th>
            @Html.Label(Date.Today.AddDays(13))
        </th>
        <th>
            @Html.Label(Date.Today.AddDays(14))
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            <strong >@Html.DisplayFor(Function(modelItem) item.UserName)</strong>
        </td>
         <td>
             @Html.DisplayFor(Function(modelItem) item.ResourceEvent0)
         </td>
         <td>
             @Html.DisplayFor(Function(modelItem) item.ResourceEvent1)
         </td>

         <td>
             @Html.DisplayFor(Function(modelItem) item.ResourceEvent2)
         </td>
         <td>
             @Html.DisplayFor(Function(modelItem) item.ResourceEvent3)
         </td>
         <td>
             @Html.DisplayFor(Function(modelItem) item.ResourceEvent4)
         </td>
         <td>
             @Html.DisplayFor(Function(modelItem) item.ResourceEvent5)
         </td>
         <td>
             @Html.DisplayFor(Function(modelItem) item.ResourceEvent6)
         </td>
         <td>
             @Html.DisplayFor(Function(modelItem) item.ResourceEvent7)
         </td>
         <td>
             @Html.DisplayFor(Function(modelItem) item.ResourceEvent8)
         </td>
         <td>
             @Html.DisplayFor(Function(modelItem) item.ResourceEvent9)
         </td>
         <td>
             @Html.DisplayFor(Function(modelItem) item.ResourceEvent10)
         </td>
         <td>
             @Html.DisplayFor(Function(modelItem) item.ResourceEvent11)
         </td>
         <td>
             @Html.DisplayFor(Function(modelItem) item.ResourceEvent12)
         </td>
         <td>
             @Html.DisplayFor(Function(modelItem) item.ResourceEvent13)
         </td>
         
        <td>
            @*@Html.ActionLink("Edit", "Edit", New With {.id = item.PrimaryKey}) |
            @Html.ActionLink("Details", "Details", New With {.id = item.PrimaryKey}) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.PrimaryKey})*@
        </td>
    </tr>
Next

</table>
@Html.ActionLink("DEb", "DebitLinePerMonth", "DebitLines", New With {.year = "2018", .month = "9"}, Nothing)<br />
@Html.ActionLink("DEbKund", "DebitLinePerCustomer", "DebitLines", New With {.year = "2018", .month = "9"}, Nothing)


