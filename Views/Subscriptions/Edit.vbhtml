﻿@ModelType Subscription
@Code
    ViewData("Title") = "Edit"
End Code

<h2>Ändra</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
        @Html.ValidationSummary(True)
        @Html.HiddenFor(Function(model) model.SubscriptionID)
        <div class="form-group">
            @Html.Label("Kund Name:", New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DropDownListFor(Function(model) model.CustomerID, DirectCast(ViewData("Customers"), IEnumerable(Of SelectListItem)), New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.CustomerID, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.Label("Start datum:", New With {.class = "control-label col-md-2"})
            <div class="col-md-10">

                @Html.TextBoxFor(Function(model) model.StartDate, New With {.class = "form-control datepicker"})
                @Html.ValidationMessageFor(Function(model) model.StartDate)
            </div>
        </div>
        <div class="form-group">
            @Html.Label("Intervall:", New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DropDownListFor(Function(model) model.PeriodTypeID, DirectCast(ViewData("PeriodTypes"), IEnumerable(Of SelectListItem)), New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.PeriodTypeID, "", New With {.class = "text-danger"})
            </div>
        </div>
     <div class="form-group">
            @Html.Label("Projekt:", New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DropDownListFor(Function(model) model.ProjectID, DirectCast(ViewData("Projects"), IEnumerable(Of SelectListItem)), New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.ProjectID, "", New With {.class = "text-danger"})
                <span id="TextErrorMessage" class="text-danger hidden">Inget Projekt kopplat till kunden!!!</span>
            </div>
        </div>

        <div class="form-group hidden">
            @Html.LabelFor(Function(model) model.UserName, New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.UserName)
                @Html.ValidationMessageFor(Function(model) model.UserName)
            </div>
        </div>

        <div class="form-group">
            @Html.Label("Antal timmar:", New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.NoOfHours)
                @Html.ValidationMessageFor(Function(model) model.NoOfHours)
            </div>
        </div>

        <div class="form-group">
            @Html.Label("Timpris", New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.PricePerHour)
                @Html.ValidationMessageFor(Function(model) model.PricePerHour)
            </div>
        </div>

        <div class="form-group hidden">
            @Html.LabelFor(Function(model) model.RegisteredDate, New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.RegisteredDate)
                @Html.ValidationMessageFor(Function(model) model.RegisteredDate)
            </div>
        </div>

        <div class="form-group">
            @Html.Label("Beskrivning", New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.TextAreaFor(Function(model) model.Description)
                @Html.ValidationMessageFor(Function(model) model.Description)
            </div>
        </div>

        <div class="form-group hidden">
            @Html.LabelFor(Function(model) model.LastInvoiced, New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.LastInvoiced)
                @Html.ValidationMessageFor(Function(model) model.LastInvoiced)
            </div>
        </div>

        <div class="form-group">
            @Html.Label("Låst till användare:", New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.LockedToUser)
                @Html.ValidationMessageFor(Function(model) model.LockedToUser)
            </div>
        </div>

        <div class="form-group hidden">
            @Html.LabelFor(Function(model) model.AutoDeb, New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.AutoDeb)
                @Html.ValidationMessageFor(Function(model) model.AutoDeb)
            </div>
        </div>

        <div class="form-group">
            @Html.Label("Provision:", New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Commission)
                @Html.ValidationMessageFor(Function(model) model.Commission)
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Spara" class="btn btn-success" />
            </div>
        </div>
    </div>
End Using

<div>
    <a href="javascript:void(0);" onclick="history.go(-1);">Tillbaka</a>
</div>
@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")

    <script type="text/javascript">
        $(function () {
            $('.datepicker').datepicker();
        });
    </script>

End Section