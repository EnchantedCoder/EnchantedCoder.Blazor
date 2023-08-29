using EnchantedCoder.Blazor.Components.Web.Bootstrap.Documentation.Model;

namespace EnchantedCoder.Blazor.Components.Web.Bootstrap.Documentation.Services;

public interface IComponentApiDocModelBuilder
{
	ComponentApiDocModel BuildModel(Type type);
}