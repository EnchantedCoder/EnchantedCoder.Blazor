namespace EnchantedCoder.Blazor.Components.Web.Bootstrap;

/// <summary>
/// Data provider (delegate) for <see cref="EcInputTags" />.
/// </summary>
public delegate Task<InputTagsDataProviderResult> InputTagsDataProviderDelegate(InputTagsDataProviderRequest request);

