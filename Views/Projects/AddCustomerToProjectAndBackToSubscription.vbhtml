@ModelType Project
@Code
    ViewData("Title") = "AddCustomerToProject"
End Code

<h2>Lägg kund till projekt</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">

        <hr />
        @Html.ValidationSummary(True)


        <div class="form-group" id="CustomersDropdownList">
            @Html.Label("Kund namn:", htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DropDownListFor(Function(model) model.CustomerID, DirectCast(ViewData("Customers"), IEnumerable(Of SelectListItem)), New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.CustomerID, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.Label("Projekt:", New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DropDownListFor(Function(model) model.ProjectName, DirectCast(ViewData("Projects"), IEnumerable(Of SelectListItem)), New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.ProjectID, "", New With {.class = "text-danger"})
            </div>
        </div>


        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Lägg till" class="btn btn-primary" />
            </div>
        </div>
    </div>
End Using

<div>
    @Html.ActionLink("Tillbaka", "Create", "Subscriptions", New With {.id = Url.RequestContext.RouteData.Values("id")}, Nothing)
</div>
