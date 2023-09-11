namespace EnchantedCoder.Blazor.Components.Web.Bootstrap.Documentation.Services;

public static class ApiTypeHelper
{
	private static readonly Dictionary<string, Type> delegateTypes = new()
	{
		["AutosuggestDataProviderDelegate"] = typeof(AutosuggestDataProviderDelegate<>),
		["GridDataProviderDelegate"] = typeof(GridDataProviderDelegate<>),
		["InputTagsDataProviderDelegate"] = typeof(InputTagsDataProviderDelegate),
		["CalendarDateCustomizationProviderDelegate"] = typeof(CalendarDateCustomizationProviderDelegate),
		["SearchBoxDataProviderDelegate"] = typeof(SearchBoxDataProviderDelegate<>),
	};

	public static bool IsLibraryType(string typeText)
	{
		try
		{
			Type type = GetType(typeText);
			if (type is null)
			{
				return false;
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	public static bool IsDelegate(Type type)
	{
		return typeof(Delegate).IsAssignableFrom(type);
	}

	public static Type GetType(string typeName)
	{
		Type result;

		// Formatting typeName.
		int openingBracePosition = typeName.IndexOf("<");
		if (openingBracePosition > 0)
		{
			typeName = typeName.Remove(openingBracePosition, typeName.Length - openingBracePosition);
		}

		// Handling delegate types, all other types are found by the Type.GetType() method.
		delegateTypes.TryGetValue(typeName, out result);
		if (result is not null)
		{
			return result;
		}

		try
		{
			result = Type.GetType($"EnchantedCoder.Blazor.Components.Web.Bootstrap.{typeName}, EnchantedCoder.Blazor.Components.Web.Bootstrap");
			if (result is not null)
			{
				return result;
			}
		}
		catch { }

		try
		{
			result = Type.GetType($"EnchantedCoder.Blazor.Components.Web.{typeName}, EnchantedCoder.Blazor.Components.Web");
			if (result is not null)
			{
				return result;
			}
		}
		catch { }

		try
		{
			result = typeof(EcButton).Assembly.GetTypes().FirstOrDefault((t) => t.FullName.Contains(typeName));
			if (result is not null)
			{
				return result;
			}
		}
		catch { }

		return null;
	}
}
