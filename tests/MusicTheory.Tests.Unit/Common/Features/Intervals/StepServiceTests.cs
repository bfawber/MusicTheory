using MusicTheory.Common.Features.Accidentals;
using MusicTheory.Common.Features.Intervals;
using MusicTheory.Common.Features.Notes;
using System;
using System.Collections.Generic;
using Xunit;

namespace MusicTheory.Tests.Unit.Common.Features.Intervals;

public class StepServiceTests
{
	[Fact]
	public void WholeStep_NullArguments_ThrowsException()
	{
		var stepService = Create();

		Assert.Throws<ArgumentNullException>(() => stepService.WholeStep(null));
	}

	[Theory]
	[MemberData(nameof(WholeStepTestData))]
	public void WholeStep_ValidInputs_ReturnsNoteWholeStepAbove(Note startingNote, Note expectedOutput)
	{
		var stepService = Create();

		var result = stepService.WholeStep(startingNote);

		Assert.Equal(expectedOutput, result);
	}

	[Fact]
	public void HalfStep_NullArguments_ThrowsException()
	{
		var stepService = Create();

		Assert.Throws<ArgumentNullException>(() => stepService.HalfStep(null));
	}

	[Theory]
	[MemberData(nameof(HalfStepTestData))]
	public void HalfStep_ValidInputs_ReturnsNoteHalfStepAbove(Note startingNote, Note expectedOutput)
	{
		var stepService = Create();

		var result = stepService.HalfStep(startingNote);

		Assert.Equal(expectedOutput, result);
	}

	private StepService Create() => new StepService(new AccidentalsService());

	public static IEnumerable<object[]> WholeStepTestData => new List<object[]>
	{
		new object[]
		{
			new Note
			{
				Name = "C"
			},
			new Note
			{
				Name = "D"
			},
		},

		new object[]
		{
			new Note
			{
				Name = "E"
			},
			new Note
			{
				Name = "F#",
				Accidental = "#",
			},
		},

		new object[]
		{
			new Note
			{
				Name = "Eb",
				Accidental = "b"
			},
			new Note
			{
				Name = "F",
			},
		},

		new object[]
		{
			new Note
			{
				Name = "Gb",
				Accidental = "b"
			},
			new Note
			{
				Name = "Ab",
				Accidental = "b"
			},
		},
	};


	public static IEnumerable<object[]> HalfStepTestData => new List<object[]>
	{
		new object[]
		{
			new Note
			{
				Name = "C"
			},
			new Note
			{
				Name = "Db",
				Accidental = "b"
			},
		},

		new object[]
		{
			new Note
			{
				Name = "E"
			},
			new Note
			{
				Name = "F",
			},
		},

		new object[]
		{
			new Note
			{
				Name = "Eb",
				Accidental = "b"
			},
			new Note
			{
				Name = "Fb",
				Accidental = "b"
			},
		},

		new object[]
		{
			new Note
			{
				Name = "Gb",
				Accidental = "b"
			},
			new Note
			{
				Name = "Abb",
				Accidental = "bb"
			},
		},
	};
}
