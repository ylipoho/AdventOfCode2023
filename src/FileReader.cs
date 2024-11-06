namespace AdventOfCode2023.src
{
	public static class FileReader
	{
		private static readonly string FilePath  = @"..\..\..\resources\Day{0}-Input.txt";

		public static IEnumerable<string> ReadFile(string id)
		{
			return File.ReadAllLines(string.Format(FilePath, id));
		}
	}
}
