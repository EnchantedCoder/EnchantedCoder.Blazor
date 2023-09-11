using System.Globalization;
using BlazorAppTest.Resources;
using EnchantedCoder.Blazor.Components.Web;
using EnchantedCoder.Blazor.GoogleTagManager;

namespace BlazorAppTest;

public class Startup
{
	public Startup(IConfiguration configuration)
	{
		Configuration = configuration;
	}

	public IConfiguration Configuration { get; }

	// This method gets called by the runtime. Use this method to add services to the container.
	// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
	public void ConfigureServices(IServiceCollection services)
	{
		services.AddLogging();

		services.AddLocalization();
		services.AddGeneratedResourceWrappers();

		services.AddRazorPages();
		services.AddServerSideBlazor();

		services.AddEcMessenger();
		services.AddEcMessageBoxHost();
		services.AddEcGoogleTagManager(options =>
		{
			options.GtmId = "GTM-W2CT4P6"; // EnchantedCoder.Blazor.GoogleTagManager DEV test
		});

		// TESTs for Defaults
		//EcAutosuggest.Defaults.InputSize = InputSize.Large;
		//EcInputText.Defaults.InputSize = InputSize.Large;
		//EcInputNumber.Defaults.InputSize = InputSize.Large;
		//EcSelect.Defaults.InputSize = InputSize.Large;
		//EcInputDate.Defaults.InputSize = InputSize.Large;
		//EcInputDateRange.Defaults.InputSize = InputSize.Large;
		//EcCalendar.Defaults.DateCustomizationProvider = request => new CalendarDateCustomizationResult { Enabled = request.Date < DateTime.Today };
		//EcMessageBox.Defaults.ModalSettings.Centered = true;
	}

	// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
	public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
	{
		if (env.IsDevelopment())
		{
			app.UseDeveloperExceptionPage();
		}
		else
		{
			app.UseExceptionHandler("/Error");
			// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
			app.UseHsts();
		}

		app.UseHttpsRedirection();
		app.UseStaticFiles();
		app.UseRequestLocalization(o =>
		{
			CultureInfo cs = new CultureInfo("cs-CZ");
			o.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(cs);
			o.AddSupportedCultures("cs", "en-US");
			o.AddSupportedUICultures("cs", "en-US");
		});

		app.UseRouting();

		app.UseEndpoints(endpoints =>
		{
			endpoints.MapBlazorHub();
			endpoints.MapControllers();
			endpoints.MapFallbackToPage("/_Host");
		});
	}
}
