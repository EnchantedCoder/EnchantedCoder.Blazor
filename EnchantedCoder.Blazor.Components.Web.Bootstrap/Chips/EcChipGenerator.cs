namespace EnchantedCoder.Blazor.Components.Web.Bootstrap;

public class EcChipGenerator : ComponentBase, IEcChipGenerator, IAsyncDisposable
{
	[CascadingParameter(Name = EcFilterForm<object>.ChipGeneratorRegistrationCascadingValueName)] public CollectionRegistration<IEcChipGenerator> ChipGeneratorsRegistration { get; set; }

	[Parameter] public RenderFragment ChildContent { get; set; }

	[Parameter] public Action<object> ChipRemoveAction { get; set; }

	/// <inheritdoc cref="ComponentBase.OnInitialized" />
	protected override void OnInitialized()
	{
		base.OnInitialized();
		ChipGeneratorsRegistration?.Register(this);
	}

	IEnumerable<ChipItem> IEcChipGenerator.GetChips()
	{
		yield return new ChipItem
		{
			ChipTemplate = ChildContent,
			Removable = ChipRemoveAction != default,
			RemoveAction = ChipRemoveAction
		};
	}

	/// <inheritdoc />
	public async ValueTask DisposeAsync()
	{
		await DisposeAsyncCore();
	}

	protected virtual async Task DisposeAsyncCore()
	{
		if (this.ChipGeneratorsRegistration != null)
		{
			await ChipGeneratorsRegistration.UnregisterAsync(this);
		}
	}
}
