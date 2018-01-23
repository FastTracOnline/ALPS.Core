namespace ALPS.Common
{
	public static class ExtensionMethods
	{
		public static string GetLast(this string source, int tail_length)
		{
			if (tail_length >= source.Length)
				return source;

			return source.Substring(source.Length - tail_length);
		}
	}
}
