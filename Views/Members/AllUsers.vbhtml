@ModelType IEnumerable(Of AllUsersView)
@Code
    ViewData("Title") = "AllUsers"
End Code

    <h2>Alla användare</h2>

    <p>
        @Html.ActionLink("Registrera ny användare", "RegisterMember")
    </p>
    <table class="table">
        <tr>
            <th>
                @Html.Label("Användarnamn")
            </th>
            <th>
                @Html.Label("Roll")
            </th>
            <th></th>
        </tr>

        @For Each item In Model
            @<tr>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.UserName)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Role)
                </td>
                <td>

                    @Html.ActionLink("Detaljer", "MembershipDetails", New With {.id = item.Id}) |
                    @Html.ActionLink("Radera", "Delete", New With {.id = item.Id}) |
                    @code
                    If item.Role = "Admin" Or item.Role = "Konsult" Then
                    @Html.ActionLink("Lägg till roll", "AddToRole", New With {.id = item.Id})
                    End If
                    End Code
                    
                </td>
            </tr>
        Next

    </table>