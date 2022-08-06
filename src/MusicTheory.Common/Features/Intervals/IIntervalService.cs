using MusicTheory.Common.Features.Notes;

namespace MusicTheory.Common.Features.Intervals;

/// <summary>
/// For performing interval related operations.
/// </summary>
public interface IIntervalService
{
	/// <summary>
	/// Get's the note that's the interval above the starting note.
	/// </summary>
	/// <param name="startingNote">The starting note.</param>
	/// <param name="interval">The interval above to get.</param>
	/// <returns>The note that's the interval above the starting note.</returns>
	Note GetAbove(Note startingNote, IInterval interval);

	/// <summary>
	/// Get's the note that's the interval below the starting note..
	/// </summary>
	/// <param name="startingNote">The starting note.</param>
	/// <param name="interval">The interval below to get.</param>
	/// <returns>The note that's the interval above the starting note.</returns>
	Note GetBelow(Note startingNote, IInterval interval);
}
