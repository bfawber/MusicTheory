using MusicTheory.Common.Features.Notes;

namespace MusicTheory.Common.Features.Intervals;

public interface IStepService
{
	Note WholeStep(Note from);

	Note HalfStep(Note from);
}
