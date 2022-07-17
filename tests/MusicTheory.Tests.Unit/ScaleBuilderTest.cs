using MusicTheory.Common.Features.Accidentals;
using MusicTheory.Common.Features.Intervals;
using MusicTheory.Common.Features.Scales;
using System.Linq;
using Xunit;

namespace MusicTheory.Tests.Unit;

public class ScaleBuilderTest
{
	[Fact]
	public void Test1()
	{
		BaseScaleBuilder builder = new MajorScaleBuilder(new StepService(new AccidentalsService()));

		var scale = builder.Build(new Note { Name = "Db" });

		var sclaeEnumerated = string.Join(",", scale.Notes.Select(x => x.Name).ToList());
	}
}