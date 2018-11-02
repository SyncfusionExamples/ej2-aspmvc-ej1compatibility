# Syncfusion Essential JS 1 and Essential JS 2 ASP.Net MVC Compatibility

This demo purpose to avoid EJ1 & EJ2 compatibility issues.

# Solution 

The below setps help you to render EJ1 and EJ2 Syncfusion components in a single page ASP.NET MVC Application.

## Adding Application	

You can create Essential JS 1 and Essential JS 2 controls using below getting started links

* (Getting started for EJ2 ASPMVC control)[https://ej2.syncfusion.com/aspnetmvc/documentation/grid/getting-started-mvc.html] 
* (Getting started for EJ1 ASPMVC control)[https://help.syncfusion.com/aspnetmvc/grid/getting-started ]

## Style Compatibility

Add compatibility styles. We have Essential JS 1 and Essential JS 2 compatibility style which won’t affect each other.

```
<head>
    @* Syncfusion Essential JS 1 Styles *@
    @Styles.Render("https://cdn.syncfusion.com/16.1.0.24/js/web/bootstrap-theme/ej.web.all.compatibility.min.css")

    @* Syncfusion Essential JS 2 Styles *@
    @Styles.Render("https://cdn.syncfusion.com/ej2/styles/compatibility/material.css")
</head>
```

## Scripts Compatibility

Add scripts for Essential JS 1 and Essential JS 2 as below.

```
@* Syncfusion Essential JS 1 Scripts *@
<script 
src="http://cdn.syncfusion.com/js/assets/external/jquery3.3.1.min.js"></script>
<script src="http://cdn.syncfusion.com/js/assets/external/jsrender.min.js"></script>
<script src="http://cdn.syncfusion.com/16.3.0.21/js/web/ej.web.all.min.js"></script>

@* Syncfusion Essential JS 2 Scripts *@
<script src="https://cdn.syncfusion.com/ej2/dist/ej2.min.js"></script>
```

Note: Need to add ej1 script before ej2 scripts or else it will throw script error.

## Adding Compatibility

To achieve this requirement, you need to use the below code in `_Layout.cshtml` page. Because EJ1 and EJ2 has same library names to perform the different actions. So conflicts may occur when we refer this both controls in same application. To overcome this we need to extend this libraries in ej namespace.

```
<script>
    var dataCopy = Object.assign({}, ej.data);
    $.extend(ej, Syncfusion);
    $.extend(ej.data, dataCopy);
</script>
```

## Adding Script Manager 

Define Script manager for both Essential JS 1 and Essential JS 2

```
@Html.EJ().ScriptManager()
@Html.EJS().ScriptManager()
```

Finally, The Layout page looks like:
```
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    @* Syncfusion Essential JS 1 Styles *@
    @Styles.Render("http://cdn.syncfusion.com/16.3.0.21/js/web/flat-azure/ej.web.all.min.css")
    @* Syncfusion Essential JS 2 Styles *@
    @Styles.Render("https://cdn.syncfusion.com/ej2/styles/compatibility/material.css")
</head>

<body>
    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/bootstrap")
    @Scripts.Render("~/Scripts/jsrender.min.js")
    @* Syncfusion Essential JS 1 Scripts *@
    @Scripts.Render("~/Scripts/ej/web/ej.web.all.min.js")
    @* Syncfusion Essential JS 2 Scripts *@
    @Scripts.Render("~/Scripts/ej2/ej2.min.js")
    @RenderSection("scripts", required: false)

    <script>
        var dataCopy = Object.assign({}, ej.data);
        $.extend(ej, Syncfusion);
        $.extend(ej.data, dataCopy);
    </script>
     
    @Html.EJ().ScriptManager()
    @Html.EJS().ScriptManager()

    <div class="container body-content">
        @RenderBody()
    </div>

</body>
</html>
```

## Declare Essential JS 1 Control & Essential JS 2 Control

You may initialized Essential JS 1 & Essential JS 2 controls using getting started. The below snippet we have initialized Eessential JS 1 & Essential JS 2 ASP.NET MVC UI Controls.

```
<h2> Essential JS 1 - Grid Control</h2>

    @(Html.EJ().Grid<object>("FlatGrid")
                            .Datasource((IEnumerable<object>)ViewBag.gridData)
                            .AllowPaging().PageSettings(page => page.PageSize(4))
                            .Columns(col =>

                            {
                                col.Field("OrderID").HeaderText("Order ID").TextAlign(TextAlign.Right).Width(75).Add();

                                col.Field("CustomerID").HeaderText("CustomerID").Width(80).Add();
                               col.Field("ShipName").HeaderText("ShipName").Width(100).Add();
                                col.Field("ShipCity").HeaderText("ShipCity").Width(100).Add();

                                col.Field("Freight").Format("{0:c3}").HeaderText("Freight").Width(80).TextAlign(TextAlign.Right).Add();
                            })
    )


<h2> Essential JS 2 - Grid Component </h2>
   @Html.EJS().Grid("Grid").DataSource((IEnumerable<object>)ViewBag.gridData).Columns(col =>
    {     col.Field("OrderID").HeaderText("OrderID").Width("120").TextAlign(Syncfusion.EJ2.Grids.TextAlign.Right).Add();

col.Field("CustomerID").HeaderText("Customer Name").Width("150").Add();
        col.Field("OrderDate").HeaderText("OrderDate").Width("130").TextAlign(Syncfusion.EJ2.Grids.TextAlign.Right).Format("yMd").Add();

col.Field("ShipCountry").HeaderText("Ship Country").Width("120").Add();

    }).AllowPaging().PageSettings(page => page.PageSize(4).PageSizes(true)).Render()

```


 
