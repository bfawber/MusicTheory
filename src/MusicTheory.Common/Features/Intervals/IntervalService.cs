using MusicTheory.Common.Features.Accidentals;
using MusicTheory.Common.Features.Notes;
using MusicTheory.Common.Features.Scales;

namespace MusicTheory.Common.Features.Intervals;

/// <inheritdoc />
public class IntervalService : IIntervalService
{
	private readonly MajorScaleBuilder _majorScaleBuilder;
	private readonly IAccidentalsService _accidentalsService;

	public IntervalService(MajorScaleBuilder majorScaleBuilder, IAccidentalsService accidentalsService)
	{
		_majorScaleBuilder = majorScaleBuilder ?? throw new ArgumentNullException(nameof(majorScaleBuilder));
		_accidentalsService = accidentalsService ?? throw new ArgumentNullException(nameof(accidentalsService));
	}

	/// <inheritdoc />
	public Note GetAbove(Note startingNote, IInterval interval)
	{
		var majorScale = _majorScaleBuilder.Build(startingNote);
		var currentNote = majorScale.Notes.Start;

		for (int i = 0; i < interval.NumberOfSteps; i++)
		{
			currentNote = currentNote.Next;
		}

		string accidental = currentNote.Item.Accidental;

		switch (interval.Modification)
		{
			case ModificationKind.Minor:
			case ModificationKind.Diminished:
				accidental = _accidentalsService.LowerAccidental(currentNote.Item.Accidental);
				break;
			case ModificationKind.Augmented:
				accidental = _accidentalsService.RaiseAccidental(currentNote.Item.Accidental);
				break;
		}

		// sevenths are special
		if (interval.NumberOfSteps == 6 && interval.Modification == ModificationKind.Diminished)
		{
			accidental = _accidentalsService.LowerAccidental(accidental);
		}

		return new Note
		{
			Name = $"{currentNote.Item.Name.First().ToString()}{accidental}",
			Accidental = accidental,
		};
	}

	/// <inheritdoc />
	public Note GetBelow(Note startingNote, IInterval interval)
	{
		var majorScale = _majorScaleBuilder.Build(startingNote);
		var currentNote = majorScale.Notes.Start;

		for (int i = 0; i < interval.NumberOfSteps; i++)
		{
			currentNote = currentNote.Prev;
		}

		string accidental = currentNote.Item.Accidental;

		switch (interval.Modification)
		{
			case ModificationKind.Diminished:
				accidental = _accidentalsService.RaiseAccidental(currentNote.Item.Accidental);
				break;

			case ModificationKind.Major:
			case ModificationKind.Augmented:
				accidental = _accidentalsService.LowerAccidental(currentNote.Item.Accidental);
				break;
		}

		return new Note
		{
			Name = $"{currentNote.Item.Name.First().ToString()}{accidental}",
			Accidental = accidental,
		};
	}
}
