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

		public static int GetEngineNumbersSum_v2()
		{
			var lines = (string[])FileReader.ReadFile("3");
			List<(int Row, int Column)> gears = new();
			List<(int Row, int Column, string Number)> numbers = new();
			
			for (int i = 0; i < lines.Length; i++)
			{
				MatchCollection matchCollection = new Regex("\\*").Matches(lines[i]);

				foreach (Match match in matchCollection.Cast<Match>())
				{
					gears.Add((i, match.Index));
				}

				matchCollection = new Regex("\\d+").Matches(lines[i]);

				foreach (Match match in matchCollection.Cast<Match>())
                {
					numbers.Add((i, match.Index, match.Value));
                }
			}

			return gears
					.Select(
						gear =>
							numbers
								.Where(number => IsNearTheGear(number.Row, 
															number.Column, 
															number.Number.Length, 
															gear.Row, 
															gear.Column))
								.ToList()
					)
					.Where(gearNumbers => gearNumbers.Count == 2)
					.Select(gearNumbers => int.Parse(gearNumbers[0].Number) 
										* int.Parse(gearNumbers[1].Number))
					.Sum();
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

		static bool IsNearTheGear(int numberRow, int numberColumn, int numberLength, int gearRow, int gearColumn)
		{
			return numberRow - 1 <= gearRow
				&& gearRow <= numberRow + 1
				&& numberColumn - 1 <= gearColumn
				&& gearColumn <= numberColumn + numberLength;
		}
	}
}
