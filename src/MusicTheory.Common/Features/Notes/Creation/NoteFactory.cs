using MusicTheory.Common.Core.Extensions;
using MusicTheory.Common.Core.Services;
using MusicTheory.Common.Features.Accidentals;
using System.Text.RegularExpressions;

namespace MusicTheory.Common.Features.Notes.Creation;

/// <inheritdoc />
public class NoteFactory : INoteFactory
{

	private static readonly Regex validNoteRegex = new Regex(@"([A-G])([#b]*)", RegexOptions.Compiled);
	private static readonly string[] BaseNotes = new[] { "A", "B", "C", "D", "E", "F", "G" };

	private readonly IAccidentalsService _accidentalsService;
	private readonly IRandomService _randomService;

	public NoteFactory(IAccidentalsService accidentalsService, IRandomService randomService)
	{
		_accidentalsService = accidentalsService ?? throw new ArgumentNullException(nameof(accidentalsService));
		_randomService = randomService ?? throw new ArgumentNullException(nameof(randomService));
	}

	/// <inheritdoc />
	public Note Create(string name)
	{
		if (name.IsNullEmptyOrWhitespace() || !validNoteRegex.IsMatch(name))
		{
			throw new ArgumentException($"Invalid note name: '{name}'. Note names must follow the pattern [A-G] followed by optional accidentals (#, b).", nameof(name));
		}

		string accidental = _accidentalsService.GetAccidental(name);

		return new Note
		{
			Accidental = accidental,
			Name = name,
		};
	}

	/// <inheritdoc />
	public Note CreateRandom()
	{
		int noteIndex = _randomService.Next(BaseNotes.Length);
		int accidentalIndex = _randomService.Next(3);

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
