![GitHub License](https://img.shields.io/github/license/TheDarkOrganism/UnidecodeSharpFork)
[![Tests](https://github.com/TheDarkOrganism/UnidecodeSharpFork/actions/workflows/tests.yml/badge.svg)](https://github.com/TheDarkOrganism/UnidecodeSharpFork/actions/workflows/tests.yml)
![NuGet Version](https://img.shields.io/nuget/v/TheDarkOrganism.UnidecodeSharpFork)
![NuGet Downloads](https://img.shields.io/nuget/dt/TheDarkOrganism.UnidecodeSharpFork)


# Notice #

The code in this repo originaly came from a bitbucket repo
that was made for .Net Framework.

Source:
[https://bitbucket.org/DimaStefantsov/unidecodesharpfork/](https://bitbucket.org/DimaStefantsov/unidecodesharpfork/)

The code has been updated to work with modern projects.

# Overview #

**UnidecodeSharpFork** is .NET library dll, written in C#.  
It provides `string` or `char` extension method **`Unidecode()`** that returns transliterated string.
It supports huge amount of languages.  
And it's very easy to add your language if it's not supported already!

## Example code ##

Take a look at the list of assertions:
    
	:::java
    Assert.AreEqual("Bei Jing ", "\u5317\u4EB0".Unidecode());
    Assert.AreEqual("Rabota s kirillitsey", "Работа с кириллицей".Unidecode());
    Assert.AreEqual("aouoAOUO", "äöűőÄÖŨŐ".Unidecode());
    Assert.AreEqual("Hello, World!", "Hello, World!".Unidecode());
    Assert.AreEqual("'\"\r\n", "'\"\r\n".Unidecode());
    Assert.AreEqual("CZSczs", "ČŽŠčžš".Unidecode());
    Assert.AreEqual("a", "ア".Unidecode());
    Assert.AreEqual("a", "α".Unidecode());
    Assert.AreEqual("a", "а".Unidecode());
    Assert.AreEqual("chateau", "ch\u00e2teau".Unidecode());
    Assert.AreEqual("vinedos", "vi\u00f1edos".Unidecode());

## History ##

**Original character transliteration tables on Perl:**  
2001, Sean M. Burke [sburke@cpan.org](mailto:sburke@cpan.org)  
[http://search.cpan.org/~sburke/Text-Unidecode-0.04/lib/Text/Unidecode.pm](http://search.cpan.org/~sburke/Text-Unidecode-0.04/lib/Text/Unidecode.pm)

**Python code and later additions:**  
2011, Tomaz Solc [tomaz.solc@tablix.org](mailto:tomaz.solc@tablix.org)  
[http://pypi.python.org/pypi/Unidecode](http://pypi.python.org/pypi/Unidecode)

**Original C# port:**  
2010, Oleg Ussanov  
[http://unidecode.codeplex.com/](http://unidecode.codeplex.com/)


[def]: https://bitbucket.org/DimaStefantsov/unidecodesharpfork/