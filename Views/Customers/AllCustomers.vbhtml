@ModelType  AllCustomersAndDebitLinesOverView
@Code
    ViewData("Title") = "AllCustomers"
End Code
@code
    If User.IsInRole("Konsult") Then
End Code
<h2>Översikt</h2>
<div class="navbar-right"  >
    @Using (Html.BeginForm("AllCustomers", "Customers", FormMethod.Get))
        @<div class="form-inline">
            <ul class="nav navbar">
                <li>@Html.TextBox("DateToGetoverview", "", New With {.Value = ViewData("InitialDate"), .class = "form-control datepicker"})<input type="submit" value="Hämta" class="btn btn-primary" /></li>

            </ul>
        </div>
        End Using
</div>



<table class="table" id="detbit">
    <tr>


        <th>
            @Html.Label("Kund")
        </th>
        <th>
            @Html.Label("Antal timmar")
        </th>
        <th>
            @Html.Label("Restid")
        </th>
        <th>
            @Html.Label("Antal Km")
        </th>
        <th>
            @Html.Label("Övriga utlägg")
        </th>
        <th>
            @Html.Label("Projekt")
        </th>
        <th>
            @Html.Label("Beskrivning")
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
        <th>
            @Html.Label("Total")
        </th>

        <th></th>
    </tr>

    @For Each item In Model.DebitLines
        @<tr>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Customer.CustName)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.NoOfHours)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.NoOfTravelHours)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.NoOfKm)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.OtherExpences)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Project.ProjectName)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Description)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.PricePerHoure)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.TravelPrice)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.PricePerKm)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Comission)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.LineTotal)   kr
            </td>

            <td>
                @*@Html.ActionLink("Edit", "Edit", New With {.id = item.PrimaryKey}) |
                    @Html.ActionLink("Details", "Details", New With {.id = item.PrimaryKey}) |*@
                @Html.ActionLink("Radera", "Delete", "DebitLines", New With {.id = item.LineID}, Nothing)
            </td>
        </tr>
        Next

</table>
<div class="alert alert-success">
    Total debiterat för  <strong>@ViewBag.theDate</strong>   är   <strong>@ViewBag.totalDebiterat</strong>   kr
</div>

@code
End If

End Code





@code
    If User.IsInRole("Admin") Then
End Code
<h2>Alla Kunder</h2>
<p>
    @Html.ActionLink("Lägg till ny kund", "Create")
</p>

@code

End If

End Code

<div class="navbar-right">
    @Using (Html.BeginForm("AllCustomers", "Customers", FormMethod.Get))
        @<div class="form-inline">
            <ul class="nav navbar">
                <li>@Html.TextBox("SearchName", "", New With {.Placeholder = "Skriv här för att söka"}) <input type="submit" value="Sök" class="btn btn-primary" /></li>

            </ul>
        </div>
    End Using
</div>


<table class="table" id="page">
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

    @For Each item In Model.AllCustomers
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
                @Html.ActionLink("Detaljer", "Details", New With {.id = item.CustID}) |
                @code
                If Context.User.IsInRole("Konsult") Then
                    @Html.ActionLink("Registera arbetad tid", "Create", "DebitLines", New With {.id = item.CustID}, Nothing)
                End If
                End Code
                @code
                If Context.User.IsInRole("Admin") Then
                End Code
                    @Html.ActionLink("Ändra", "Edit", New With {.id = item.CustID}) |
                @Code
                End If
                End Code

                



                @code
                If Context.User.IsInRole("Admin") Then
                    @Html.ActionLink("Radera", "Delete", New With {.id = item.CustID})
                End If
                End Code





            </td>
        </tr>
    Next

</table>
<div class="col-md-10"></div>
<div class="col-md-2">
    @code
        If GlobalVariables.countOfCustomers >= GlobalVariables.num Then
            @Html.ActionLink("Visa fler", "AllCustomers", "Customers", New With {.n = 4}, Nothing)

        End If


    End Code
    
</div>
<br/>
<hr/>
<table class="table" id="SubTable">
    <tr>
        <th>
            @Html.Label("Abonnemang")
        </th>
        
        <th>
            @Html.Label("Kund")
        </th>
        
        <th>
            @Html.Label("Projekt")
        </th>
        <th>
            @Html.Label("Internalkund?")
        </th>
        <th>
            @Html.Label("Antal Timmar")
        </th>
        <th>
            @Html.Label("Timpris")
        </th>
        <th>
            @Html.Label("Beskrivning")
        </th>
        <th>
            @Html.Label("Användarlåst")
        </th>
        <th>
            @Html.Label("Aktuell från")
        </th>
        <th>
            @Html.Label("Provision")
        </th>
        <th>
            @Html.Label("Auto deb")
        </th>
        <th></th>
    </tr>
    @code
        Dim n As Integer = 1
    End Code
    @For Each item In Model.AllSubscriptions

        @<tr>
             <td>
                 @Html.DisplayFor(Function(modelItem) item.Project.ProjectName)
             </td>
                        <td>
                @Html.DisplayFor(Function(modelItem) item.Customer.CustName)
            </td>
             
             <td>
                 @Html.DisplayFor(Function(modelItem) item.Project.ProjectName)
             </td>
             <td>
                 @Html.DisplayFor(Function(modelItem) item.InternalCustomer)
             </td>

            
            <td>
                @Html.DisplayFor(Function(modelItem) item.NoOfHours)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.PricePerHour)
            </td>
                        <td>
                @Html.DisplayFor(Function(modelItem) item.Description)
            </td>
            
            <td>
                @Html.DisplayFor(Function(modelItem) item.LockedToUser)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.StartDate)
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
                @Html.ActionLink("Ändra", "Edit", "Subscriptions", New With {.id = item.SubscriptionID}, Nothing) |
                @*@Html.ActionLink("Details", "Details", New With {.id = item.PrimaryKey}) |*@
                @Html.ActionLink("Radera", "Delete", "Subscriptions", New With {.id = item.SubscriptionID}, Nothing)
            </td>
        </tr>
        @code
        n = n + 1
        End Code
    Next

</table>


<div class="col-md-10"></div>
<div class="col-md-2">@Html.ActionLink("Debitera", "AllCustomers", "Customers")</div>
@Section Scripts

    @Scripts.Render("~/bundles/jqueryval")
    @Scripts.Render("~/bundles/subsicriptionscheckboxes")
@Scripts.Render("~/bundles/jdatetogetoverview")
End Section
