namespace MusicTheory.Common.Features.Accidentals;

/// <summary>
/// For performing accidental related operations.
/// </summary>
public interface IAccidentalsService
{
	/// <summary>
	/// Get the accidental from a provieded note name.
	/// </summary>
	/// <param name="note">The name of the note to get the accidental on.</param>
	/// <returns>The accidental string.</returns>
	string GetAccidental(string note);

	/// <summary>
	/// Raises the accidental provided.
	/// </summary>
	/// <param name="accidental">The accidental to raise.</param>
	/// <returns>The accidental as a result of raising the one provided.</returns>
	string RaiseAccidental(string accidental);

	/// <summary>
	/// Lowers the accidental provided.
	/// </summary>
	/// <param name="accidental">The accidental to lower.</param>
	/// <returns>The accidental as a result of lowering the one provided.</returns>
	string LowerAccidental(string accidental);
}
