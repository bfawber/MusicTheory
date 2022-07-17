using MusicTheory.Common.Features.Intervals;

namespace MusicTheory.Common.Features.Scales;

public class MajorScaleBuilder : BaseScaleBuilder
{
	public MajorScaleBuilder(IStepService stepService) : base(stepService, ScaleStepKind.Whole, ScaleStepKind.Whole, ScaleStepKind.Half, ScaleStepKind.Whole, ScaleStepKind.Whole, ScaleStepKind.Whole, ScaleStepKind.Half)
	{
	}
}
