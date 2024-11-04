using System.Text.RegularExpressions;

namespace AdventOfCode2023.src
{
	public static class Day6
	{
		public static int GetWaysToWinNumberMultiplication_v1()
		{
			string fileName = @"..\..\..\resources\Day6-Input.txt";
			string[] lines = Array.Empty<string>();

			if (File.Exists(fileName))
			{
				lines = File.ReadAllLines(fileName);
			}

			List<int[]> records = new List<int[]>();
			foreach (var line in lines)
			{
				records.Add(Regex.Matches(line, @"\d+")
								.Select(x => int.Parse(x.Value))
								.ToArray());
			}
			int[] requiredWinsCounts = new int[records[0].Length];

			for ( int i = 0; i < records[0].Length; i++)
			{
				
				int time = records[0][i];

				List<int> results = new List<int>();

				for (int j=1; j < time; j++)
				{
					results.Add(j * (time - j));
				}

				requiredWinsCounts[i] = results.Count(r => r > records[1][i]);
			}

			return requiredWinsCounts.Aggregate((x, y) => x * y);
		}

		public static int GetWaysToWinNumberMultiplication_v2()
		{
			string fileName = @"..\..\..\resources\Day6-Input.txt";
			string[] lines = Array.Empty<string>();

			if (File.Exists(fileName))
			{
				lines = File.ReadAllLines(fileName);
			}

			var stringNumbers = lines.Select(line => Regex.Matches(line, @"\d")
														.Select(l => l.Value));

			List<long> records = new List<long>();
			foreach (var stringNumber in stringNumbers)
			{
				string item = string.Join(string.Empty, stringNumber);
				records.Add(long.Parse(item));
			}

			int requiredWinsCounts = 0;
			long time = records[0];
			List<long> results = new List<long>();

			for (int j = 0; j < time; j++)
			{
				results.Add(j * (time - j));
			}

			requiredWinsCounts = results.Count(r => r > records[1]);

			return requiredWinsCounts;
		}
	}
}
