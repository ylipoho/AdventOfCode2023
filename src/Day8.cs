using System.Text.RegularExpressions;

namespace AdventOfCode2023.src
{
	public static class Day8
	{
		public static int GetStepsCount_v1()
		{
			string fileName = @"..\..\..\resources\Day8-Input.txt";
			List<string> lines = new List<string>();

			if (File.Exists(fileName))
			{
				lines = File.ReadAllLines(fileName).ToList();
			}

			string directionGuide = lines[0];
			lines = lines.Skip(2).ToList();
			List<string[]> words = new List<string[]>();
			
			foreach (var line in lines)
			{
				words.Add(Regex.Matches(line, @"[A-Z]{3}")
								.Select(m =>m.Value)
								.ToArray());
			}

			int steps = 0;
			int currentLRIndex = 0;
			string currentLetters = "AAA";
			int currentPattern = 1;
			string[] currentLine;

			do
			{
				currentLine = words.First(l => l[0] == currentLetters);
				currentPattern = directionGuide[currentLRIndex] == 'L' ? 1 : 2;
				currentLetters = currentLine[currentPattern];
				currentLRIndex = (currentLRIndex + 1) % directionGuide.Length;
				steps++;
			} while (currentLine[currentPattern] != "ZZZ");

			return steps;
		}

		public static long GetStepsCount_v2()
		{
			string fileName = @"..\..\..\resources\Day8-Input.txt";
			List<string> lines = new List<string>();

			if (File.Exists(fileName))
			{
				lines = File.ReadAllLines(fileName).ToList();
			}

			string directionGuide = lines[0];
			lines = lines.Skip(2).ToList();
			List<string[]> words = new List<string[]>();

			foreach (var line in lines)
			{
				words.Add(Regex.Matches(line, @"[A-Z]{3}")
								.Select(m => m.Value)
								.ToArray());
			}

			int currentLRIndex = 0;
			string[] currentLetters = words.Where(w => w[0][2] == 'A')
											.Select(w => w[0])
											.ToArray(); // "RCA", "GDA", "NPA", "LVA", "SLA", "AAA"
			int[] steps = new int[currentLetters.Length];
			int currentPattern = 1;
			string[] currentLine;

			for (int i = 0; i< currentLetters.Length; i++)
			{
				do
				{
					currentLine = words.First(l => l[0] == currentLetters[i]);
					currentPattern = directionGuide[currentLRIndex] == 'L' ? 1 : 2;
					currentLetters[i] = currentLine[currentPattern];
					currentLRIndex = (currentLRIndex + 1) % directionGuide.Length;
					steps[i]++;
				} while (currentLine[currentPattern][2] != 'Z');
			}

			long stepsCount = steps[0];
			for (int i = 1; i < steps.Length; i++)
			{
				stepsCount = GetLCM(stepsCount, steps[i]);
			}

			return stepsCount;
		}

		static long GetGCD(long a, long b)
		{
			return b == 0 ? a : GetGCD(b, a % b);
		}

		static long GetLCM(long a, long b)
		{
			return a * b / GetGCD(a, b);
		}
	}
}
