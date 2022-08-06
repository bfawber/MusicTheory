﻿using MusicTheory.Common.Features.Accidentals;

namespace MusicTheory.Common.Features.Notes.Creation;

/// <inheritdoc />
public class NoteFactory : INoteFactory
{
	private static readonly string[] BaseNotes = new[] { "A", "B", "C", "D", "E", "F", "G" };

	private readonly IAccidentalsService _accidentaLService;
	private readonly Random _random = new Random();

	public NoteFactory(IAccidentalsService accidentaLService)
	{
		_accidentaLService = accidentaLService;
	}

	/// <inheritdoc />
	public Note Create(string name)
	{
		string accidental = _accidentaLService.GetAccidental(name);

		return new Note
		{
			Accidental = accidental,
			Name = name,
		};
	}

	/// <inheritdoc />
	public Note GetRandomNote()
	{
		int noteIndex = _random.Next(BaseNotes.Length);
		int accidentalIndex = _random.Next(3);

		string accidental = accidentalIndex switch
		{
			0 => string.Empty,
			1 => Constants.Sharp,
			2 => Constants.Flat,
			_ => throw new ArgumentOutOfRangeException(),
		};

		return Create($"{BaseNotes[noteIndex]}{accidental}");
	}
}