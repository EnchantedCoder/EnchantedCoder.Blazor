﻿namespace EnchantedCoder.Blazor.Components.Web.Bootstrap.Documentation.Shared.Components;

public class TypeLink : ComponentBase
{
	[Parameter] public Type Type { get; set; }

	[Parameter] public RenderFragment ChildContent { get; set; }

	private string GetLinkUrl()
	{
		string urlSegment = Type.FullName
			.Replace("EnchantedCoder.Blazor.Components.Web.Bootstrap", "EnchantedCoder!Blazor!Components!Web!Bootstrap")
			.Replace("EnchantedCoder.Blazor.Components.Web", "EnchantedCoder!Blazor!Components!Web")
			.Replace(".", "/")
			.Replace("!", ".");

		return "https://dev.azure.com/EnchantedCoder/DEV/_git/002.HFW-EnchantedCoderBlazor?path=" + System.Net.WebUtility.UrlEncode("/" + urlSegment + ".cs");
	}

	protected override void BuildRenderTree(RenderTreeBuilder builder)
	{
		// no base call
		builder.OpenElement(1, "a");
		builder.AddAttribute(2, "href", GetLinkUrl());

		if (ChildContent != null)
		{
			builder.AddContent(3, ChildContent);
		}
		else
		{
			builder.AddContent(4, Type.Name);
		}

		builder.CloseElement();
	}
}
