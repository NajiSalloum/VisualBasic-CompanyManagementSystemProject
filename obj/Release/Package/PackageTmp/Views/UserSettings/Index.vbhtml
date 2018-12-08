@ModelType IEnumerable(Of UserSetting)
@Code
ViewData("Title") = "Index"
End Code

<h2>Egenskaper för koppling till affärsystem</h2>
<table class="table">
    <tr>
        <th>
            @Html.Label("Användare")
        </th>
        <th>
            @Html.Label("Initialer")
        </th>
        <th>
           @Html.Label("Resues ID")
        </th>
        <th>
            @Html.Label("Restids ID")
        </th>
        <th>
            @Html.Label("Antal Km ID")
        </th>
        <th>
            @Html.Label("Övriga Kostnader ID")
        </th>
        <th>
            @Html.Label("Aktiv Konsult")
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.UserName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Initials)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.ExtResourc)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.ExtTravelTimeID)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.ExtNoOfK)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.ExtOtherExpencesID)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Active)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.UserSettingID }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.UserSettingID }) 
            
        </td>
    </tr>
Next

</table>
