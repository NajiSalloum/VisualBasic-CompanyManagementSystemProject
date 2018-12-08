@ModelType CreateAndAllSourceEventLinesView
@Code
    ViewData("Title") = "Create"
End Code

<h2>Registrera tillgänglighet</h2>

@Using (Html.BeginForm()) 
    @Html.AntiForgeryToken()
    
    @<div class="form-horizontal">
        
        <hr />
        @Html.ValidationSummary(true)
        @*<div class="form-group">
            @Html.LabelFor(Function(model) model.UserID, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.UserID)
                @Html.ValidationMessageFor(Function(model) model.UserID)
            </div>
        </div>*@
         <div class="form-group">
             @Html.Label("Datum:", New With {.class = "control-label col-md-2"})
             <div class="col-md-10">
                 
                 @Html.TextBoxFor(Function(model) model.ResourceEventLine.EventDate, New With {.class = "form-control datepicker"})
                 @Html.ValidationMessageFor(Function(model) model.ResourceEventLine.EventDate)
             </div>
         </div>

         <div class="form-group" id="CustomersDropdownList">
             @Html.Label("Användarnamn:", htmlAttributes:=New With {.class = "control-label col-md-2"})
             <div class="col-md-10">
                 @Html.DropDownListFor(Function(model) model.ResourceEventLine.UserName, DirectCast(ViewData("Users"), IEnumerable(Of SelectListItem)), New With {.class = "form-control"})
                 @Html.ValidationMessageFor(Function(model) model.ResourceEventLine.UserName, "", New With {.class = "text-danger"})
             </div>
         </div>

        @*<div class="form-group">
            @Html.LabelFor(Function(model) model.EventDate, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.EventDate)
                @Html.ValidationMessageFor(Function(model) model.EventDate)
            </div>
        </div>*@

        @*<div class="form-group">
            @Html.LabelFor(Function(model) model.ResourceEventID, "ResourceEventID", New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.DropDownList("ResourceEventID", String.Empty)
                @Html.ValidationMessageFor(Function(model) model.ResourceEventID)
            </div>
        </div>*@
         <div class="form-group" id="CustomersDropdownList">
             @Html.Label("Händelse:", htmlAttributes:=New With {.class = "control-label col-md-2"})
             <div class="col-md-10">
                 @Html.DropDownListFor(Function(model) model.ResourceEventLine.ResourceEventID, DirectCast(ViewData("Events"), IEnumerable(Of SelectListItem)), New With {.class = "form-control"})
                 @Html.ValidationMessageFor(Function(model) model.ResourceEventLine.ResourceEventID, "", New With {.class = "text-danger"})
             </div>
         </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Registrera" class="btn btn-primary"  />
            </div>
        </div>
    </div>
End Using


<table class="table">
    <tr>
        <th>
            @Html.Label("Datum")
        </th>
        <th>
            @Html.Label("Användarnamn")
        </th>

        <th>
            @Html.Label("Händelse")
        </th>
        <th></th>
    </tr>

    @For Each item In Model.AllRecourseEventLines 
        @<tr>
            <td>
                @Html.DisplayFor(Function(modelItem) item.EventDate)
            </td>

            <td>
                @Html.DisplayFor(Function(modelItem) item.UserName)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.ResourceEventName)
            </td>
            <td>
                @*@Html.ActionLink("Edit", "Edit", New With {.id = item.PrimaryKey}) |
                    @Html.ActionLink("Details", "Details", New With {.id = item.PrimaryKey}) |*@
                @Html.ActionLink("Radera", "Delete", New With {.id = item.RecourseEventLineID})
            </td>
        </tr>
    Next

</table>


@Section Scripts

    @Scripts.Render("~/bundles/jqueryval")
    @Scripts.Render("~/bundles/jdatetogetoverview")
End Section
