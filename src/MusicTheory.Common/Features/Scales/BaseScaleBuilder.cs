using MusicTheory.Common.DataStructures;
using MusicTheory.Common.Features.Intervals;
using MusicTheory.Common.Features.Notes;

namespace MusicTheory.Common.Features.Scales;

public abstract class BaseScaleBuilder
{
	protected readonly List<ScaleStepKind> ScaleSteps = new List<ScaleStepKind> { ScaleStepKind.Whole, ScaleStepKind.Whole, ScaleStepKind.Half, ScaleStepKind.Whole, ScaleStepKind.Whole, ScaleStepKind.Whole, ScaleStepKind.Half };
	private readonly IStepService _stepService;

	protected BaseScaleBuilder(IStepService stepService, params ScaleStepKind[] scaleSteps)
	{
		_stepService = stepService;
		ScaleSteps = scaleSteps.ToList();
	}

	public virtual Scale Build(Note startingNote)
	{
		Scale result = new Scale();
		var current = new ListItem<Note>
		{
			Item = startingNote,
		};

		result.Notes.Add(current);

		foreach (var step in ScaleSteps)
		{
			var nextNote = step switch
			{
				ScaleStepKind.Whole => _stepService.WholeStep(current.Item),
				ScaleStepKind.Half => _stepService.HalfStep(current.Item),
				_ => throw new InvalidOperationException()
			};

			current = new ListItem<Note>
			{
				Item = nextNote,
			};

			if(nextNote != startingNote)
			{
				result.Notes.Add(current);
			}
		}

		return result;
	}
}
