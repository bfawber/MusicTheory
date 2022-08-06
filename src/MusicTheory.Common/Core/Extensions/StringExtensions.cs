namespace MusicTheory.Common.Core.Extensions;

public static class StringExtensions
{
	public static bool IsNullEmptyOrWhitespace(this string str) => string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str);
}
