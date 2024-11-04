using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2023.src
{
	public static class Day7
	{
		private static char[] cards_v1 = new char[] { '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K', 'A' };
		private static char[] cards_v2 = new char[] { 'J', '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'Q', 'K', 'A' };

		public static long GetTotalWinnings_v1()
		{
			string fileName = @"..\..\..\resources\Day7-Input.txt";
			List<string> lines = new List<string>();

			if (File.Exists(fileName))
			{
				lines = File.ReadAllLines(fileName).ToList();
			}

			List<Tuple<string, int>> tuples = lines.Select(l =>
															new Tuple<string, int>(
																Regex.Match(l, @"(.{5})(?= )").Value,
																int.Parse(Regex.Match(l, @"(?<= )(.+)").Value)))
													.ToList();

			tuples.Sort(compare_v1);

			foreach (var tuple in tuples)
			{
				Console.WriteLine(tuple);
			}

			return tuples.Select((t, index) =>	t.Item2 * (index + 1)).Sum();
		}

		private static int compare_v1(Tuple<string, int> xHand, Tuple<string, int> yHand)
		{
			string x = xHand.Item1;
			string y = yHand.Item1;

			int xCost = EstimateItem_v1(x);
			int yCost = EstimateItem_v1(y);

			if (xCost == yCost)
			{
				char[] cards = Day7.cards_v1;

				for (int i = 0; i < x.Length; i++)
				{
					int xIndex = Array.IndexOf(cards, x[i]);
					int yIndex = Array.IndexOf(cards, y[i]);

					if (xIndex != yIndex)
					{
						return xIndex - yIndex;
					}
				}
				return 0;
			}

			return xCost - yCost;
		}

		private static int EstimateItem_v1(string item)
		{
			var itemData = item.GroupBy(x => x).OrderByDescending(x => x.Count());
			int cost = 0;

			switch (itemData.Count())
			{
				case 1: // TTTTT
					cost = 6;
					break;
				case 2: // AA8AA : 23332
					cost = item.Count(d => d == itemData.First().ToList()[0]) == 4 ? 5 : 4;
					break;
				case 3: // TTT98 : 23432
					cost = itemData.ElementAt(0).Count() == itemData.ElementAt(1).Count() ? 2 : 3;
					break;
				case 4: // AA234
					cost = 1;
					break;
				default: // 12345
					cost = 0;
					break;
			}

			return cost;
		}


		public static long GetTotalWinnings_v2()
		{
			string fileName = @"..\..\..\resources\Day7-Input.txt";
			List<string> lines = new List<string>();

			if (File.Exists(fileName))
			{
				lines = File.ReadAllLines(fileName).ToList();
			}

			List<Tuple<string, int>> tuples = lines.Select(l =>
															new Tuple<string, int>(
																Regex.Match(l, @"(.{5})(?= )").Value,
																int.Parse(Regex.Match(l, @"(?<= )(.+)").Value)))
													.ToList();

			tuples.Sort(compare_v2);

			foreach (var tuple in tuples)
			{
				Console.WriteLine(tuple);
			}

			return tuples.Select((t, index) => t.Item2 * (index + 1)).Sum();
			// 251821661 is too low((
			// 252898370 is the answer
			// 252907464 is too high ((
			// 254122006 is too high((
		}

		private static int compare_v2(Tuple<string, int> xHand, Tuple<string, int> yHand)
		{
			string x = xHand.Item1;
			string y = yHand.Item1;
			int xCost = EstimateItem_v2(x);
			int yCost = EstimateItem_v2(y);

			if (xCost == yCost)
			{
				char[] cards = Day7.cards_v2;

				for (int i = 0; i < x.Length; i++)
				{
					int xIndex = Array.IndexOf(cards, x[i]);
					int yIndex = Array.IndexOf(cards, y[i]);

					if (xIndex != yIndex)
					{
						return xIndex - yIndex;
					}
				}
				return 0;
			}

			return xCost - yCost;
		}

		private static int EstimateItem_v2(string item)
		{
			item = Day7.getJUpdatedItem(item);
			var itemData = item.GroupBy(x => x).OrderByDescending(x => x.Count());
			int cost = 0;

			switch (itemData.Count())
			{
				case 1: // TTTTT
					cost = 6;
					break;
				case 2: // AA8AA : 23332
					cost = item.Count(d => d == itemData.First().ToList()[0]) == 4 ? 5 : 4;
					break;
				case 3: // TTT98 : 23432
					cost = itemData.ElementAt(0).Count() == itemData.ElementAt(1).Count() ? 2 : 3;
					break;
				case 4: // AA234
					cost = 1;
					break;
				default: // 12345
					cost = 0;
					break;
			}

			return cost;
		}

		private static string getJUpdatedItem(string item)
		{
			if (item.Contains('J') && item.Count(x => x == 'J') < 5)
			{
				var itemData = item.Where(x => x != 'J').GroupBy(x => x).OrderByDescending(x => x.Count());
				char newChar = itemData.ElementAt(0).ToList()[0];
				return item.Replace('J', newChar);
			}

			return item;
		}
	}
}
