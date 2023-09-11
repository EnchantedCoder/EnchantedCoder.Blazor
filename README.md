
# EnchantedCoder Blazor - Bootstrap 5 component bundle

[![Nuget](https://img.shields.io/nuget/v/EnchantedCoder.Blazor.Components.Web.Bootstrap)](https://www.nuget.org/packages/EnchantedCoder.Blazor.Components.Web.Bootstrap/)
[![Nuget](https://img.shields.io/nuget/dt/EnchantedCoder.Blazor.Components.Web.Bootstrap)](https://www.nuget.org/packages/EnchantedCoder.Blazor.Components.Web.Bootstrap/)
[![Build Status](https://dev.azure.com/EnchantedCoder/DEV/_apis/build/status/002.HFW-EnchantedCoderBlazor?branchName=master)](https://dev.azure.com/EnchantedCoder/DEV/_build/latest?definitionId=318&branchName=master)
[![GitHub](https://img.shields.io/github/license/EnchantedCoder/EnchantedCoder.Blazor)](https://github.com/EnchantedCoder/EnchantedCoder.Blazor/blob/master/LICENSE)
[![GitHub](https://img.shields.io/github/stars/EnchantedCoder/EnchantedCoder.Blazor)](https://github.com/EnchantedCoder/EnchantedCoder.Blazor/)
[![#StandWithUkraine](https://img.shields.io/badge/%23StandWithUkraine-Russian%20warship%2C%20go%20f%23ck%20yourself-blue)](https://www.peopleinneed.net/what-we-do/humanitarian-aid-and-development/ukraine)

* Free Bootstrap 5.3 components for ASP.NET Blazor
* .NET 6+ with Blazor WebAssembly or Blazor Server (other hosting models not tested yet, .NET 7 fully supported)
* [Enterprise project template](https://github.com/EnchantedCoder/NewProjectTemplate-Blazor) (optional) - layered architecture, EF Core, gRPC code-first, ...

If you enjoy using [EnchantedCoder Blazor](https://EnchantedCoder.blazor.eu/), you can [become a sponsor](https://github.com/sponsors/EnchantedCoder). Your sponsorship will allow us to devote time to features and issues requested by the community (i.e. not required by our own projects) ❤️.


# See [&gt;&gt;Interactive Documentation & Demos&lt;&lt;](https://EnchantedCoder.blazor.eu)

## 🔥[Migration to v4](https://EnchantedCoder.blazor.eu/migrating)🔥

# Components

## Forms

* [`EcAutosuggest`](https://EnchantedCoder.blazor.eu/components/EcAutosuggest) - Component for single item selection with dynamic suggestions.
* [`EcCalendar`](https://EnchantedCoder.blazor.eu/components/EcCalendar) - Basic calendar building block.
* [`EcInputDate`](https://EnchantedCoder.blazor.eu/components/EcInputDate) - Date picker. Form input component for entering a date.
* [`EcInputDateRange`](https://EnchantedCoder.blazor.eu/components/EcInputDateRange) - Date range picker. Form input component for entering start date and end date.
* [`EcInputFile[Core]`](https://EnchantedCoder.blazor.eu/components/EcInputFile[Core]) - Wraps EcInputFileCore as Bootstrap form control (incl. Label etc.).
* [`EcInputFileDropZone`](https://EnchantedCoder.blazor.eu/components/EcInputFileDropZone) - Ready-made UX for drag&amp;drop file upload.
* [`EcInputNumber`](https://EnchantedCoder.blazor.eu/components/EcInputNumber) - Numeric input.
* [`EcInputPercent`](https://EnchantedCoder.blazor.eu/components/EcInputPercent) - Numeric input in percentages with value normalization (0% = 0, 100% = 1.0).
* [`EcInputRange`](https://EnchantedCoder.blazor.eu/components/EcInputRange) - Range input (slider).
* [`EcInputTags`](https://EnchantedCoder.blazor.eu/components/EcInputTags) - Input for entering tags.
* [`EcInputText`](https://EnchantedCoder.blazor.eu/components/EcInputText) - Text input (also password, search, etc.)
* [`EcInputTextArea`](https://EnchantedCoder.blazor.eu/components/EcInputTextArea) - [Textarea](https://getbootstrap.com/docs/5.3/forms/floating-labels/#textareas).
* [`EcCheckbox`](https://EnchantedCoder.blazor.eu/components/EcCheckbox) - Checkbox input.
* [`EcCheckboxList`](https://EnchantedCoder.blazor.eu/components/EcCheckboxList) - Multiple choice by checkboxes.
* [`EcFormState`](https://EnchantedCoder.blazor.eu/components/EcFormState) - Propagates form states as a cascading parementer to child components.
* [`EcFormValue`](https://EnchantedCoder.blazor.eu/components/EcFormValue) - Displays a read-only value in the form control visual.
* [`EcRadioButtonList`](https://EnchantedCoder.blazor.eu/components/EcRadioButtonList) - Select.
* [`EcSelect`](https://EnchantedCoder.blazor.eu/components/EcSelect) - Select - DropDownList - single-item picker.
* [`EcMultiSelect`](https://EnchantedCoder.blazor.eu/components/EcMultiSelect) - Unlike a normal select, multiselect allows the user to select multiple options at once.
* [`EcSearchBox`](https://EnchantedCoder.blazor.eu/components/EcSearchBox) - A search input component witch automatic suggestions, initial dropdown template and free-text queries support.
* [`EcSwitch`](https://EnchantedCoder.blazor.eu/components/EcSwitch) - Switch input.
* [`EcFilterForm`](https://EnchantedCoder.blazor.eu/components/EcFilterForm) - Edit form derived from EcModelEditForm with support for chip generators.
* [`EcValidationMessage`](https://EnchantedCoder.blazor.eu/components/EcValidationMessage) - Displays a list of validation messages for a specified field.

## Buttons & Indicators

* [`EcButton`](https://EnchantedCoder.blazor.eu/components/EcButton) - Bootstrap [button](https://getbootstrap.com/docs/5.3/components/buttons/).
* [`EcButtonGroup`](https://EnchantedCoder.blazor.eu/components/EcButtonGroup) - Bootstrap [ButtonGroups](https://getbootstrap.com/docs/5.3/components/button-group/).
* [`EcButtonToolbar`](https://EnchantedCoder.blazor.eu/components/EcButtonToolbar) - Bootstrap [ButtonGroups](https://getbootstrap.com/docs/5.3/components/button-group/).
* [`EcCloseButton`](https://EnchantedCoder.blazor.eu/components/EcCloseButton) - Bootstrap [close-button](https://getbootstrap.com/docs/5.3/components/close-button/).
* [`EcSubmit`](https://EnchantedCoder.blazor.eu/components/EcSubmit) - Submit button.
* [`EcDropdown`](https://EnchantedCoder.blazor.eu/components/EcDropdown) - [Bootstrap 5 Dropdown](https://getbootstrap.com/docs/5.3/components/dropdowns/).
* [`EcBadge`](https://EnchantedCoder.blazor.eu/components/EcBadge) - [Bootstrap Badge](https://getbootstrap.com/docs/5.3/components/badge/) component.
* [`EcChipList`](https://EnchantedCoder.blazor.eu/components/EcChipList) - Presents a list of chips as badges.
* [`EcIcon`](https://EnchantedCoder.blazor.eu/components/EcIcon) - Displays an icon.
* [`EcSpinner`](https://EnchantedCoder.blazor.eu/components/EcSpinner) - Bootstrap [Spinner](https://getbootstrap.com/docs/5.3/components/spinners/) (usually indicates operation in progress).
* [`EcProgressIndicator`](https://EnchantedCoder.blazor.eu/components/EcProgressIndicator) - Displays the content of the component as "in progress".
* [`EcTooltip`](https://EnchantedCoder.blazor.eu/components/EcTooltip) - [Bootstrap Tooltip](https://getbootstrap.com/docs/5.3/components/tooltips/) component, activates on hover.
* [`EcPopover`](https://EnchantedCoder.blazor.eu/components/EcPopover) - [Bootstrap Popover](https://getbootstrap.com/docs/5.3/components/popovers/) component.

## Data & Grid

* [`EcGrid`](https://EnchantedCoder.blazor.eu/components/EcGrid) - Grid to display tabular data from data source.
* [`EcContextMenu`](https://EnchantedCoder.blazor.eu/components/EcContextMenu) - Ready-made context menu.
* [`EcPager`](https://EnchantedCoder.blazor.eu/components/EcPager) - Pager.
* [`EcRepeater`](https://EnchantedCoder.blazor.eu/components/EcRepeater) - A data-bound list component.
* [`EcTreeView`](https://EnchantedCoder.blazor.eu/components/EcTreeView) - Component to display hierarchy data structure.

## Layout & Typography

* [`EcAccordion`](https://EnchantedCoder.blazor.eu/components/EcAccordion) - [Bootstrap accordion](https://getbootstrap.com/docs/5.3/components/accordion/) component.
* [`EcAlert`](https://EnchantedCoder.blazor.eu/components/EcAlert) - Bootstrap Alert.
* [`EcBadge`](https://EnchantedCoder.blazor.eu/components/EcBadge) - [Bootstrap Badge](https://getbootstrap.com/docs/5.3/components/badge/) component.
* [`EcCard`](https://EnchantedCoder.blazor.eu/components/EcCard) - [Bootstrap Card](https://getbootstrap.com/docs/5.3/components/card/) component.
* [`EcCarousel`](https://EnchantedCoder.blazor.eu/components/EcCarousel) - A slideshow component for cycling through elements—images or slides of text—like a carousel.
* [`EcCollapse`](https://EnchantedCoder.blazor.eu/components/EcCollapse) - [Bootstrap 5 Collapse](https://getbootstrap.com/docs/5.3/components/collapse/) component.
* [`EcDropdown`](https://EnchantedCoder.blazor.eu/components/EcDropdown) - [Bootstrap 5 Dropdown](https://getbootstrap.com/docs/5.3/components/dropdowns/).
* [`EcIcon`](https://EnchantedCoder.blazor.eu/components/EcIcon) - Displays an icon.
* [`EcSpinner`](https://EnchantedCoder.blazor.eu/components/EcSpinner) - [Bootstrap Spinner](https://getbootstrap.com/docs/5.3/components/spinners/) (usually indicates operation in progress).
* [`EcPlaceholder`](https://EnchantedCoder.blazor.eu/components/EcPlaceholder) - [Bootstrap 5 Placeholder](https://getbootstrap.com/docs/5.3/components/placeholders/) component, aka Skeleton.
* [`EcProgress`](https://EnchantedCoder.blazor.eu/components/EcProgress) - [Bootstrap 5 Progress](https://getbootstrap.com/docs/5.3/components/progress/) component.
* [`EcProgressIndicator`](https://EnchantedCoder.blazor.eu/components/EcProgressIndicator) - Displays the content of the component as "in progress".
* [`EcTooltip`](https://EnchantedCoder.blazor.eu/components/EcTooltip) - [Bootstrap Tooltip](https://getbootstrap.com/docs/5.3/components/tooltips/) component, activates on hover.
* [`EcTabPanel`](https://EnchantedCoder.blazor.eu/components/EcTabPanel) - Container for `EcTab`.
* [`EcListGroup`](https://EnchantedCoder.blazor.eu/components/EcListGroup) - [Bootstrap 5 List group](https://getbootstrap.com/docs/5.3/components/list-group/) component.
* [`EcListLayout`](https://EnchantedCoder.blazor.eu/components/EcListLayout) - Page layout for data presentation (usualy `EcGrid` with filter in `EcOffcanvas`).
* [`EcFormValue`](https://EnchantedCoder.blazor.eu/components/EcFormValue) - Displays a read-only value in the form control visual (as `.form-control`, with label, border, etc.).

## Navigation

* [`EcNavbar`](https://EnchantedCoder.blazor.eu/components/EcNavbar) - [Bootstrap 5 Navbar](https://getbootstrap.com/docs/5.3/components/navbar/) component - responsive navigation header.
* [`EcSidebar`](https://EnchantedCoder.blazor.eu/components/EcSidebar) - Sidebar component - responsive navigation sidebar.
* [`EcNav`](https://EnchantedCoder.blazor.eu/components/EcNav) - [Bootstrap Nav](https://getbootstrap.com/docs/5.3/components/navs-tabs/) component.
* [`EcNavLink`](https://EnchantedCoder.blazor.eu/components/EcNavLink) - [Bootstrap Nav](https://getbootstrap.com/docs/5.3/components/navs-tabs/) component.
* [`EcScrollspy`](https://EnchantedCoder.blazor.eu/components/EcScrollspy) - [Bootstrap Scrollspy](https://getbootstrap.com/docs/5.3/components/scrollspy/) component.
* [`EcBreadcrumb`](https://EnchantedCoder.blazor.eu/components/EcBreadcrumb) - [Bootstrap 5 Breadcrumb](https://getbootstrap.com/docs/5.3/components/breadcrumb/) component. Indicates the current page’s location within a navigational hierarchy.
* [`EcAnchorFragmentNavigation`](https://EnchantedCoder.blazor.eu/components/EcAnchorFragmentNavigation) - Compensates Blazor deficiency in anchor-fragments (scrolling to <code>page#id</code> URLs).
* [`EcContextMenu`](https://EnchantedCoder.blazor.eu/components/EcContextMenu) - Ready-made context menu.
* [`EcDropdown`](https://EnchantedCoder.blazor.eu/components/EcDropdown) - [Bootstrap 5 Dropdown](https://getbootstrap.com/docs/5.3/components/dropdowns/).
* [`EcTabPanel`](https://EnchantedCoder.blazor.eu/components/EcTabPanel) - Container for `EcTab` for easier implementation of tabbed UI.
* [`EcRedirectTo`](https://EnchantedCoder.blazor.eu/components/EcRedirectTo) - Rendering a `EcRedirectTo` will navigate to a new location.

## Modals & Interactions

* [`EcMessageBox`](https://EnchantedCoder.blazor.eu/components/EcMessageBox) - Component to display message-boxes.
* [`EcModal`](https://EnchantedCoder.blazor.eu/components/EcModal) - Component to render modal dialog as a [Bootstrap Modal](https://getbootstrap.com/docs/5.3/components/modal/).
* [`EcDialogBase`](https://EnchantedCoder.blazor.eu/components/EcDialogBase) - Base class to simplify custom modal dialog implementation.
* [`EcOffcanvas`](https://EnchantedCoder.blazor.eu/components/EcOffcanvas) - [Bootstrap Offcanvas](https://getbootstrap.com/docs/5.3/components/offcanvas/) component (aka Drawer).
* [`EcMessenger`](https://EnchantedCoder.blazor.eu/components/EcMessenger) - `EcToastContainer` wrapper for displaying `EcToast` messages dispatched through `IEcMessengerService`.
* [`EcToast`](https://EnchantedCoder.blazor.eu/components/EcToast) - [Bootstrap Toast](https://getbootstrap.com/docs/5.3/components/toasts/) component. Not intented to be used in user code, use `EcMessenger`.

## Special

* [`EcDynamicElement`](https://EnchantedCoder.blazor.eu/components/EcDynamicElement) - Renders an element with the specified name, attributes and child-content.
* [`EcGoogleTagManager`](https://EnchantedCoder.blazor.eu/components/EcGoogleTagManager) - Support for [Google Tag Manager](https://developers.google.com/tag-manager/devguide) - initialization and pushing data to data-layer.
