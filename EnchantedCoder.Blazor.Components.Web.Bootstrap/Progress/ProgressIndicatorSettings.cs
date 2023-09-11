namespace EnchantedCoder.Blazor.Components.Web.Bootstrap;

/// <summary>
/// Settings for the <see cref="EcProgressIndicator"/> and derived components.
/// </summary>
public record ProgressIndicatorSettings
{
	/// <summary>
	/// Debounce delay in milliseconds.
	/// </summary>
	public int? Delay { get; set; }
}
