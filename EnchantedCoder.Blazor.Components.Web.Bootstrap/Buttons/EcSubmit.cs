namespace EnchantedCoder.Blazor.Components.Web.Bootstrap;

/// <summary>
/// Button <c>&lt;button type="submit"&gt;</c>.
/// Direct ancestor of <see cref="EcButton"/> with the same API.<br />
/// Full documentation and demos: <see href="https://EnchantedCoder.blazor.eu/components/EcSubmit#EcSubmit">https://EnchantedCoder.blazor.eu/components/EcSubmit#EcSubmit</see>
/// </summary>
public class EcSubmit : EcButton
{
	private protected override string GetButtonType() => "submit";
}
