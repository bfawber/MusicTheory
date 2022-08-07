using MusicTheory.Common.Core.DataStructures;
using MusicTheory.Common.Features.Intervals;
using MusicTheory.Common.Features.Notes;

namespace MusicTheory.Common.Features.Scales;

public abstract class BaseScaleBuilder
{
	protected readonly List<ScaleStepKind> ScaleSteps = new List<ScaleStepKind> { ScaleStepKind.Whole, ScaleStepKind.Whole, ScaleStepKind.Half, ScaleStepKind.Whole, ScaleStepKind.Whole, ScaleStepKind.Whole, ScaleStepKind.Half };
	private readonly IStepService _stepService;

	protected BaseScaleBuilder(IStepService stepService, params ScaleStepKind[] scaleSteps)
	{
		_stepService = stepService ?? throw new ArgumentNullException(nameof(stepService));
		ScaleSteps = scaleSteps.ToList();
	}

	public virtual Scale Build(Note startingNote)
	{
		if(startingNote == null)
		{
			throw new ArgumentNullException(nameof(startingNote));
		}

		Scale result = new Scale();
		var current = startingNote;

		result.Notes.Add(current);

		foreach (var step in ScaleSteps)
		{
			var nextNote = step switch
			{
				ScaleStepKind.Whole => _stepService.WholeStep(current),
				ScaleStepKind.Half => _stepService.HalfStep(current),
				_ => throw new InvalidOperationException()
			};

			current = nextNote;

			if (nextNote != startingNote)
			{
				result.Notes.Add(current);
			}
		}

		return result;
	}
}
