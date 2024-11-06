using System.Text.RegularExpressions;

namespace AdventOfCode2023.src
{
	public static class Day7
	{
		private static readonly char[] cards_v1 = new char[] { '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K', 'A' };
		private static readonly char[] cards_v2 = new char[] { 'J', '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'Q', 'K', 'A' };

		public static long GetTotalWinnings_v1()
		{
			var lines = FileReader.ReadFile("7");

			List<Tuple<string, int>> tuples = lines.Select(l =>
															new Tuple<string, int>(
																Regex.Match(l, @"(.{5})(?= )").Value,
																int.Parse(Regex.Match(l, @"(?<= )(.+)").Value)))
													.ToList();

			tuples.Sort(Compare_v1);

			return tuples.Select((t, index) =>	t.Item2 * (index + 1)).Sum();
		}

		private static int Compare_v1(Tuple<string, int> xHand, Tuple<string, int> yHand)
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

			return itemData.Count() switch
			{
				// TTTTT
				1 => 6,
				// AA8AA : 23332
				2 => item.Count(d => d == itemData.First().ToList()[0]) == 4 ? 5 : 4,
				// TTT98 : 23432
				3 => itemData.ElementAt(0).Count() == itemData.ElementAt(1).Count() ? 2 : 3,
				// AA234
				4 => 1,
				// 12345
				_ => 0,
			};
		}


		public static long GetTotalWinnings_v2()
		{
			var lines = FileReader.ReadFile("7");

			List<Tuple<string, int>> tuples = lines.Select(l =>
															new Tuple<string, int>(
																Regex.Match(l, @"(.{5})(?= )").Value,
																int.Parse(Regex.Match(l, @"(?<= )(.+)").Value)))
													.ToList();

			tuples.Sort(Compare_v2);

			return tuples.Select((t, index) => t.Item2 * (index + 1)).Sum();
		}

		private static int Compare_v2(Tuple<string, int> xHand, Tuple<string, int> yHand)
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
			item = Day7.GetJUpdatedItem(item);
			return EstimateItem_v1(item);
		}

		private static string GetJUpdatedItem(string item)
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
