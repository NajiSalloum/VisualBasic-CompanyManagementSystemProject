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
            @Html.LabelFor(Function(model) model.CustomerID, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DropDownListFor(Function(model) model.CustomerID, DirectCast(ViewData("Customers"), IEnumerable(Of SelectListItem)), New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.CustomerID, "", New With {.class = "text-danger"})
            </div>
        </div>
        @*<div class="form-group">
                @Html.LabelFor(Function(model) model.ProjectName, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.DropDownListFor(Function(model) model.ProjectName, DirectCast(ViewData("Projects"), IEnumerable(Of SelectListItem)), New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(model) model.ProjectName, "", New With {.class = "text-danger"})
                </div>
            </div>*@
        <div class="form-group">
            @Html.Label("Projects:", New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DropDownListFor(Function(model) model.ProjectName, DirectCast(ViewData("Projects"), IEnumerable(Of SelectListItem)), New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.ProjectID, "", New With {.class = "text-danger"})
            </div>
        </div>


        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Create" class="btn btn-primary" />
            </div>
        </div>
    </div>
End Using

<div>
    @Html.ActionLink("Backa", "Create", "Subscriptions", New With {.id = Url.RequestContext.RouteData.Values("id")}, Nothing)
</div>
