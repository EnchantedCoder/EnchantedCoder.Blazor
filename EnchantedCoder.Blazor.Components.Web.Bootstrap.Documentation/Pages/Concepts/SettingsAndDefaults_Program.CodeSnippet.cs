public class Startup
{
	public void ConfigureServices(IServiceCollection services)
	{
		services.AddRazorPages();

		services.AddEcServices();
		services.AddEcMessenger();
		services.AddEcMessageBoxHost();

		SetEcComponents();
	}

	private static void SetEcComponents()
	{
		EcPlaceholderContainer.Defaults.Animation = PlaceholderAnimation.Glow;
		EcPlaceholder.Defaults.Color = ThemeColor.Light;

		EcButton.Defaults.Size = ButtonSize.Small;

		EcOffcanvas.Defaults.Backdrop = OffcanvasBackdrop.Static;
		EcOffcanvas.Defaults.HeaderCssClass = "border-bottom";
		EcOffcanvas.Defaults.FooterCssClass = "border-top";

		EcChipList.Defaults.ChipBadgeSettings.Color = ThemeColor.Light;
		EcChipList.Defaults.ChipBadgeSettings.TextColor = ThemeColor.Dark;
		EcChipList.Defaults.ChipBadgeSettings.CssClass = "p-2 rounded-pill";
	}
}