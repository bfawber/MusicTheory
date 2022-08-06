using MusicTheory.Common.Core.DataStructures;
using MusicTheory.Common.Features.Accidentals;
using MusicTheory.Common.Features.Notes;

namespace MusicTheory.Common.Features.Intervals;

public class StepService : IStepService
{
	private HashSet<string> _specialSteps = new HashSet<string> { "B", "E" };
	private readonly Linked<string> BaseSteps = new Linked<string>("A", "B", "C", "D", "E", "F", "G");
	private readonly IAccidentalsService _accidentalsService;

	public StepService(IAccidentalsService accidentalsService)
	{
		_accidentalsService = accidentalsService;
	}

	public Note HalfStep(Note from)
	{
		var wholeStep = WholeStep(from);

		string baseNoteValue = wholeStep.Name.First().ToString().ToUpper();
		string accidental = _accidentalsService.LowerAccidental(wholeStep.Accidental);

		return new Note
		{
			Name = $"{baseNoteValue}{accidental}",
			Accidental = accidental,
		};
	}

	public Note WholeStep(Note from)
	{
		string baseNoteValue = from.Name.First().ToString().ToUpper();
		string accidental = _accidentalsService.GetAccidental(from.Name);
		var start = BaseSteps.GetListItem(baseNoteValue);
		string nextBaseNoteValue = start.Next.Item;

		if (_specialSteps.Contains(baseNoteValue))
		{
			accidental = _accidentalsService.RaiseAccidental(accidental);
		}

		return new Note
		{
			Name = $"{nextBaseNoteValue}{accidental}",
			Accidental = accidental,
		};
	}
}
