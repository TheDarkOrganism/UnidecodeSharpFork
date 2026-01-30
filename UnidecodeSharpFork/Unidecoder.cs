using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;

namespace UnidecodeSharpFork
{
	/// <summary>
	/// ASCII transliterations of Unicode text
	/// </summary>
	public static class Unidecoder
	{
		private const string _unicodeFile = "Unicode.json";

#if !NET10_0_OR_GREATER
		private static Dictionary<int, IReadOnlyList<string>>? _characters;
#endif

		/// <summary>
		/// The unicode characters used.
		/// </summary>
		private static Dictionary<int, IReadOnlyList<string>> Characters
		{
			get
			{
				if (
#if NET10_0_OR_GREATER
				field
#else
				_characters
#endif
				is null)
				{
					using Stream? stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"{nameof(UnidecodeSharpFork)}.{_unicodeFile}") ?? throw new FileNotFoundException(null, _unicodeFile);

#if NET10_0_OR_GREATER
					field
#else
					_characters
#endif
					= JsonSerializer.Deserialize<Dictionary<int, IReadOnlyList<string>>>(stream) ??
#if NET8_0_OR_GREATER
					[];
#else
					new Dictionary<int, IReadOnlyList<string>>();
#endif
				}


#if NET10_0_OR_GREATER
				return field;			
#else
				return _characters;
#endif
			}
		}

#if NET10_0_OR_GREATER
		#pragma warning disable IDE0055 // Fix formatting

		extension(string? input)
		{
#endif

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
#if NET10_0_OR_GREATER
		public string Unidecode()
#else
		public static string Unidecode(this string? input)
#endif
		{
			return string.IsNullOrEmpty(input) ? string.Empty : input.All(x => x < 0x80)
				? input
				: string.Join(string.Empty, input.Select(c => c < 0x80 ? c.ToString() : Characters.TryGetValue(c >> 8, out IReadOnlyList<string>? transliterations) ? transliterations[c & 0xff] : default));
		}

#if NET10_0_OR_GREATER
		}

		#pragma warning restore IDE0055 // Fix formatting
#endif

#if NET10_0_OR_GREATER
		#pragma warning disable IDE0055 // Fix formatting

		extension(char c)
		{
#endif

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
#if NET10_0_OR_GREATER
		public string Unidecode()
#else
		public static string Unidecode(this char c)
#endif
		{
			return c < 0x80
				? c.ToString()
				: Characters.TryGetValue(c >> 8, out IReadOnlyList<string>? transliterations) ? transliterations[c & 0xff] : string.Empty;
		}

#if NET10_0_OR_GREATER
		}

#pragma warning restore IDE0055 // Fix formatting
#endif
	}
}
