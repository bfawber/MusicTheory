using MusicTheory.Common.Features.Accidentals;
using MusicTheory.Common.Features.Notes;
using MusicTheory.Common.Features.Notes.Creation;
using System;
using System.Collections.Generic;
using Xunit;

namespace MusicTheory.Tests.Unit.Common.Features.Notes.Creation;

public class NoteFactoryTests
{
	[Theory]
	[InlineData(null)]
	[InlineData("")]
	[InlineData(" ")]
	[InlineData(" \t\t\r\n		")]
	[InlineData("badnote")]
	public void Create_InvalidArguments_ThrowsException(string name)
	{
		var factory = Create();

		Assert.Throws<ArgumentException>(() => factory.Create(name));
	}

	[Theory]
	[MemberData(nameof(NotesTests))]
	public void Create_WithValidNoteName_CreatesNote(string name, Note expectedNote)
	{
		var factory = Create();

		var note = factory.Create(name);

		Assert.Equal(expectedNote, note);
	}

	[Fact]
	public void GetRandomNote_Creates_RandomNewNote()
	{
		var factory = Create();

		var note = factory.GetRandomNote();

		Assert.IsType<Note>(note);
	}

	private NoteFactory Create() => new NoteFactory(new AccidentalsService());

	public static IEnumerable<object[]> NotesTests => new List<object[]>
	{
		new object[]
		{
			"C",
			new Note
			{
				Name = "C",
			}
		},

		new object[]
		{
			"Ab",
			new Note
			{
				Name = "Ab",
				Accidental = "b",
			}
		},

		new object[]
		{
			"C##",
			new Note
			{
				Name = "C##",
				Accidental = "##",
			}
		},
	};
}
