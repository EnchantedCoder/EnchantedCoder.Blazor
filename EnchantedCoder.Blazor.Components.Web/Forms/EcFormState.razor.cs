namespace EnchantedCoder.Blazor.Components.Web;

/// <summary>
/// Propagates form states as a cascading parementer to child components.<br />
/// Full documentation and demos: <see href="https://EnchantedCoder.blazor.eu/components/EcFormState">https://EnchantedCoder.blazor.eu/components/EcFormState</see>
/// </summary>
public partial class EcFormState
{
	/// <summary>
	/// Received form state.
	/// </summary>
	[CascadingParameter] protected FormState CascadingFormState { get; set; }

	/// <summary>
	/// Indicated enabled/disabled section. Value to propagate.
	/// </summary>
	[Parameter] public bool? Enabled { get; set; }

	/// <summary>
	/// When <c>false</c>, nothing is rendered (no children). Value is not propagated, there is no where to propagate.
	/// </summary>
	[Parameter] public bool Visible { get; set; } = true;

	/// <summary>
	/// Child content.
	/// </summary>
	[Parameter] public RenderFragment ChildContent { get; set; }

	/// <summary>
	/// Create form state to propagate.
	/// </summary>
	private FormState CreateNewCascadingFormState()
	{
		return new FormState
		{
			Enabled = Enabled ?? CascadingFormState?.Enabled,
		};
	}
}
