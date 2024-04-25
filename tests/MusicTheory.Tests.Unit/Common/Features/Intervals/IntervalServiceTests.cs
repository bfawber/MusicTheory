using MusicTheory.Common.Features.Accidentals;
using MusicTheory.Common.Features.Intervals;
using MusicTheory.Common.Features.Notes;
using MusicTheory.Common.Features.Scales;
using System.Collections.Generic;
using Xunit;

namespace MusicTheory.Tests.Unit;

public class IntervalServiceTests
{
	[Theory]
	[MemberData(nameof(GetAboveTestData))]
	public void GetAbove_WithValidInputs_ReturnsCorretNote(Note startingNote, IInterval interval, Note expectedOutput)
	{
		var intervalService = Create();

		var result = intervalService.GetAbove(startingNote, interval);

		Assert.Equal(expectedOutput, result);
	}

	[Theory]
	[MemberData(nameof(GetBelowTestData))]
	public void GetBelow_WithValidInputs_ReturnsCorretNote(Note startingNote, IInterval interval, Note expectedOutput)
	{
		var intervalService = Create();

		var result = intervalService.GetBelow(startingNote, interval);

		Assert.Equal(expectedOutput, result);
	}

	private IntervalService Create()
	{
		IAccidentalsService accidentalsService = new AccidentalsService();
		StepService stepService = new StepService(accidentalsService);
		MajorScaleBuilder majorScaleBuilder = new MajorScaleBuilder(stepService);

		return new IntervalService(majorScaleBuilder, accidentalsService);
	}

	public static IEnumerable<object[]> GetAboveTestData => new List<object[]>
	{
		new object[]
		{
			new Note
			{
				Name = "Gb",
				Accidental = "b",
			},
			new PerfectFifth(),
			new Note
			{
				Name = "Db",
				Accidental = "b",
			}
		},
		new object[]
		{
			new Note
			{
				Name = "C",
			},
			new AugmentedFifth(),
			new Note
			{
				Name = "G#",
				Accidental = "#",
			}
		},
	};

	public static IEnumerable<object[]> GetBelowTestData => new List<object[]>
	{
		new object[]
		{
			new Note
			{
				Name = "Gb",
				Accidental = "b",
			},
			new PerfectFifth(),
			new Note
			{
				Name = "Cb",
				Accidental = "b",
			}
		},
	};
}
