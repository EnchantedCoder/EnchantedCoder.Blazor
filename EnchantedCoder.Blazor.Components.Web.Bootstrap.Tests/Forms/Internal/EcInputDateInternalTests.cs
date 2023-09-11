using EnchantedCoder.Blazor.Components.Web.Bootstrap.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnchantedCoder.Blazor.Components.Web.Bootstrap.Tests.Forms.Internal;

[TestClass]
public class EcInputDateInternalTests
{
	[TestMethod]
	public void EcInputDateInternal_GetValueFromDateTimeOffset()
	{
		// Arrange
		DateTimeOffset dateTimeOffset = DateTimeOffset.Now.Date;

		// Act + Assert

		// DateTime
		Assert.AreEqual(dateTimeOffset.DateTime, EcInputDateInternal<DateTime>.GetValueFromDateTimeOffset(dateTimeOffset));
		Assert.AreEqual(default(DateTime), EcInputDateInternal<DateTime>.GetValueFromDateTimeOffset(null));

		// DateTime?
		Assert.AreEqual(dateTimeOffset.DateTime, EcInputDateInternal<DateTime?>.GetValueFromDateTimeOffset(dateTimeOffset));
		Assert.AreEqual(null, EcInputDateInternal<DateTime?>.GetValueFromDateTimeOffset(null));

		// DateTimeOffset
		Assert.AreEqual(dateTimeOffset, EcInputDateInternal<DateTimeOffset>.GetValueFromDateTimeOffset(dateTimeOffset));
		Assert.AreEqual(default(DateTimeOffset), EcInputDateInternal<DateTimeOffset>.GetValueFromDateTimeOffset(null));

		// DateTimeOffset?
		Assert.AreEqual(dateTimeOffset, EcInputDateInternal<DateTimeOffset?>.GetValueFromDateTimeOffset(dateTimeOffset));
		Assert.AreEqual(null, EcInputDateInternal<DateTimeOffset?>.GetValueFromDateTimeOffset(null));
	}
}
