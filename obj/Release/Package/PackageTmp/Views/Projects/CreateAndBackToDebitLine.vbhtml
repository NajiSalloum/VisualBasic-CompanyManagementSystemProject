@ModelType Project
@Code
    ViewData("Title") = "Create"
End Code
<div class="jumbotron">
    <h2>Lägg till nytt projekt</h2>

    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-horizontal">

            <hr />
            @Html.ValidationSummary(True)
            <div class="form-group">
                @Html.Label("Projekt", New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.ProjectName)
                    @Html.ValidationMessageFor(Function(model) model.ProjectName)
                </div>
            </div>

            <div class="form-group" id="PartnerDropdownList">
                @Html.Label("Kund", htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.DropDownListFor(Function(model) model.CustomerID, DirectCast(ViewData("Customers"), IEnumerable(Of SelectListItem)), New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(model) model.CustomerID, "", New With {.class = "text-danger"})
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
        @Html.ActionLink("Back to List", "Index")
    </div>
</div>