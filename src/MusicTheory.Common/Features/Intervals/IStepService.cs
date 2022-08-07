using MusicTheory.Common.Features.Notes;

namespace MusicTheory.Common.Features.Intervals;

/// <summary>
/// For performing half and whole steps.
/// </summary>
public interface IStepService
{
	/// <summary>
	/// Returns the note a whole step up from the provided note.
	/// </summary>
	/// <param name="from">The note to start on.</param>
	/// <returns>the note a whole step up from the provided note.</returns>
	Note WholeStep(Note from);

	/// <summary>
	/// Returns the note a half step up from the provided note.
	/// </summary>
	/// <param name="from">The note to start on.</param>
	/// <returns>the note a half step up from the provided note.</returns>
	Note HalfStep(Note from);
}
