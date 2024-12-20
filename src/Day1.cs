﻿using System.Text.RegularExpressions;

namespace AdventOfCode2023.src
{
	public static class Day1
	{
		public static int GetCalibrationValuesSum_v1()
		{
			var lines = FileReader.ReadFile("1");

			return (int)lines
				.Select(l => 
					10 * Char.GetNumericValue(l.First(c => Char.IsDigit(c)))
					+ Char.GetNumericValue(l.Last(c => Char.IsDigit(c))))
				.Sum();	
		}

		public static int GetCalibrationValuesSum_v2()
		{
			string digitsRegex = "1|2|3|4|5|6|7|8|9|one|two|three|four|five|six|seven|eight|nine";
			Dictionary<string, int> digitsDictionary = new Dictionary<string, int>()
			{
				{"one", 1}, {"two", 2},{"three", 3}, {"four", 4}, {"five", 5}, {"six", 6}, {"seven", 7}, {"eight", 8}, {"nine", 9}
			};

			var lines = FileReader.ReadFile("1");
			int sum = 0;

			foreach (string line in lines)
			{
				Match left = Regex.Match(line, digitsRegex);
				Match right = Regex.Match(line, digitsRegex, RegexOptions.RightToLeft);
				int leftDigit = digitsDictionary.ContainsKey(left.Value) ? digitsDictionary[left.Value] : int.Parse(left.Value);
				int rightDigit = digitsDictionary.ContainsKey(right.Value) ? digitsDictionary[right.Value] : int.Parse(right.Value);

				sum += 10 * leftDigit + rightDigit;
			}

			return sum;
		}
	}
}
