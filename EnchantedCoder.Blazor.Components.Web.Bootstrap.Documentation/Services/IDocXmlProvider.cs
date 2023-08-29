using LoxSmoke.DocXml;

namespace EnchantedCoder.Blazor.Components.Web.Bootstrap.Documentation.Services;
public interface IDocXmlProvider
{
	DocXmlReader GetDocXmlReaderFor(string docXmlResourceName);
}