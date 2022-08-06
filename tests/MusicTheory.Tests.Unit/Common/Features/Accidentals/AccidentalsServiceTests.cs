using MusicTheory.Common.Features.Accidentals;
using Xunit;

namespace MusicTheory.Tests.Unit.Common.Features.Accidentals;

public class AccidentalsServiceTests
{
	[Theory]
	[InlineData(null, null)]
	[InlineData("", null)]
	[InlineData("A", null)]
	[InlineData("Ab", "b")]
	[InlineData("Abb", "bb")]
	[InlineData("Abbbbbb", "bbbbbb")]
	[InlineData("A#", "#")]
	[InlineData("A##", "##")]
	[InlineData("A#####", "#####")]
	public void GetAccidental_Returns_ExpectedAccidental(string input, string expectedOutput)
	{
		var accidentalService = Create();

		string result = accidentalService.GetAccidental(input);

		Assert.Equal(expectedOutput, result);
	}

	[Theory]
	[InlineData(null, "#")]
	[InlineData("", "#")]
	[InlineData("#", "##")]
	[InlineData("##", "###")]
	[InlineData("b", null)]
	[InlineData("bb", "b")]
	public void RaiseAccidental_Returns_RaisedAccidental(string input, string expectedOutput)
	{
		var accidentalService = Create();

		string result = accidentalService.RaiseAccidental(input);

		Assert.Equal(expectedOutput, result);
	}

	[Theory]
	[InlineData(null, "b")]
	[InlineData("", "b")]
	[InlineData("#", null)]
	[InlineData("####", "###")]
	[InlineData("b", "bb")]
	[InlineData("bb", "bbb")]
	public void LowerAccidental_Returns_LowersAccidental(string input, string expectedOutput)
	{
		var accidentalService = Create();

		string result = accidentalService.LowerAccidental(input);

		Assert.Equal(expectedOutput, result);
	}

	private AccidentalsService Create() => new AccidentalsService();
}
