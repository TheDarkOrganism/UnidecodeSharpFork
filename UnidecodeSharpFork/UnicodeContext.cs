#if !NETSTANDARD2_0
using System.Text.Json.Serialization;
#if !NET5_0_OR_GREATER
using System;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
#endif

namespace UnidecodeSharpFork
{
#if NET5_0_OR_GREATER
	[JsonSerializable(typeof(Dictionary<int, IReadOnlyList<string>>))]
#endif
	internal sealed partial class UnicodeContext : JsonSerializerContext
#if NET5_0_OR_GREATER
	{ }
#else
	{
		public static UnicodeContext Default { get; } = new UnicodeContext();

		private UnicodeContext() : base(null) { }

		protected override JsonSerializerOptions? GeneratedSerializerOptions => null;

		public override JsonTypeInfo? GetTypeInfo(Type type)
		{
			return JsonTypeInfo.CreateJsonTypeInfo(type, Options);
		}
	}
#endif
}
#endif