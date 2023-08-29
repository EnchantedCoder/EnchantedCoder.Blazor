
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

* [`HxAutosuggest`](https://EnchantedCoder.blazor.eu/components/HxAutosuggest) - Component for single item selection with dynamic suggestions.
* [`HxCalendar`](https://EnchantedCoder.blazor.eu/components/HxCalendar) - Basic calendar building block.
* [`HxInputDate`](https://EnchantedCoder.blazor.eu/components/HxInputDate) - Date picker. Form input component for entering a date.
* [`HxInputDateRange`](https://EnchantedCoder.blazor.eu/components/HxInputDateRange) - Date range picker. Form input component for entering start date and end date.
* [`HxInputFile[Core]`](https://EnchantedCoder.blazor.eu/components/HxInputFile[Core]) - Wraps HxInputFileCore as Bootstrap form control (incl. Label etc.).
* [`HxInputFileDropZone`](https://EnchantedCoder.blazor.eu/components/HxInputFileDropZone) - Ready-made UX for drag&amp;drop file upload.
* [`HxInputNumber`](https://EnchantedCoder.blazor.eu/components/HxInputNumber) - Numeric input.
* [`HxInputPercent`](https://EnchantedCoder.blazor.eu/components/HxInputPercent) - Numeric input in percentages with value normalization (0% = 0, 100% = 1.0).
* [`HxInputRange`](https://EnchantedCoder.blazor.eu/components/HxInputRange) - Range input (slider).
* [`HxInputTags`](https://EnchantedCoder.blazor.eu/components/HxInputTags) - Input for entering tags.
* [`HxInputText`](https://EnchantedCoder.blazor.eu/components/HxInputText) - Text input (also password, search, etc.)
* [`HxInputTextArea`](https://EnchantedCoder.blazor.eu/components/HxInputTextArea) - [Textarea](https://getbootstrap.com/docs/5.3/forms/floating-labels/#textareas).
* [`HxCheckbox`](https://EnchantedCoder.blazor.eu/components/HxCheckbox) - Checkbox input.
* [`HxCheckboxList`](https://EnchantedCoder.blazor.eu/components/HxCheckboxList) - Multiple choice by checkboxes.
* [`HxFormState`](https://EnchantedCoder.blazor.eu/components/HxFormState) - Propagates form states as a cascading parementer to child components.
* [`HxFormValue`](https://EnchantedCoder.blazor.eu/components/HxFormValue) - Displays a read-only value in the form control visual.
* [`HxRadioButtonList`](https://EnchantedCoder.blazor.eu/components/HxRadioButtonList) - Select.
* [`HxSelect`](https://EnchantedCoder.blazor.eu/components/HxSelect) - Select - DropDownList - single-item picker.
* [`HxMultiSelect`](https://EnchantedCoder.blazor.eu/components/HxMultiSelect) - Unlike a normal select, multiselect allows the user to select multiple options at once.
* [`HxSearchBox`](https://EnchantedCoder.blazor.eu/components/HxSearchBox) - A search input component witch automatic suggestions, initial dropdown template and free-text queries support.
* [`HxSwitch`](https://EnchantedCoder.blazor.eu/components/HxSwitch) - Switch input.
* [`HxFilterForm`](https://EnchantedCoder.blazor.eu/components/HxFilterForm) - Edit form derived from HxModelEditForm with support for chip generators.
* [`HxValidationMessage`](https://EnchantedCoder.blazor.eu/components/HxValidationMessage) - Displays a list of validation messages for a specified field.

## Buttons & Indicators

* [`HxButton`](https://EnchantedCoder.blazor.eu/components/HxButton) - Bootstrap [button](https://getbootstrap.com/docs/5.3/components/buttons/).
* [`HxButtonGroup`](https://EnchantedCoder.blazor.eu/components/HxButtonGroup) - Bootstrap [ButtonGroups](https://getbootstrap.com/docs/5.3/components/button-group/).
* [`HxButtonToolbar`](https://EnchantedCoder.blazor.eu/components/HxButtonToolbar) - Bootstrap [ButtonGroups](https://getbootstrap.com/docs/5.3/components/button-group/).
* [`HxCloseButton`](https://EnchantedCoder.blazor.eu/components/HxCloseButton) - Bootstrap [close-button](https://getbootstrap.com/docs/5.3/components/close-button/).
* [`HxSubmit`](https://EnchantedCoder.blazor.eu/components/HxSubmit) - Submit button.
* [`HxDropdown`](https://EnchantedCoder.blazor.eu/components/HxDropdown) - [Bootstrap 5 Dropdown](https://getbootstrap.com/docs/5.3/components/dropdowns/).
* [`HxBadge`](https://EnchantedCoder.blazor.eu/components/HxBadge) - [Bootstrap Badge](https://getbootstrap.com/docs/5.3/components/badge/) component.
* [`HxChipList`](https://EnchantedCoder.blazor.eu/components/HxChipList) - Presents a list of chips as badges.
* [`HxIcon`](https://EnchantedCoder.blazor.eu/components/HxIcon) - Displays an icon.
* [`HxSpinner`](https://EnchantedCoder.blazor.eu/components/HxSpinner) - Bootstrap [Spinner](https://getbootstrap.com/docs/5.3/components/spinners/) (usually indicates operation in progress).
* [`HxProgressIndicator`](https://EnchantedCoder.blazor.eu/components/HxProgressIndicator) - Displays the content of the component as "in progress".
* [`HxTooltip`](https://EnchantedCoder.blazor.eu/components/HxTooltip) - [Bootstrap Tooltip](https://getbootstrap.com/docs/5.3/components/tooltips/) component, activates on hover.
* [`HxPopover`](https://EnchantedCoder.blazor.eu/components/HxPopover) - [Bootstrap Popover](https://getbootstrap.com/docs/5.3/components/popovers/) component.

## Data & Grid

* [`HxGrid`](https://EnchantedCoder.blazor.eu/components/HxGrid) - Grid to display tabular data from data source.
* [`HxContextMenu`](https://EnchantedCoder.blazor.eu/components/HxContextMenu) - Ready-made context menu.
* [`HxPager`](https://EnchantedCoder.blazor.eu/components/HxPager) - Pager.
* [`HxRepeater`](https://EnchantedCoder.blazor.eu/components/HxRepeater) - A data-bound list component.
* [`HxTreeView`](https://EnchantedCoder.blazor.eu/components/HxTreeView) - Component to display hierarchy data structure.

## Layout & Typography

* [`HxAccordion`](https://EnchantedCoder.blazor.eu/components/HxAccordion) - [Bootstrap accordion](https://getbootstrap.com/docs/5.3/components/accordion/) component.
* [`HxAlert`](https://EnchantedCoder.blazor.eu/components/HxAlert) - Bootstrap Alert.
* [`HxBadge`](https://EnchantedCoder.blazor.eu/components/HxBadge) - [Bootstrap Badge](https://getbootstrap.com/docs/5.3/components/badge/) component.
* [`HxCard`](https://EnchantedCoder.blazor.eu/components/HxCard) - [Bootstrap Card](https://getbootstrap.com/docs/5.3/components/card/) component.
* [`HxCarousel`](https://EnchantedCoder.blazor.eu/components/HxCarousel) - A slideshow component for cycling through elements—images or slides of text—like a carousel.
* [`HxCollapse`](https://EnchantedCoder.blazor.eu/components/HxCollapse) - [Bootstrap 5 Collapse](https://getbootstrap.com/docs/5.3/components/collapse/) component.
* [`HxDropdown`](https://EnchantedCoder.blazor.eu/components/HxDropdown) - [Bootstrap 5 Dropdown](https://getbootstrap.com/docs/5.3/components/dropdowns/).
* [`HxIcon`](https://EnchantedCoder.blazor.eu/components/HxIcon) - Displays an icon.
* [`HxSpinner`](https://EnchantedCoder.blazor.eu/components/HxSpinner) - [Bootstrap Spinner](https://getbootstrap.com/docs/5.3/components/spinners/) (usually indicates operation in progress).
* [`HxPlaceholder`](https://EnchantedCoder.blazor.eu/components/HxPlaceholder) - [Bootstrap 5 Placeholder](https://getbootstrap.com/docs/5.3/components/placeholders/) component, aka Skeleton.
* [`HxProgress`](https://EnchantedCoder.blazor.eu/components/HxProgress) - [Bootstrap 5 Progress](https://getbootstrap.com/docs/5.3/components/progress/) component.
* [`HxProgressIndicator`](https://EnchantedCoder.blazor.eu/components/HxProgressIndicator) - Displays the content of the component as "in progress".
* [`HxTooltip`](https://EnchantedCoder.blazor.eu/components/HxTooltip) - [Bootstrap Tooltip](https://getbootstrap.com/docs/5.3/components/tooltips/) component, activates on hover.
* [`HxTabPanel`](https://EnchantedCoder.blazor.eu/components/HxTabPanel) - Container for `HxTab`.
* [`HxListGroup`](https://EnchantedCoder.blazor.eu/components/HxListGroup) - [Bootstrap 5 List group](https://getbootstrap.com/docs/5.3/components/list-group/) component.
* [`HxListLayout`](https://EnchantedCoder.blazor.eu/components/HxListLayout) - Page layout for data presentation (usualy `HxGrid` with filter in `HxOffcanvas`).
* [`HxFormValue`](https://EnchantedCoder.blazor.eu/components/HxFormValue) - Displays a read-only value in the form control visual (as `.form-control`, with label, border, etc.).

## Navigation

* [`HxNavbar`](https://EnchantedCoder.blazor.eu/components/HxNavbar) - [Bootstrap 5 Navbar](https://getbootstrap.com/docs/5.3/components/navbar/) component - responsive navigation header.
* [`HxSidebar`](https://EnchantedCoder.blazor.eu/components/HxSidebar) - Sidebar component - responsive navigation sidebar.
* [`HxNav`](https://EnchantedCoder.blazor.eu/components/HxNav) - [Bootstrap Nav](https://getbootstrap.com/docs/5.3/components/navs-tabs/) component.
* [`HxNavLink`](https://EnchantedCoder.blazor.eu/components/HxNavLink) - [Bootstrap Nav](https://getbootstrap.com/docs/5.3/components/navs-tabs/) component.
* [`HxScrollspy`](https://EnchantedCoder.blazor.eu/components/HxScrollspy) - [Bootstrap Scrollspy](https://getbootstrap.com/docs/5.3/components/scrollspy/) component.
* [`HxBreadcrumb`](https://EnchantedCoder.blazor.eu/components/HxBreadcrumb) - [Bootstrap 5 Breadcrumb](https://getbootstrap.com/docs/5.3/components/breadcrumb/) component. Indicates the current page’s location within a navigational hierarchy.
* [`HxAnchorFragmentNavigation`](https://EnchantedCoder.blazor.eu/components/HxAnchorFragmentNavigation) - Compensates Blazor deficiency in anchor-fragments (scrolling to <code>page#id</code> URLs).
* [`HxContextMenu`](https://EnchantedCoder.blazor.eu/components/HxContextMenu) - Ready-made context menu.
* [`HxDropdown`](https://EnchantedCoder.blazor.eu/components/HxDropdown) - [Bootstrap 5 Dropdown](https://getbootstrap.com/docs/5.3/components/dropdowns/).
* [`HxTabPanel`](https://EnchantedCoder.blazor.eu/components/HxTabPanel) - Container for `HxTab` for easier implementation of tabbed UI.
* [`HxRedirectTo`](https://EnchantedCoder.blazor.eu/components/HxRedirectTo) - Rendering a `HxRedirectTo` will navigate to a new location.

## Modals & Interactions

* [`HxMessageBox`](https://EnchantedCoder.blazor.eu/components/HxMessageBox) - Component to display message-boxes.
* [`HxModal`](https://EnchantedCoder.blazor.eu/components/HxModal) - Component to render modal dialog as a [Bootstrap Modal](https://getbootstrap.com/docs/5.3/components/modal/).
* [`HxDialogBase`](https://EnchantedCoder.blazor.eu/components/HxDialogBase) - Base class to simplify custom modal dialog implementation.
* [`HxOffcanvas`](https://EnchantedCoder.blazor.eu/components/HxOffcanvas) - [Bootstrap Offcanvas](https://getbootstrap.com/docs/5.3/components/offcanvas/) component (aka Drawer).
* [`HxMessenger`](https://EnchantedCoder.blazor.eu/components/HxMessenger) - `HxToastContainer` wrapper for displaying `HxToast` messages dispatched through `IHxMessengerService`.
* [`HxToast`](https://EnchantedCoder.blazor.eu/components/HxToast) - [Bootstrap Toast](https://getbootstrap.com/docs/5.3/components/toasts/) component. Not intented to be used in user code, use `HxMessenger`.

## Special

* [`HxDynamicElement`](https://EnchantedCoder.blazor.eu/components/HxDynamicElement) - Renders an element with the specified name, attributes and child-content.
* [`HxGoogleTagManager`](https://EnchantedCoder.blazor.eu/components/HxGoogleTagManager) - Support for [Google Tag Manager](https://developers.google.com/tag-manager/devguide) - initialization and pushing data to data-layer.
