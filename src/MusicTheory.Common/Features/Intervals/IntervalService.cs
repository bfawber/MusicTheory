using MusicTheory.Common.Features.Accidentals;
using MusicTheory.Common.Features.Notes;
using MusicTheory.Common.Features.Scales;

namespace MusicTheory.Common.Features.Intervals;

public class IntervalService : IIntervalService
{
	private readonly MajorScaleBuilder _majorScaleBuilder;
	private readonly IAccidentalsService _accidentalsService;

	public IntervalService(MajorScaleBuilder majorScaleBuilder, IAccidentalsService accidentalsService)
	{
		_majorScaleBuilder = majorScaleBuilder;
		_accidentalsService = accidentalsService;
	}

	public Note Get(Note startingNote, IInterval interval)
	{
		var majorScale = _majorScaleBuilder.Build(startingNote);
		var currentNote = majorScale.Notes.Start;

		for(int i = 0; i < interval.NumberOfSteps; i++)
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
		if(interval.NumberOfSteps == 6 && interval.Modification == ModificationKind.Diminished)
		{
			accidental = _accidentalsService.LowerAccidental(accidental);
		}

		return new Note
		{
			Name = $"{currentNote.Item.Name.First().ToString()}{accidental}",
			Accidental = accidental,
		};
	}

	public Note GetBelow(Note startingNote, IInterval interval)
	{
		throw new NotImplementedException();
	}
}
