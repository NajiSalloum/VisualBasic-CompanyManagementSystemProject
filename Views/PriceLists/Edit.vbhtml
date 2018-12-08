@ModelType PriceList
@Code
    ViewData("Title") = "Edit"
End Code
<div class="jumbotron">
    <h2>Redigera</h2>

    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-horizontal">
            
            <hr />
            @Html.ValidationSummary(True)
            @Html.HiddenFor(Function(model) model.PriceListID)

            <div class="form-group">
                @Html.Label("Prislista namn")
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.PriceListName)
                    @Html.ValidationMessageFor(Function(model) model.PriceListName)
                </div>
            </div>

            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <input type="submit" value="Save" class="btn btn-success"  />
                </div>
            </div>
        </div>
    End Using

    <div>
        @Html.ActionLink("Back to List", "Index")
    </div>
</div>