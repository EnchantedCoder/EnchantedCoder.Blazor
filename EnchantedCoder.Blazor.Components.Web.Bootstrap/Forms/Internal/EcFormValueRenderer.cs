namespace EnchantedCoder.Blazor.Components.Web.Bootstrap.Internal;

/// <summary>
/// Default <see cref="IFormValueComponent" /> renderer.
/// </summary>
public class EcFormValueRenderer : FormValueRenderer
{
	/// <summary>
	/// Adds <see cref="EcFormValueComponentRenderer"/> to a builder.
	/// </summary>
	public override void Render(int sequence, RenderTreeBuilder builder, IFormValueComponent data)
	{
		builder.OpenRegion(sequence);

		builder.OpenComponent(0, typeof(EcFormValueComponentRenderer));
		builder.AddAttribute(1, nameof(EcFormValueComponentRenderer.FormValueComponent), data);
		builder.CloseComponent();

		builder.CloseRegion();
	}

}
