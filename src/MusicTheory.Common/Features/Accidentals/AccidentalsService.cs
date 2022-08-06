using System.Text.RegularExpressions;

namespace MusicTheory.Common.Features.Accidentals;

/// <inheritdoc/>
public class AccidentalsService : IAccidentalsService
{
	private static readonly Regex accidentalRegex = new Regex(@"([A-G])([#b]+)", RegexOptions.Compiled);

	/// <inheritdoc/>
	public string GetAccidental(string note)
	{
		if (note == null) return null;

		var match = accidentalRegex.Match(note);

		if (match.Success)
		{
			return match.Groups[2].Value;
		}

		return null;
	}

	/// <inheritdoc/>
	public string RaiseAccidental(string accidental)
	{
		accidental ??= string.Empty;

		if (accidental.Contains(Constants.Sharp))
		{
			return $"{accidental}{Constants.Sharp}";
		}

		if (accidental.Contains(Constants.Flat))
		{
			var raised = accidental.Substring(0, accidental.Length - 1);
			if (raised.Length < 1)
			{
				return null;
			}

			return raised;
		}

		return Constants.Sharp;
	}

	/// <inheritdoc/>
	public string LowerAccidental(string accidental)
	{
		accidental ??= string.Empty;

		if (accidental.Contains(Constants.Flat))
		{
			return $"{accidental}{Constants.Flat}";
		}

		if (accidental.Contains(Constants.Sharp))
		{
			var lowered = accidental.Substring(0, accidental.Length - 1);
			if (lowered.Length < 1)
			{
				return null;
			}

			return lowered;
		}

		return Constants.Flat;
	}
}
