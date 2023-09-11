namespace EnchantedCoder.Blazor.Components.Web;

/// <summary>
/// Base class for icons.
/// </summary>
public abstract class IconBase
{
	/// <summary>
	/// Renderer of the icon. Must have a Icon property which receives the instance of the icon (IconBase descendant instance).
	/// See BootstrapIcon and <see cref="EcIcon"/> implementations for more details.
	/// </summary>
	public abstract Type RendererComponentType { get; }
}
