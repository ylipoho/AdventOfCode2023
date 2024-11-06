namespace AdventOfCode2023.src
{
	public static class Day9
	{
		public static int GetNewHistorySum_v1()
		{
			List<string> lines = FileReader.ReadFile("9").ToList();

			List<List<int>> histories = lines.Select(l => l.Split(' ')
															.Select(x => int.Parse(x))
															.ToList())
												.ToList();
			
			return histories.Select(history => GetNextLevel(history)).Sum();
		}

		static int GetNextLevel(List<int> input)
		{
			List<int> output = new List<int>();
			int newValue = 0;

			for (int i = 0; i< input.Count - 1; i++)
			{
				output.Add(input[i+1] - input[i]);
			}

			if (output.Any(x => x != 0))
			{
				newValue = GetNextLevel(output);
			}

			return input.First() - newValue;
		}
	}
}
