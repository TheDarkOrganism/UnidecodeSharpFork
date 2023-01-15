namespace Tests
{
	///<summary>
	///This is a test class for UnidecoderTest and is intended
	///to contain all UnidecoderTest Unit Tests
	///</summary>
	public sealed class UnidecoderTest
	{
		[Fact]
		public void DocTest()
		{
			Assert.Equal("Bei Jing ", "\u5317\u4EB0".Unidecode());
		}

		[Fact]
		public void CustomTest()
		{
			Assert.Equal("Rabota s kirillitsey", "Работа с кириллицей".Unidecode());
			Assert.Equal("aouoAOUO", "äöűőÄÖŨŐ".Unidecode());
		}

		[Fact]
		public void PythonTest()
		{
			Assert.Equal("Hello, World!", "Hello, World!".Unidecode());

			Assert.Equal("'\"\r\n", "'\"\r\n".Unidecode());
			Assert.Equal("CZSczs", "ČŽŠčžš".Unidecode());
			Assert.Equal("a", "ア".Unidecode());
			Assert.Equal("a", "α".Unidecode());
			Assert.Equal("a", "а".Unidecode());
			Assert.Equal("chateau", "ch\u00e2teau".Unidecode());
			Assert.Equal("vinedos", "vi\u00f1edos".Unidecode());
		}

		/// <summary>
		/// According to http://en.wikipedia.org/wiki/Romanization_of_Russian BGN/PCGN.
		/// http://en.wikipedia.org/wiki/BGN/PCGN_romanization_of_Russian
		/// With converting "ё" to "yo".
		/// </summary>
		[Fact]
		public void RussianAlphabetTest()
		{
			const string russianAlphabetLowercase = "а б в г д е ё ж з и й к л м н о п р с т у ф х ц ч ш щ ъ ы ь э ю я";
			const string russianAlphabetUppercase = "А Б В Г Д Е Ё Ж З И Й К Л М Н О П Р С Т У Ф Х Ц Ч Ш Щ Ъ Ы Ь Э Ю Я";

			const string expectedLowercase = "a b v g d e yo zh z i y k l m n o p r s t u f kh ts ch sh shch \" y ' e yu ya";
			const string expectedUppercase = "A B V G D E Yo Zh Z I Y K L M N O P R S T U F Kh Ts Ch Sh Shch \" Y ' E Yu Ya";

			Assert.Equal(expectedLowercase, russianAlphabetLowercase.Unidecode());
			Assert.Equal(expectedUppercase, russianAlphabetUppercase.Unidecode());
		}

		[Fact]
		public void CharUnidecodeTest()
		{
			const string input = "а б в г д е ё ж з и й к л м н о п р с т у ф х ц ч ш щ ъ ы ь э ю я А Б В Г Д Е Ё Ж З И Й К Л М Н О П Р С Т У Ф Х Ц Ч Ш Щ Ъ Ы Ь Э Ю Я";
			const string expected = "a b v g d e yo zh z i y k l m n o p r s t u f kh ts ch sh shch \" y ' e yu ya A B V G D E Yo Zh Z I Y K L M N O P R S T U F Kh Ts Ch Sh Shch \" Y ' E Yu Ya";

			Assert.Equal(expected, string.Join("", input.Select(c => c.Unidecode())));
		}

		[Fact]
		public void UnidecodeOnNullShouldReturnEmptyString()
		{
			Assert.Equal(string.Empty, default(string).Unidecode());
		}
	}
}
