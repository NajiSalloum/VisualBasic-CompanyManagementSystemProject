@ModelType IEnumerable(Of RecourseEventLine)
@Code
ViewData("Title") = "Index"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.ResourceEvent.EventName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.UserID)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.UserName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.EventDate)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.ResourceEvent.EventName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.UserID)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.UserName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.EventDate)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.RecourseEventLineID }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.RecourseEventLineID }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.RecourseEventLineID })
        </td>
    </tr>
Next

</table>
