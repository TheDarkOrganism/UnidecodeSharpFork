namespace UnidecodeSharpFork
{
	/// <summary>
	/// ASCII transliterations of Unicode text
	/// </summary>
	public static class Unidecoder
	{
		/// <summary>
		/// The unicode characters used.
		/// </summary>
		private static IReadOnlyDictionary<int, IReadOnlyList<string>> Characters { get; } = JsonConvert.DeserializeObject<Dictionary<int, IReadOnlyList<string>>>(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "UnidecodeSharpFork", "Unicode.json"))) ?? new();

		/// <summary>
		/// Transliterate Unicode string to ASCII string.
		/// </summary>
		/// <param name="input">
		/// String you want to transliterate into ASCII
		/// </param>
		/// <returns>
		/// ASCII string. There are [?] (3 characters) in places of some unknown(?) unicode characters.
		/// It is this way in Python code as well.
		/// </returns>
		public static string Unidecode(this string? input)
		{
			return input is null or "" ? string.Empty : input.All(x => x < 0x80)
				? input
				: string.Join(string.Empty, input.Select(c => c < 0x80 ? c.ToString() : Characters.TryGetValue(c >> 8, out IReadOnlyList<string>? transliterations) ? transliterations[c & 0xff] : default));
		}

		/// <summary>
		/// Transliterate Unicode character to ASCII string.
		/// </summary>
		/// <param name="c">
		/// Character you want to transliterate into ASCII
		/// </param>
		/// <returns>
		/// ASCII string. Unknown(?) unicode characters will return [?] (3 characters).
		/// It is this way in Python code as well.
		/// </returns>
		public static string Unidecode(this char c)
		{
			return c < 0x80
				? c.ToString()
				: Characters.TryGetValue(c >> 8, out IReadOnlyList<string>? transliterations) ? transliterations[c & 0xff] : string.Empty;
		}
	}
}
