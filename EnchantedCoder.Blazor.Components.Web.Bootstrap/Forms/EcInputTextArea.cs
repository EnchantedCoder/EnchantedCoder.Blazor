namespace EnchantedCoder.Blazor.Components.Web.Bootstrap;

/// <summary>
/// <see href="https://getbootstrap.com/docs/5.3/forms/floating-labels/#textareas" target="_blank">Textarea</see>.
/// To set a custom height, do not use the rows attribute. Instead, set an explicit height (either inline or via custom CSS).<br />
/// Full documentation and demos: <see href="https://EnchantedCoder.blazor.eu/components/EcInputTextArea">https://EnchantedCoder.blazor.eu/components/EcInputTextArea</see>
/// </summary>
public class EcInputTextArea : EcInputText
{
	/// <inheritdoc />
	private protected override string GetElementName() => "textarea";

	/// <inheritdoc />
	private protected override string GetTypeAttributeValue() => null;
}
