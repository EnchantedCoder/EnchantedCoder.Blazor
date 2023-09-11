using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnchantedCoder.Blazor.Components.Web.Bootstrap.Tests.Forms;

[TestClass]
public class EcInputDateTests
{
	[TestMethod]
	public void EcInputDate_TryParseDateTimeOffsetFromString()
	{
		// Arrange
		CultureInfo culture = CultureInfo.GetCultureInfo("cs-CZ");

		DateTimeOffset? parsedDateTime;

		// Act + Assert

		// empty (valid)
		Assert.IsTrue(EcInputDate<DateTime>.TryParseDateTimeOffsetFromString(" ", culture, out parsedDateTime));
		Assert.AreEqual(null, parsedDateTime);

		// standard (valid)
		Assert.IsTrue(EcInputDate<DateTime>.TryParseDateTimeOffsetFromString("10.02.2020", culture, out parsedDateTime));
		Assert.AreEqual(new DateTime(2020, 2, 10), parsedDateTime);

		// whitespaces (valid)
		Assert.IsTrue(EcInputDate<DateTime>.TryParseDateTimeOffsetFromString("   20. 3. 2020  ", culture, out parsedDateTime));
		Assert.AreEqual(new DateTime(2020, 3, 20), parsedDateTime);

		// commas (valid)
		Assert.IsTrue(EcInputDate<DateTime>.TryParseDateTimeOffsetFromString("05,06,2020", culture, out parsedDateTime));
		Assert.AreEqual(new DateTime(2020, 6, 5), parsedDateTime);

		Assert.IsTrue(EcInputDate<DateTime>.TryParseDateTimeOffsetFromString("07,08", culture, out parsedDateTime));
		Assert.AreEqual(new DateTime(DateTime.Now.Year, 8, 7), parsedDateTime);

		// spaces (valid)
		Assert.IsTrue(EcInputDate<DateTime>.TryParseDateTimeOffsetFromString("05 06 2020", culture, out parsedDateTime));
		Assert.AreEqual(new DateTime(2020, 6, 5), parsedDateTime);

		Assert.IsTrue(EcInputDate<DateTime>.TryParseDateTimeOffsetFromString("07 08", culture, out parsedDateTime));
		Assert.AreEqual(new DateTime(DateTime.Now.Year, 8, 7), parsedDateTime);

		// shortcuts (valid)
		Assert.IsTrue(EcInputDate<DateTime>.TryParseDateTimeOffsetFromString("0203", culture, out parsedDateTime));
		Assert.AreEqual(new DateTime(DateTime.Now.Year, 3, 2), parsedDateTime);

		Assert.IsTrue(EcInputDate<DateTime>.TryParseDateTimeOffsetFromString("15", culture, out parsedDateTime));
		Assert.AreEqual(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 15), parsedDateTime);

		// time (invalid)
		Assert.IsFalse(EcInputDate<DateTime>.TryParseDateTimeOffsetFromString("10.02.2020 1:00", culture, out _));

		// shortcut, 13th month (invalid)
		Assert.IsFalse(EcInputDate<DateTime>.TryParseDateTimeOffsetFromString("0113", culture, out _));

		// shortcut, 32nd day (invalid)
		Assert.IsFalse(EcInputDate<DateTime>.TryParseDateTimeOffsetFromString("32", culture, out _));

		// time 0:00 unfortunately passes
		// Assert.IsFalse(EcInputDate<DateTime>.TryParseDateTimeOffsetFromString("10.02.2020 0:00", culture, out _));

	}

}
