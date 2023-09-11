namespace EnchantedCoder.Blazor.Components.Web.Bootstrap.Documentation.Shared.Components;

public partial class Search
{
	[Inject] private NavigationManager NavigationManager { get; set; }

	private SearchItem SelectedResult
	{
		get
		{
			return null;
		}
		set
		{
			NavigateToSelectedPage(value);
		}
	}

	private string userInput;

	private const int DefaultsLevel = 2;
	private const int EnumsLevel = 2;
	private const int EventArgsLevel = 2;
	private const int DelegatesLevel = 2;

	private readonly List<SearchItem> searchItems = new()
	{
		new("/migrating-to-v3", "Migrating to v3", "upgrade release notes update 5.2 5.1"),

		// Components and other pages

		new("/components/Inputs", "Inputs", "form"),
		new("/components/Inputs#input-groups", "Inputs > Input groups", ""),
		new("/components/Inputs#floating-labels", "Inputs > Floating labels", ""),

		new("/components/EcAccordion", "EcAccordion", "collapse"),
		new("/components/EcAlert", "EcAlert", "message warning exclamation panel"),
		new("/components/EcAnchorFragmentNavigation", "EcAnchorFragmentNavigation", "id scroll"),
		new("/components/EcAutosuggest", "EcAutosuggest", "autocomplete search typeahead select"),
		new("/components/EcBadge", "EcBadge", "chip tag"),
		new("/components/EcBreadcrumb", "EcBreadcrumb", "navigation link"),
		new("/components/EcButton", "EcButton", "click submit input tooltip"),
		new("/components/EcButtonGroup", "EcButtonGroup", "collection"),
		new("/components/EcButtonToolbar", "EcButtonToolbar", ""),
		new("/components/EcCalendar", "EcCalendar", "datepicker"),
		new("/components/EcCard", "EcCard", "panel"),
		new("/components/EcCarousel", "EcCarousel", "slider jumbotron"),
		new("/components/EcCheckbox", "EcCheckbox", "ecinputcheckbox switch"),
		new("/components/EcCheckboxList", "EcCheckboxList", "multiselect"),
		new("/components/EcChipList", "EcChipList", "tags badges"),
		new("/components/EcCloseButton", "EcCloseButton", "dismiss cross x"),
		new("/components/EcCollapse", "EcCollapse", "accordion dropdown expand"),
		new("/components/EcCollapseToggleButton", "EcCollapseToggleButton", ""),
		new("/components/EcCollapseToggleElement", "EcCollapseToggleElement", ""),
		new("/components/EcContextMenu", "EcContextMenu", "dropdown popup"),
		new("/components/EcDialogBase", "EcDialogBase", "custom dialog modal messagebox"),
		new("/components/EcDropdown", "EcDropdown", "collapse tooltip popover popup popper"),
		new("/components/EcDropdownButtonGroup", "EcDropdownButtonGroup", "collapse tooltip popover popup popper"),
		new("/components/EcDynamicElement", "EcDynamicElement", "dynamiccomponent html"),
		new("/components/EcFilterForm", "EcFilterForm", "EcListLayout"),
		new("/components/EcFormState", "EcFormState", "enabled disabled"),
		new("/components/EcFormValue", "EcFormValue", "readonly"),
		new("/components/EcGoogleTagManager", "EcGoogleTagManager", "gtm ga analytics"),
		new("/components/EcGrid", "EcGrid", "data row column table datalist"),
		new("/components/EcGrid#InfiniteScroll", "EcGrid > Infinite scroll (Virtualized)", ""),
		new("/components/EcGrid#context-menu", "EcGrid > Context menu", ""),
		new("/components/EcGrid#multiselect", "EcGrid > Multiselect with checkboxes", ""),
		new("/components/EcGrid#inline-editing", "EcGrid > Inline-editing", ""),
		new("/components/EcGrid#header-filtering", "EcGrid > Filtering from header", ""),
		new("/components/EcIcon", "EcIcon", "bootstrap picture image font"),
		new("/components/EcInputDate", "EcInputDate", "datepicker"),
		new("/components/EcInputDateRange", "EcInputDateRange", "period datepicker"),
		new("/components/EcInputFile", "EcInputFile[Core]", "upload single multiple"),
		new("/components/EcInputFileDropZone", "EcInputFileDropZone", "upload single multiple"),
		new("/components/EcInputNumber", "EcInputNumber", ""),
		new("/components/EcInputPercent", "EcInputPercent", "normalization ecinputnumber"),
		new("/components/EcInputRange", "EcInputRange", "slider"),
		new("/components/EcInputTags", "EcInputTags", "keywords labels restricted suggestion"),
		new("/components/EcInputText", "EcInputText", "field password search textbox"),
		new("/components/EcInputTextArea", "EcInputTextArea", "field multiline"),
		new("/components/EcListGroup", "EcListGroup", "item"),
		new("/components/EcListLayout", "EcListLayout", "data presentation filter"),
		new("/components/EcMessageBox", "EcMessageBox", "pop-up full-screen dialog modal confirm"),
		new("/components/EcMessenger", "EcMessenger", "popup warning alert toaster"),
		new("/components/EcModal", "EcModal", "popup fullscreen dialog messagebox"),
		new("/components/EcMultiSelect", "EcMultiSelect", "dropdownlist picker checkbox multiple"),
		new("/components/EcNamedViewList", "EcNamedViewList", "EcListLayout"),
		new("/components/EcNav", "EcNav", "navigation"),
		new("/components/EcNavLink#EcNavLink", "EcNavLink", "href redirect navigation"),
		new("/components/EcNavbar", "EcNavbar", "navigation header"),
		new("/components/EcOffcanvas", "EcOffcanvas", "drawer"),
		new("/components/EcPager", "EcPager", "list pagination"),
		new("/components/EcPlaceholder", "EcPlaceholder", "loading skeleton spinner progress"),
		new("/components/EcPopover", "EcPopover", "hover tooltip popper dropdown"),
		new("/components/EcProgress", "EcProgress", "loading bar indicator"),
		new("/components/EcProgressIndicator", "EcProgressIndicator", "loading spinner"),
		new("/components/EcRadioButtonList", "EcRadioButtonList", "multiselect"),
		new("/components/EcRedirectTo", "EcRedirectTo", "navigateto 302 301 moved navigationmanager"),
		new("/components/EcRepeater", "EcRepeater", "multi clone foreach iterator iterate"),
		new("/components/EcScrollspy", "EcScrollspy", "anchor navigation link"),
		new("/components/EcSearchBox", "EcSearchBox", "autosuggest autocomplete searchbar omnibox input"),
		new("/components/EcSelect", "EcSelect", "dropdownlist picker"),
		new("/components/EcSidebar", "EcSidebar", "navigation collapse layout responsive"),
		new("/components/EcSpinner", "EcSpinner", "loading progress placeholder skeleton"),
		new("/components/EcSubmit#EcSubmit", "EcSubmit", "send form button"),
		new("/components/EcSwitch", "EcSwitch", "ecinputswitch ecradiobutton checkbox"),
		new("/components/EcTabPanel", "EcTabPanel", "page tabs"),
		new("/components/EcToast", "EcToast", "messenger"),
		new("/components/EcTooltip", "EcTooltip", "hover popup popover dropdown popper"),
		new("/components/EcTreeView", "EcTreeView", "hierarchy"),
		new("/components/EcValidationMessage", "EcValidationMessage", "form"),

		// Concepts
		new("/concepts/defaults-and-settings", "Defaults & Settings", "configuration themes wide preset"),
		new("/concepts/Debouncer", "Debouncer", "delay timer"),
		new("/concepts/dark-color-mode-theme", "Dark color mode", "dark color theme"),

		// Supportive types

		// Defaults (settings)

		new("/types/AutosuggestSettings", "Autosuggest Settings", "defaults", DefaultsLevel),
		new("/types/BadgeSettings", "Badge Settings", "defaults", DefaultsLevel),
		new("/types/ButtonSettings", "Button Settings", "defaults", DefaultsLevel),
		new("/types/CalendarSettings", "Calendar Settings", "defaults", DefaultsLevel),
		new("/types/CardSettings", "Card Settings", "defaults", DefaultsLevel),
		new("/types/ChipListSettings", "ChipList Settings", "defaults", DefaultsLevel),
		new("/types/CloseButtonSettings", "CloseButton Settings", "defaults", DefaultsLevel),
		new("/types/CheckboxSettings", "Checkbox Settings", "defaults", DefaultsLevel),
		new("/types/CheckboxListSettings", "CheckboxList Settings", "defaults", DefaultsLevel),
		new("/types/ContextMenuSettings", "ContextMenu Settings", "defaults", DefaultsLevel),
		new("/types/FormValueSettings", "FormValue Settings", "defaults", DefaultsLevel),
		new("/types/GridSettings", "Grid Settings", "defaults", DefaultsLevel),
		new("/types/InputsSettings", "Inputs Settings", "defaults", DefaultsLevel),
		new("/types/InputFileSettings", "InputFile Settings", "defaults", DefaultsLevel),
		new("/types/InputRangeSettings", "InputRangeSettings Settings", "defaults", DefaultsLevel),
		new("/types/InputDateRangeSettings", "InputDateRange Settings", "defaults", DefaultsLevel),
		new("/types/InputDateSettings", "InputDate Settings", "defaults", DefaultsLevel),
		new("/types/InputNumberSettings", "InputNumber Settings", "defaults", DefaultsLevel),
		new("/types/InputTextSettings", "InputText Settings", "defaults", DefaultsLevel),
		new("/types/InputTagsSettings", "InputTags Settings", "defaults", DefaultsLevel),
		new("/types/InputFileCoreSettings", "InputFileCore Settings", "defaults", DefaultsLevel),
		new("/types/ListLayoutSettings", "ListLayout Settings", "defaults", DefaultsLevel),
		new("/types/MultiSelect Settings", "MultiSelect Settings", "defaults", DefaultsLevel),
		new("/types/Modal Settings", "Modal Settings", "defaults", DefaultsLevel),
		new("/types/MessengerServiceExtensionsSettings", "MessengerServiceExtensions Settings", "defaults", DefaultsLevel),
		new("/types/MessageBoxSettings", "MessageBox Settings", "defaults", DefaultsLevel),
		new("/types/OffcanvasSettings", "Offcanvas Settings", "defaults", DefaultsLevel),
		new("/types/PagerSettings", "Pager Settings", "defaults", DefaultsLevel),
		new("/types/PlaceholderContainerSettings", "PlaceholderContainer Settings", "defaults", DefaultsLevel),
		new("/types/PlaceholderSettings", "Placeholder Settings", "defaults", DefaultsLevel),
		new("/types/ProgressIndicatorSettings", "ProgressIndicator Settings", "defaults", DefaultsLevel),
		new("/types/RadioButtonList", "RadioButtonList Settings", "defaults", DefaultsLevel),
		new("/types/SelectSettings", "Select Settings", "defaults", DefaultsLevel),
		new("/types/SearchBoxSettings", "SearchBox Settings", "defaults", DefaultsLevel),

		// Enums

		new("/types/BadgeType", "BadgeType", "enum shape", EnumsLevel),
		new("/types/BootstrapTheme", "BootstrapTheme", "enum", EnumsLevel),
		new("/types/ButtonGroupOrientation", "ButtonGroupOrientation", "enum", EnumsLevel),
		new("/types/ButtonGroupSize", "ButtonGroupSize", "enum", EnumsLevel),
		new("/types/ButtonIconPlacement", "ButtonIconPlacement", "enum", EnumsLevel),
		new("/types/ButtonSize", "ButtonSize", "enum", EnumsLevel),
		new("/types/CardImagePlacement", "CardImagePlacement", "enum", EnumsLevel),
		new("/types/CarouselRide", "CarouselRide", "enum", EnumsLevel),
		new("/types/CollapseDirection", "CollapseDirection", "enum", EnumsLevel),
		new("/types/DropdownAutoClose", "DropdownAutoClose", "enum", EnumsLevel),
		new("/types/DropdownDirection", "DropdownDirection", "enum", EnumsLevel),
		new("/types/BindEvent", "BindEvent", "enum", EnumsLevel),
		new("/types/InputSize", "InputSize", "enum", EnumsLevel),
		new("/types/InputType", "InputType", "enum", EnumsLevel),
		new("/types/LabelValueRenderOrder", "LabelValueRenderOrder", "enum", EnumsLevel),
		new("/types/LabelType", "LabelType", "enum", EnumsLevel),
		new("/types/GridContentNavigationMode", "GridContentNavigationMode", "enum", EnumsLevel),
		new("/types/ListGroupHorizontal", "ListGroupHorizontal", "enum", EnumsLevel),
		new("/types/ModalBackdrop", "ModalBackdrop", "enum static", EnumsLevel),
		new("/types/ModalFullscreen", "ModalFullscreen", "enum behavior", EnumsLevel),
		new("/types/ModalSize", "ModalSize", "enum", EnumsLevel),
		new("/types/AnchorFragmentNavigationAutomationMode", "AnchorFragmentNavigationAutomationMode", "enum", EnumsLevel),
		new("/types/NavbarExpand", "NavbarExpand", "enum responsive expand breakpoint", EnumsLevel),
		new("/types/NavOrientation", "NavOrientation", "enum", EnumsLevel),
		new("/types/NavVariant", "NavVariant", "enum", EnumsLevel),
		new("/types/OffcanvasBackdrop", "OffcanvasBackdrop", "enum static", EnumsLevel),
		new("/types/OffcanvasPlacement", "OffcanvasPlacement", "enum", EnumsLevel),
		new("/types/OffcanvasRenderMode", "OffcanvasRenderMode", "enum", EnumsLevel),
		new("/types/OffcanvasResponsiveBreakpoint", "OffcanvasResponsiveBreakpoint", "enum", EnumsLevel),
		new("/types/OffcanvasSize", "OffcanvasSize", "enum", EnumsLevel),
		new("/types/PlaceholderAnimation", "PlaceholderAnimation", "enum", EnumsLevel),
		new("/types/PlaceholderSize", "PlaceholderSize", "enum", EnumsLevel),
		new("/types/SpinnerSize", "SpinnerSize", "enum", EnumsLevel),
		new("/types/SpinnerType", "SpinnerType", "enum", EnumsLevel),
		new("/types/ThemeColor", "ThemeColor", "enum", EnumsLevel),
		new("/types/ToastContainerPosition", "ToastContainerPosition", "enum", EnumsLevel),
		new("/types/PopoverPlacement", "PopoverPlacement", "enum", EnumsLevel),
		new("/types/PopoverTrigger", "PopoverTrigger", "enum", EnumsLevel),
		new("/types/TooltipPlacement", "TooltipPlacement", "enum", EnumsLevel),
		new("/types/TooltipTrigger", "TooltipTrigger", "enum", EnumsLevel),
		new("/types/MessageBoxButtons", "MessageBoxButtons", "enum", EnumsLevel),

		// Event arguments

		new("/types/FileUploadedEventArgs", "FileUploadedEventArgs", "argument event", EventArgsLevel),
		new("/types/UploadCompletedEventArgs", "UploadCompletedEventArgs", "argument event", EventArgsLevel),
		new("/types/UploadProgressEventArgs", "UploadProgressEventArgs", "argument event", EventArgsLevel),

		// Delegates

		new("/types/CalendarDateCustomizationProviderDelegate", "CalendarDateCustomizationProviderDelegate", "delegate action", DelegatesLevel),
		new("/types/CalendarDateCustomizationResult", "CalendarDateCustomizationResult", "delegate", DelegatesLevel),
		new("/types/CalendarDateCustomizationRequest", "CalendarDateCustomizationRequest", "delegate", DelegatesLevel),

		new("/types/AutosuggestDataProviderDelegate", "AutosuggestDataProviderDelegate", "delegate action", DelegatesLevel),
		new("/types/AutosuggestDataProviderResult", "AutosuggestDataProviderResult", "delegate", DelegatesLevel),
		new("/types/AutosuggestDataProviderRequest", "AutosuggestDataProviderRequest", "delegate", DelegatesLevel),

		new("/types/GridDataProviderDelegate", "GridDataProviderDelegate", "delegate action", DelegatesLevel),
		new("/types/GridDataProviderResult", "GridDataProviderResult", "delegate", DelegatesLevel),
		new("/types/GridDataProviderRequest", "GridDataProviderRequest", "delegate", DelegatesLevel),

		new("/types/InputTagsDataProviderDelegate", "InputTagsDataProviderDelegate", "delegate action", DelegatesLevel),
		new("/types/InputTagsDataProviderResult", "InputTagsDataProviderResult", "delegate", DelegatesLevel),
		new("/types/InputTagsDataProviderRequest", "InputTagsDataProviderRequest", "delegate", DelegatesLevel)

	};

	private EcAutosuggest<SearchItem, SearchItem> autosuggest;

	private bool wasFocused = false;

	protected override async Task OnAfterRenderAsync(bool firstRender)
	{
		if (firstRender && !wasFocused)
		{
			wasFocused = true;
			await Task.Delay(1);
			await autosuggest.FocusAsync();
		}
	}

	private Task<AutosuggestDataProviderResult<SearchItem>> ProvideSuggestions(AutosuggestDataProviderRequest request)
	{
		this.userInput = request.UserInput.Trim();

		return Task.FromResult(new AutosuggestDataProviderResult<SearchItem>
		{
			Data = GetSearchItems()
		});
	}

	private IEnumerable<SearchItem> GetSearchItems()
	{
		return searchItems
				.Where(si => si.GetRelevance(userInput) > 0)
				.OrderBy(si => si.Level)
					.ThenByDescending(si => si.GetRelevance(userInput))
					.ThenBy(si => si.Title)
				.Take(5);
	}

	public void NavigateToSelectedPage(SearchItem searchItem)
	{
		NavigationManager.NavigateTo(searchItem.Href);
	}
}
