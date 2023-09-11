﻿using System.Reflection;
using Microsoft.JSInterop;

namespace EnchantedCoder.Blazor.Components.Web;
public static class JSRuntimeExtensions
{
	public static ValueTask<IJSObjectReference> ImportModuleAsync(this IJSRuntime jsRuntime, string modulePath, Assembly assemblyForVersionInfo = null)
	{
		Contract.Requires<ArgumentException>(!String.IsNullOrWhiteSpace(modulePath));

		if (assemblyForVersionInfo is not null)
		{
			modulePath = modulePath + "?v=" + GetAssemblyVersionIdentifierForUri(assemblyForVersionInfo);
		}
		return jsRuntime.InvokeAsync<IJSObjectReference>("import", modulePath);
	}

	internal static ValueTask<IJSObjectReference> ImportEnchantedCoderBlazorWebModuleAsync(this IJSRuntime jsRuntime, string moduleNameWithoutExtension)
	{
		versionIdentifierEnchantedCoderBlazorWeb ??= GetAssemblyVersionIdentifierForUri(typeof(EcDynamicElement).Assembly);

		var path = "./_content/EnchantedCoder.Blazor.Components.Web/" + moduleNameWithoutExtension + ".js?v=" + versionIdentifierEnchantedCoderBlazorWeb;
		return jsRuntime.InvokeAsync<IJSObjectReference>("import", path);
	}
	private static string versionIdentifierEnchantedCoderBlazorWeb;

	internal static string GetAssemblyVersionIdentifierForUri(Assembly assembly)
	{
		return Uri.EscapeDataString(((AssemblyInformationalVersionAttribute)Attribute.GetCustomAttribute(assembly, typeof(AssemblyInformationalVersionAttribute), false)).InformationalVersion);
	}
}
