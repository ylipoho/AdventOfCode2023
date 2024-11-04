using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2023.src
{
	public static class Day6
	{
		public static int GetWaysToWinNumberMultiplication_v1()
		{
			string fileName = @"..\..\..\resources\Day6-Input.txt";
			string[] lines = new string[0];

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

			// каждая гонка
			for ( int i = 0; i < records[0].Length; i++)
			{
				
				int time = records[0][i];

				List<int> results = new List<int>();
				// разбираем каждый вариант
				for (int j=1; j < time; j++)
				{
					// j - скорость, time-j - оставшееся время движения
					results.Add(j * (time - j));
				}

				requiredWinsCounts[i] = results.Count(r => r > records[1][i]);
			}

			return requiredWinsCounts.Aggregate((x, y) => x * y);
		}

		public static int GetWaysToWinNumberMultiplication_v2()
		{
			string fileName = @"..\..\..\resources\Day6-Input.txt";
			string[] lines = new string[0];

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

			// разбираем каждый вариант
			for (int j = 0; j < time; j++)
			{
				// j - скорость, time-j - оставшееся время движения
				results.Add(j * (time - j));
			}

			requiredWinsCounts = results.Count(r => r > records[1]);

			return requiredWinsCounts;
		}
	}
}
