using MusicTheory.Common.Features.Accidentals;
using MusicTheory.Common.Features.Intervals;
using MusicTheory.Common.Features.Notes;
using MusicTheory.Common.Features.Scales;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MusicTheory.Tests.Unit.Common.Features.Scales;

public class MajorScaleBuilderTests
{
	[Fact]
	public void Build_NullArguments_ThrowsException()
	{
		var scaleBuilder = Create();

		Assert.Throws<ArgumentNullException>(() => scaleBuilder.Build(null));
	}

	[Theory]
	[MemberData(nameof(TestData))]
	public void Build_ValidInputs_BuildsExpectedScale(Note startingNote, string[] expectedScale)
	{
		var scaleBuilder = Create();

		var scale = scaleBuilder.Build(startingNote);

		Assert.Equal(expectedScale.Length, scale.Notes.Count());
		Assert.Empty(expectedScale.Except(scale.Notes.Select(x => x.Name)));
	}

	private MajorScaleBuilder Create() => new MajorScaleBuilder(new StepService(new AccidentalsService()));

	public static IEnumerable<object[]> TestData => new List<object[]>
	{
		new object[]
		{
			new Note
			{
				Name = "C"
			},
			new string[] { "C", "D", "E", "F", "G", "A", "B", }
		},

		new object[]
		{
			new Note
			{
				Name = "Eb",
				Accidental = "b"
			},
			new string[] { "Eb", "F", "G", "Ab", "Bb", "C", "D", }
		},

		new object[]
		{
			new Note
			{
				Name = "D",
			},
			new string[] { "D", "E", "F#", "G", "A", "B", "C#", }
		},

		new object[]
		{
			new Note
			{
				Name = "F#",
				Accidental = "#"
			},
			new string[] { "F#", "G#", "A#", "B", "C#", "D#", "E#", }
		},
	};
}