Imports System.Web.Optimization

Public Module BundleConfig
    ' For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
    Public Sub RegisterBundles(ByVal bundles As BundleCollection)

        bundles.Add(New ScriptBundle("~/bundles/jdatetogetoverview").Include(
              "~/Scripts/JDateToGetOverview.js"))


        bundles.Add(New ScriptBundle("~/bundles/subscriptionvalidations").Include(
                 "~/Scripts/SubscriptionValidations.js"))

        bundles.Add(New ScriptBundle("~/bundles/registerdebitLineprojectvalidations").Include(
                  "~/Scripts/RegisterDebitLineProjectValidations.js"))
        bundles.Add(New ScriptBundle("~/bundles/editpartnervalidations").Include(
                  "~/Scripts/EditPartnerValidations.js"))

        bundles.Add(New ScriptBundle("~/bundles/subsicriptionscheckboxes").Include(
                  "~/Scripts/SubsicriptionsCheckBoxes.js"))

        bundles.Add(New ScriptBundle("~/bundles/partnervalidations").Include(
                  "~/Scripts/PartnerValidations.js"))
        bundles.Add(New ScriptBundle("~/bundles/dropdownlistvalidations").Include(
                  "~/Scripts/DropdownListValidations.js"))

        bundles.Add(New ScriptBundle("~/bundles/uniqueusername").Include(
                  "~/Scripts/UniqueUserName.js"))
        bundles.Add(New ScriptBundle("~/bundles/uniquecompanyname").Include(
                   "~/Scripts/UniqueCompanyname.js"))
        bundles.Add(New ScriptBundle("~/bundles/partnerlevelcheckbox").Include(
                   "~/Scripts/PartnerLevelCheckBox.js"))








        bundles.Add(New ScriptBundle("~/bundles/jquery").Include(
                    "~/Scripts/jquery-{version}.js"))

        bundles.Add(New ScriptBundle("~/bundles/jqueryval").Include(
                    "~/Scripts/jquery.validate*"))

        ' Use the development version of Modernizr to develop with and learn from. Then, when you're
        ' ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
        bundles.Add(New ScriptBundle("~/bundles/modernizr").Include(
                    "~/Scripts/modernizr-*"))

        bundles.Add(New ScriptBundle("~/bundles/bootstrap").Include(
                  "~/Scripts/bootstrap.js",
                  "~/Scripts/respond.js"))

        bundles.Add(New StyleBundle("~/Content/css").Include(
                  "~/Content/bootstrap.css",
                  "~/Content/site.css"))
    End Sub
End Module

