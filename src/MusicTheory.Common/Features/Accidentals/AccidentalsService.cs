using System.Text.RegularExpressions;

namespace MusicTheory.Common.Features.Accidentals;

public class AccidentalsService : IAccidentalsService
{
	private static readonly Regex accidentalRegex = new Regex(@"([A-G])([#b]+)", RegexOptions.Compiled);

	public string GetAccidental(string note)
	{
		var match = accidentalRegex.Match(note);

		if (match.Success)
		{
			return match.Groups[2].Value;
		}

		return string.Empty;
	}

	public string RaiseAccidental(string accidental)
	{
		if (accidental.Contains(Constants.Sharp))
		{
			return $"{accidental}{Constants.Sharp}";
		}

		if (accidental.Contains(Constants.Flat))
		{
			return accidental.Substring(0, accidental.Length - 1);
		}

		return Constants.Sharp;
	}


	public string LowerAccidental(string accidental)
	{
		if (accidental.Contains(Constants.Flat))
		{
			return $"{accidental}{Constants.Flat}";
		}

		if (accidental.Contains(Constants.Sharp))
		{
			return accidental.Substring(0, accidental.Length - 1);
		}

		return Constants.Flat;
	}
}
