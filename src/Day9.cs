using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2023.src
{
	public static class Day9
	{
		public static int GetNewHistorySum_v1()
		{
			string fileName = @"..\..\..\resources\Day9-Input.txt";
			List<string> lines = new List<string>();

			if (File.Exists(fileName))
			{
				lines = File.ReadAllLines(fileName).ToList();
			}

			List<List<int>> histories = lines.Select(l => l.Split(' ')
															.Select(x => int.Parse(x))
															.ToList())
												.ToList();
			
			return histories.Select(history => GetNextLevel(history)).Sum();
			// v1 = 1974232246
			// v2 - 928
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

			// v1
			//return input.Last() + newValue;
			// v2
			return input.First() - newValue;
		}
	}
}
