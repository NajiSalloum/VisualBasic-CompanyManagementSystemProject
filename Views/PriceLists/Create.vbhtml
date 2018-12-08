@ModelType PriceList
@Code
    ViewData("Title") = "Create"
End Code
<div class="jumbotron">
    <h2>Lägg till ny prislista</h2>

    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-horizontal">

            <hr />
            @Html.ValidationSummary(True)
            <div class="form-group">
                @Html.LabelFor(Function(model) model.PriceListName, New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.PriceListName)
                    @Html.ValidationMessageFor(Function(model) model.PriceListName)
                </div>
            </div>

            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <input type="submit" value="Create" class="btn btn-primary"  />
                </div>
            </div>
        </div>
    End Using

    <div>
        @Html.ActionLink("Back to List", "Index")
    </div>
</div>