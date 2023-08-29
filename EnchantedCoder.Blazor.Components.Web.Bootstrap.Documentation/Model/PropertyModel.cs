﻿using System.Reflection;
using LoxSmoke.DocXml;

namespace EnchantedCoder.Blazor.Components.Web.Bootstrap.Documentation.Model;

public class PropertyModel : MemberModel
{
	public PropertyInfo PropertyInfo { get; set; }
	public bool EditorRequired { get; set; }

	public CommonComments Comments
	{
		set
		{
			CommonComments inputComments = value;
			try { inputComments.Summary = TryFormatComment(inputComments.Summary, PropertyInfo.DeclaringType); } catch { }
			comments = inputComments;
		}
		get
		{
			return comments;
		}
	}
	private CommonComments comments;

	public bool IsStatic => this.PropertyInfo.GetAccessors(false).Any(o => o.IsStatic);
}
