namespace MusicTheory.Common.Features.Notes.Creation;

/// <summary>
/// For creating notes.
/// </summary>
public interface INoteFactory
{
	/// <summary>
	/// Create a note with the associated name.
	/// </summary>
	/// <param name="name">The name of the note. 
	/// e.g. A# Bbb C
	/// </param>
	/// <returns>The note from the name given.</returns>
	Note Create(string name);

	/// <summary>
	/// Generates a random note.
	/// </summary>
	/// <returns>A new random note.</returns>
	Note CreateRandom();
}
