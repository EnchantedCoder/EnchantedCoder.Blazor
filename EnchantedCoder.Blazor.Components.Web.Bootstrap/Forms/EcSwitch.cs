namespace EnchantedCoder.Blazor.Components.Web.Bootstrap;

/// <summary>
/// Switch input.<br/>
/// (Replaces the former <c>EcInputSwitch</c> component which was dropped in v4.0.0.)<br/>
/// Full documentation and demos: <see href="https://EnchantedCoder.blazor.eu/components/EcSwitch">https://EnchantedCoder.blazor.eu/components/EcSwitch</see>
/// </summary>
public class EcSwitch : EcCheckbox
{
	/// <inheritdoc cref="EcCheckbox.CoreFormElementCssClass" />
	private protected override string CoreFormElementCssClass => "form-check form-switch";
}