using Microsoft.Extensions.Localization;

namespace EnchantedCoder.Blazor.Components.Web.Bootstrap;

/// <summary>
/// Data presentation component composed of <see cref="EcGrid"/> for data, <see cref="EcOffcanvas"/> for manual filtering and <see cref="EcNamedViewList{T}"/> for pre-defined filters.<br />
/// Full documentation and demos: <see href="https://EnchantedCoder.blazor.eu/components/EcListLayout">https://EnchantedCoder.blazor.eu/components/EcListLayout</see>
/// </summary>
/// <typeparam name="TFilterModel"></typeparam>
public partial class EcListLayout<TFilterModel>
{
	/// <summary>
	/// Returns <see cref="EcMessageBox"/> defaults.
	/// Enables overriding defaults in descendants (use separate set of defaults).
	/// </summary>
	protected virtual ListLayoutSettings GetDefaults() => EcListLayout.Defaults;

	/// <summary>
	/// Set of settings to be applied to the component instance (overrides <see cref="EcListLayout.Defaults"/>, overridden by individual parameters).
	/// </summary>
	[Parameter] public ListLayoutSettings Settings { get; set; }

	/// <summary>
	/// Returns optional set of component settings.
	/// </summary>
	/// <remarks>
	/// Similar to <see cref="GetDefaults"/>, enables defining wider <see cref="Settings"/> in components descendants (by returning a derived settings class).
	/// </remarks>
	protected virtual ListLayoutSettings GetSettings() => this.Settings;

	[Parameter] public string Title { get; set; }

	[Parameter] public RenderFragment TitleTemplate { get; set; }

	[Parameter] public RenderFragment NamedViewsTemplate { get; set; }

	[Parameter] public RenderFragment SearchTemplate { get; set; }

	[Parameter] public RenderFragment<TFilterModel> FilterTemplate { get; set; }

	[Parameter] public TFilterModel FilterModel { get; set; }
	[Parameter] public EventCallback<TFilterModel> FilterModelChanged { get; set; }
	/// <summary>
	/// Triggers the <see cref="FilterModelChanged"/> event. Allows interception of the event in derived components.
	/// </summary>
	protected virtual Task InvokeFilterModelChangedAsync(TFilterModel newFilterModel) => FilterModelChanged.InvokeAsync(newFilterModel);

	[Parameter] public RenderFragment DataTemplate { get; set; }

	[Parameter] public RenderFragment DetailTemplate { get; set; }

	[Parameter] public RenderFragment CommandsTemplate { get; set; }

	/// <summary>
	/// Settings for the wrapping <see cref="EcCard"/>.
	/// </summary>
	[Parameter] public CardSettings CardSettings { get; set; }
	protected CardSettings CardSettingsEffective => this.CardSettings ?? GetSettings()?.CardSettings ?? GetDefaults().CardSettings ?? throw new InvalidOperationException(nameof(CardSettings) + " default for " + nameof(EcListLayout) + " has to be set.");

	/// <summary>
	/// Settings for the <see cref="EcButton"/> opening filtering offcanvas.
	/// </summary>
	[Parameter] public ButtonSettings FilterOpenButtonSettings { get; set; }
	protected ButtonSettings FilterOpenButtonSettingsEffective => this.FilterOpenButtonSettings ?? GetSettings()?.FilterOpenButtonSettings ?? GetDefaults().FilterOpenButtonSettings ?? throw new InvalidOperationException(nameof(FilterOpenButtonSettings) + " default for " + nameof(EcListLayout) + " has to be set.");

	/// <summary>
	/// Settings for the <see cref="EcButton"/> submitting the filter.
	/// </summary>
	[Parameter] public ButtonSettings FilterSubmitButtonSettings { get; set; }
	protected ButtonSettings FilterSubmitButtonSettingsEffective => this.FilterSubmitButtonSettings ?? GetSettings()?.FilterSubmitButtonSettings ?? GetDefaults().FilterSubmitButtonSettings ?? throw new InvalidOperationException(nameof(FilterSubmitButtonSettings) + " default for " + nameof(EcListLayout) + " has to be set.");

	/// <summary>
	/// Settings for the <see cref="EcOffcanvas"/> with the filter.
	/// </summary>
	[Parameter] public OffcanvasSettings FilterOffcanvasSettings { get; set; }
	protected OffcanvasSettings FilterOffcanvasSettingsEffective => this.FilterOffcanvasSettings ?? GetSettings()?.FilterOffcanvasSettings ?? GetDefaults().FilterOffcanvasSettings ?? throw new InvalidOperationException(nameof(FilterOffcanvasSettings) + " default for " + nameof(EcListLayout) + " has to be set.");

	/// <summary>
	/// Additional CSS classes for the wrapping <c>div</c>.
	/// </summary>
	[Parameter] public string CssClass { get; set; }
	protected string CssClassEffective => CssClass ?? this.GetSettings()?.CssClass ?? this.GetDefaults().CssClass;

	[Inject] protected IStringLocalizer<EcListLayout> Localizer { get; set; }

	private ChipItem[] chips;
	private string filterFormId = "ec" + Guid.NewGuid().ToString("N");
	private EcFilterForm<TFilterModel> filterForm;
	private EcOffcanvas filterOffcanvasComponent;

	protected override void OnParametersSet()
	{
		base.OnParametersSet();

		Contract.Requires<InvalidOperationException>((FilterTemplate is null) || (FilterModel is not null), $"{nameof(EcListLayout)} requires {nameof(FilterModel)} to be set if {nameof(FilterTemplate)}  is used.");
	}

	private void HandleChipUpdated(ChipItem[] chips)
	{
		this.chips = chips;
	}

	private async Task HandleChipRemoveClick(ChipItem chipItemToRemove)
	{
		await filterForm.RemoveChipAsync(chipItemToRemove);
	}

	private async Task HandleFilterButtonClick()
	{
		await filterOffcanvasComponent.ShowAsync();
	}

	private async Task HandleFilterFormModelChanged(TFilterModel newFilterModel)
	{
		FilterModel = newFilterModel;
		await InvokeFilterModelChangedAsync(newFilterModel);
		await filterOffcanvasComponent.HideAsync();
	}
}
