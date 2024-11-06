using System.Text.RegularExpressions;

namespace AdventOfCode2023.src
{
	internal class Day3
	{
		public static int GetEngineNumbersSum_v1()
		{
			var lines = (string[])FileReader.ReadFile("3");

			int sum = 0;

			for (int i = 0; i < lines.Length; i++)
			{
				Regex numberRegex = new Regex("\\d+");
				MatchCollection matchCollection = numberRegex.Matches(lines[i]);

				foreach (Match match in matchCollection.Cast<Match>())
				{
					sum += HasNeighbours(lines, i, match) ? int.Parse(match.Value) : 0;	
				}

			}

			return sum;
		}

		static bool HasNeighbours(string[] lines, int lineIndex, Match match)
		{
			int startIndex = match.Index;
			int endIndex = match.Index + match.Length - 1;
			Regex symbolRegex = new Regex(@"[^.\d\n]");

			return new string[3]
				{
					lineIndex > 0 ? lines[lineIndex - 1] : string.Empty,
					lines[lineIndex],
					lineIndex < lines.Length - 1 ? lines[lineIndex + 1] : string.Empty
				}
					.Where(s => !string.IsNullOrWhiteSpace(s))
					.Select(s => s.Substring(
									Math.Max(0, startIndex - 1),
									startIndex == 0 || endIndex == lines[lineIndex].Length - 1
										? match.Length + 1
										: match.Length + 2
								)
							)
					.Where(s => symbolRegex.IsMatch(s))
					.Any();
		}
	}
}
