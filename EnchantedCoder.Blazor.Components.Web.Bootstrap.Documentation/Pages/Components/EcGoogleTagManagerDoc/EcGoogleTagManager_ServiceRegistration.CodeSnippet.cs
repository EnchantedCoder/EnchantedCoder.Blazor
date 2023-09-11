builder.Services.AddEcGoogleTagManager(options =>
{
	builder.Configuration.Bind("EcGoogleTagManager", options);
});