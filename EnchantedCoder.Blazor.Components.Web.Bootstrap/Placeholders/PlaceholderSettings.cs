namespace EnchantedCoder.Blazor.Components.Web.Bootstrap;

/// <summary>
/// Settings for the <see cref="EcPlaceholder"/> and derived components.
/// </summary>
public record PlaceholderSettings
{
	/// <summary>
	/// Size of the placeholder.
	/// </summary>
	public PlaceholderSize? Size { get; set; }

	/// <summary>
	/// Explicit color of the placeholder.
	/// </summary>
	public ThemeColor? Color { get; set; }

	/// <summary>
	/// Additional CSS class for <see cref="EcPlaceholder"/>.
	/// </summary>
	public string CssClass { get; set; }
}
