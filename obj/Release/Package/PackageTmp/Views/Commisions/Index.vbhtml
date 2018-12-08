@ModelType IEnumerable(Of ComisionsView)
@Code
    ViewData("Title") = "Index"
End Code

<h2>Rapport selektering</h2>

<div class="navbar-left" >
    @Using (Html.BeginForm("Index", "Commisions", FormMethod.Get))
        @<div class="form-inline">
            <ul class="nav navbar">
                <li>@Html.DropDownList("years", Nothing, New With {.class = "form-control"})@Html.DropDownList("months", Nothing, New With {.class = "form-control"})
                    <input type="submit" value="Visa" class="btn btn-primary" />
                </li>
                
                
            </ul>
        </div>
    End Using
</div>

<table class="table">
    <tr>

        <th>
            @Html.Label("Användare")
        </th>
        <th>
            @Html.Label("Kund")
        </th>
        <th>
            @Html.Label("Antal timmar")
        </th>
        <th>
            @Html.Label("Projekt")
        </th>
        <th>
            @Html.Label("Beskrivning")
        </th>
        <th>
            @Html.Label("Registrerad")
        </th>
        <th>
            @Html.Label("Timpris")
        </th>
        <th>
            @Html.Label("Provision i %")
        </th>
        <th>
            @Html.Label("Provision")
        </th>
        <th></th>
    </tr>

    @For Each item In Model
        @<tr>

            <td>
                @Html.DisplayFor(Function(modelItem) item.UserName)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Customer.CustName)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.NoOfHours)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Project.ProjectName)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Description)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Regesterad)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.PricePerHoure)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Comission)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.ComissionBased)
            </td>
            <td>
                @*@Html.ActionLink("Edit", "Edit", New With {.id = item.PrimaryKey}) |
                    @Html.ActionLink("Details", "Details", New With {.id = item.PrimaryKey}) |
                    @Html.ActionLink("Delete", "Delete", New With {.id = item.PrimaryKey})*@
            </td>
        </tr>
    Next

</table>
