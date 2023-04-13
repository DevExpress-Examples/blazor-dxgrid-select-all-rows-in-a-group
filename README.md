<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/626950627/22.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T1159694)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# Grid for Blazor - How to allow users to select and deselect all items in a group

This example demonstrates how to congifure the [Devexpress Blazor Grid](https://docs.devexpress.com/Blazor/403143/grid) component to allow users to select and deselect all items in a group.

![Select and Deselect Items in a Group](select-deselect-rows.gif)

## Specifics and Limitations

The technique shown in the example imposes the following specifics and limitations:

* We do not recommend that you use the technique when the Grid is bound to a large data collection.
* To support scenarios when data editing  is enabled, the example implements the `InvalidateGroupDataItemsCache` method. Call the method in the [EditModelSaving](https://docs.devexpress.com/Blazor/DevExpress.Blazor.DxGrid.EditModelSaving) and [DataItemDeleting](https://docs.devexpress.com/Blazor/DevExpress.Blazor.DxGrid.DataItemDeleting) event handlers after you save changes to the data source.

## Overview

The Grid does not include built-in API to get rows that belong to a group. To get data items that correspond to a group's rows, the example does the following:

1. Creates a filter predicate based on [grouping](https://docs.devexpress.com/Blazor/403143/grid#group-data) and filter applied to the Grid. The predicate determines whether a data item belongs to the group and meets the Grid's [filter criteria](https://docs.devexpress.com/Blazor/DevExpress.Blazor.DxGrid.GetFilterCriteria). To convert the filter criteria to a case-insensitive predicate, the example uses the [CriteriaStringToLowerConverter](./CS/Data/CriteriaStringToLowerConverter.cs) class.
2. Obtains an item collection from the database bound to the Grid.
3. Calls the **System.Linq.Dynamic.Core** library's [AsQueryable](https://learn.microsoft.com/en-us/dotnet/api/system.linq.queryable.asqueryable?view=net-8.0#system-linq-queryable-asqueryable-1(system-collections-generic-ienumerable((-0)))) method to convert the collection from [IEnumerable\<T\>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-7.0) to [IQueryable\<T\>](https://learn.microsoft.com/en-us/dotnet/api/system.linq.iqueryable-1?view=net-8.0).
4. Filters the collection based on the created filter predicate. 

To reduce the number of requests to the database, the example saves the result item lists and the corresponding filter predicates to the `GroupDataItemsCache` object. The contents of this object remains constant until the grouping or the filter criteria changes. After the change, the example updates the `GroupDataItemsCache` object.

## Files to Review

- [Index.razor](./CS/Pages/Index.razor)
- [CriteriaStringToLowerConverter.cs](./CS/Data/CriteriaStringToLowerConverter.cs)
- [WeatherForecast.cs](/.CS/Data/WeatherForecast.cs)
- [WeatherForecastService.cs](/.CS/Data/WeatherForecastService.cs)

## Documentation

- [Filter Data](https://docs.devexpress.com/Blazor/404326/grid/filter-data/filter-data)
- [Examples](https://docs.devexpress.com/Blazor/404035/grid/examples)

## More Examples

- [Grid for Blazor - How to implement a date range filter](https://github.com/DevExpress-Examples/blazor-dxgrid-date-range-filter)
- [Grid for Blazor - Incorporate a selector for filter row operator type](https://github.com/DevExpress-Examples/blazor-dxgrid-filter-operator-selector)
