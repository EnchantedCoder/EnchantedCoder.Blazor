namespace EnchantedCoder.Blazor.Components.Web.Bootstrap;

/// <summary>
/// Text input (also password, search, etc.)
/// </summary>
public class EcInputText : EcInputTextBase
{
	/// <summary>
	/// Application-wide defaults for the <see cref="EcInputFile"/> and derived components.<br />
	/// Full documentation and demos: <see href="https://EnchantedCoder.blazor.eu/components/EcInputText">https://EnchantedCoder.blazor.eu/components/EcInputText</see>.
	/// </summary>
	public static InputTextSettings Defaults { get; set; }

	static EcInputText()
	{
		Defaults = new InputTextSettings()
		{
			InputSize = Bootstrap.InputSize.Regular,
		};
	}

	/// <summary>
	/// Returns application-wide defaults for the component.
	/// Enables overriding defaults in descendants (use separate set of defaults).
	/// </summary>
	protected override InputTextSettings GetDefaults() => Defaults;

	/// <summary>
	/// Input type.
	/// </summary>
	[Parameter] public InputType Type { get; set; } = InputType.Text;

	/// <inheritdoc />
	private protected override string GetElementName() => "input";

	/// <inheritdoc />
	private protected override string GetTypeAttributeValue() => Type.ToString().ToLower();
}
