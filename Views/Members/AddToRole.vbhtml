@ModelType UserRoleView
@Code
    ViewData("Title") = "AddToRole"
End Code

    <h2>Lägg till roll</h2>

    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-horizontal">
            
            
            @Html.ValidationSummary(True)
            @Html.HiddenFor(Function(model) model.Id)

            <div class="form-group">
                @Html.Label("Användarnamn", New With {.class = "col-md-2 control-label"})
                <div class="col-md-10">
                    @Html.DisplayFor(Function(model) model.UserName)
                    @Html.ValidationMessageFor(Function(model) model.UserName)
                </div>
            </div>
            @Code
            Dim roles As New List(Of SelectListItem)()
            If Model.Kind = 1 Then
            roles.Add(New SelectListItem() With
             {
             .Text = "Konsult",
             .Value = 2
             })

            Else

            roles.Add(New SelectListItem() With
                              {
                              .Text = "Admin",
                              .Value = 1
                              })
            End If



            End Code


            <div class="form-group">
                @Html.Label("Roll", New With {.class = "col-md-2 control-label"})
                <div class="col-md-10">
                    @Html.DropDownListFor(Function(model) model.Kind, roles, New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(model) model.Kind, "", New With {.class = "text-danger"})
                </div>
            </div>


            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <input type="submit" value="Lägg till" class="btn btn-primary"   />
                </div>
            </div>
        </div>
    End Using

    <div>
        @Html.ActionLink("Tillbaka", "AllUsers")
    </div>