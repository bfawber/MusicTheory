using MusicTheory.Common.Core.Extensions;
using MusicTheory.Common.Features.Accidentals;
using System.Text.RegularExpressions;

namespace MusicTheory.Common.Features.Notes.Creation;

/// <inheritdoc />
public class NoteFactory : INoteFactory
{

	private static readonly Regex validNoteRegex = new Regex(@"([A-G])([#b]*)", RegexOptions.Compiled);
	private static readonly string[] BaseNotes = new[] { "A", "B", "C", "D", "E", "F", "G" };

	private readonly IAccidentalsService _accidentaLService;
	private readonly Random _random = new Random();

	public NoteFactory(IAccidentalsService accidentaLService)
	{
		_accidentaLService = accidentaLService ?? throw new ArgumentNullException(nameof(accidentaLService));
	}

	/// <inheritdoc />
	public Note Create(string name)
	{
		if (name.IsNullEmptyOrWhitespace() || !validNoteRegex.IsMatch(name))
		{
			throw new ArgumentException(nameof(name));
		}

		string accidental = _accidentaLService.GetAccidental(name);

		return new Note
		{
			Accidental = accidental,
			Name = name,
		};
	}

	/// <inheritdoc />
	public Note CreateRandom()
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
