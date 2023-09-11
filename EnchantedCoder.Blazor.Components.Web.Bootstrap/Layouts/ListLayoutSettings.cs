namespace EnchantedCoder.Blazor.Components.Web.Bootstrap;

/// <summary>
/// Settings for the <see cref="EcListLayout"/> and derived components.
/// </summary>
public record ListLayoutSettings
{
	/// <summary>
	/// Additional CSS classes for the wrapping <c>div</c>.
	/// </summary>
	public string CssClass { get; set; }

	/// <summary>
	/// Settings for the wrapping <see cref="EcCard"/>.
	/// </summary>
	public CardSettings CardSettings { get; set; }

	/// <summary>
	/// Settings for the <see cref="EcButton"/> opening filtering offcanvas.
	/// </summary>
	public ButtonSettings FilterOpenButtonSettings { get; set; }

	/// <summary>
	/// Settings for the <see cref="EcButton"/> submitting the filter.
	/// </summary>
	public ButtonSettings FilterSubmitButtonSettings { get; set; }

	/// <summary>
	/// Settings for the <see cref="EcOffcanvas"/> with the filter.
	/// </summary>
	public OffcanvasSettings FilterOffcanvasSettings { get; set; }
}
