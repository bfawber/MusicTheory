using MusicTheory.Common.Features.Accidentals;
using MusicTheory.Common.Features.Intervals;
using MusicTheory.Common.Features.Notes;
using Xunit;

namespace MusicTheory.Tests.Unit;

public class IntervalServiceTests
{
	[Fact]
	public void Test()
	{
		var intervalService = new IntervalService(new Common.Features.Scales.MajorScaleBuilder(new StepService(new AccidentalsService())), new AccidentalsService());

		var result = intervalService.Get(new Note
		{
			Name = "Bb",
			Accidental = "b",
		}, new DiminishedSeventh());

		result = intervalService.Get(new Note
		{
			Name = "Bb",
			Accidental = "b",
		}, new MinorNinth());

		result = intervalService.Get(new Note
		{
			Name = "Bb",
			Accidental = "b",
		}, new MinorThird());

		result = intervalService.Get(new Note
		{
			Name = "Bb",
			Accidental = "b",
		}, new MajorSixth());

		result = intervalService.Get(new Note
		{
			Name = "Bb",
			Accidental = "b",
		}, new PerfectOctave());

		result = intervalService.Get(new Note
		{
			Name = "Bb",
			Accidental = "b",
		}, new MajorNinth());

		result = intervalService.Get(new Note
		{
			Name = "Bb",
			Accidental = "b",
		}, new MajorThirtheenth());

		result = intervalService.Get(new Note
		{
			Name = "Bb",
			Accidental = "b",
		}, new MinorThirteenth());
	}
}
