@ModelType IEnumerable(Of AllSubscriptionsView)
@Code
    ViewData("Title") = "AllSubsicriptions"
End Code

<h2>Alla abonnemang</h2>

<table class="table">
    <tr>
        <th>
            @Html.Label("Projekt")
        </th>
        <th>
            @Html.Label("Kund")
        </th>
        <th>
            @Html.Label("Inervall")
        </th>
        <th>
            @Html.Label("Registrerad av")
        </th>
        <th>
            @Html.Label("Antal Timmar")
        </th>
        <th>
            @Html.Label("Timpris")
        </th>
        <th>
            @Html.Label("Registrerad")
        </th>
        <th>
            @Html.Label("Beskrivning")
        </th>
        <th>
            @Html.Label("Nästa debitering")
        </th>
        <th>
            @Html.Label("Låst till användare")
        </th>
        <th>
            @Html.Label("Startdatum")
        </th>
        <th>
            @Html.Label("Auto deb")
        </th>
        <th>
            @Html.Label("Provision")
        </th>
        <th>
            @Html.Label("Debitera")
        </th>
        <th></th>
    </tr>
    @code
        Dim n As Integer = 1
    End Code
    @For Each item In Model

        @<tr>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Project.ProjectName)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Customer.CustName)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.PeriodType.PeriodTypeName)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.UserName)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.NoOfHours)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.PricePerHour)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.RegisteredDate)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Description)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.LastInvoiced)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.LockedToUser)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.StartDate)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.AutoDeb)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Commission)
            </td>
            @*<td>
                    @Html.CheckBox(n.ToString, False)
                </td>*@
            <td>
                @Html.CheckBox("chekboxName", New With {.id = n, .onclick = "setCompleteStatus()", .val = item.SubscriptionID})
            </td>

            <td>
                @Html.ActionLink("Ändra", "Edit", New With {.id = item.SubscriptionID}) |
                @*@Html.ActionLink("Details", "Details", New With {.id = item.PrimaryKey}) |*@
                @Html.ActionLink("Radera", "Delete", New With {.id = item.SubscriptionID})
            </td>
        </tr>
        @code
        n = n + 1
        End Code
    Next

</table>
<div class="col-md-10" ></div>
<div class="col-md-2" >@Html.ActionLink("Debitera", "AllSubsicriptions", "Subscriptions")</div>


@Section Scripts

    @Scripts.Render("~/bundles/jqueryval")
    @Scripts.Render("~/bundles/subsicriptionscheckboxes")
End Section
