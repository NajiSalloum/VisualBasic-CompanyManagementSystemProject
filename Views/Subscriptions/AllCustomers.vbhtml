@ModelType IEnumerable(Of AllCustomersView)
@Code
    ViewData("Title") = "AllCustomers"
End Code
    <h2>Alla Kunder</h2>

    
    <div class="navbar-right">
        @Using (Html.BeginForm("AllCustomers", "Subscriptions", FormMethod.Get))
            @<div class="form-inline">
                <ul class="nav navbar">
                    <li>@Html.TextBox("SearchName", "", New With {.Placeholder = "Skriv här för att söka"}) <input type="submit" value="Sök" class="btn btn-primary" /></li>

                </ul>
            </div>
        End Using
    </div>


    <table class="table" id="custTable">
    <tr>
        <th>
            @Html.Label("Kund namn")
        </th>
        <th>
            @Html.Label("Referens")
        </th>
        <th>
            @Html.Label("Prislista")
        </th>
        <th>
            @Html.Label("Internalkund?")
        </th>
        <th></th>
    </tr>

    @For Each item In Model
        @<tr>
            <td>
                @Html.DisplayFor(Function(modelItem) item.CustName)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.CustRef)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.PriceList.PriceListName)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.IinternalCustomer)
            </td>
            <td>
                @Html.ActionLink("Detaljer", "Details", "Customers", New With {.id = item.CustID}, Nothing) |
                @code
                If Context.User.IsInRole("Konsult") Then
                    @Html.ActionLink("Lägg till", "Create", "Subscriptions", New With {.id = item.CustID}, Nothing)
                End If
                End Code
                @code
                If Context.User.IsInRole("Admin") Then
                    @Html.ActionLink("Ändra", "Edit", New With {.id = item.CustID})
                End If
                End Code

                |



                @code
                If Context.User.IsInRole("Admin") Then
                    @Html.ActionLink("Radera", "Delete", New With {.id = item.CustID})
                End If
                End Code





            </td>
        </tr>
    Next

</table>

