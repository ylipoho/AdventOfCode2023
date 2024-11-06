namespace AdventOfCode2023.src
{
	public static class Day4
	{
		public static int GetCardsWorth_v1()
		{
			var lines = FileReader.ReadFile("4");

			var cardParts = lines
				.Select(l => l[(l.IndexOf(':') + 1)..])
				.Select(l => l.Split('|'));

			int sum = 0;
			int nullCard = 0;

			foreach (var part in cardParts)
			{
				string[] winningNumbers = part[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
				string[] numbers = part[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);

				int winCount = winningNumbers.Count(n => numbers.Contains(n));
				if (winCount == 0) { nullCard++; }
				sum += winCount > 0 ? (int)Math.Pow(2, winCount-1) : 0;
			}

			return sum;
		}

		public static int GetCardsWorth_v2()
		{
			var lines = FileReader.ReadFile("4");
			char[] separators = new char[] {':', '|'};

			var cards = lines.Select(l => l.Split(separators));
			int[] cardCounter = new int[lines.Count()];
			Array.Fill(cardCounter, 1);
			int counter = 0;

			foreach (var card in cards)
			{
				string[] winningNumbers = card[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
				string[] numbers = card[2].Split(' ', StringSplitOptions.RemoveEmptyEntries);

				int winCount = winningNumbers.Count(n => numbers.Contains(n));

				for (int i  = 0; i < winCount; i++)
				{
					cardCounter[counter+i+1] += cardCounter[counter];
				}
				counter++;
			}

			return cardCounter.Sum();
		}
	}
}
