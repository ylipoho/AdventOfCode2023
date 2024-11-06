using System.Text.RegularExpressions;

namespace AdventOfCode2023.src
{
	internal class Day5
	{
		public static long GetLowestLocation_v1()
		{
			var lines = (string[])FileReader.ReadFile("5");

			// seeds numbers
			long[] seeds = Regex.Matches(lines[0], @"\d+")
											.Select(s => long.Parse(s.Value))
											.ToArray();

			// map line indexes
			int[] mapHeaderLines = lines.Select((l, index) => new { l, index })
									.Where(obj => obj.l.Contains("map:"))
									.Select(obj => obj.index + 1)
									.Append(lines.Length + 1)
									.ToArray();
			
			// index of first line with 3 numbers
			int firstDataLineIndex = 3;

			for (int i = 0; i < mapHeaderLines.Length - 1; i++)
			{
				List<long[]> map = new List<long[]>();

				while (firstDataLineIndex < lines.Length && lines[firstDataLineIndex].Any(c => char.IsDigit(c)))
				{
					long[] threeValue = Regex.Matches(lines[firstDataLineIndex], @"\d+")
									.Select(v => long.Parse(v.Value))
									.ToArray();
					map.Add(threeValue);
					firstDataLineIndex++;
				}

				firstDataLineIndex += 2;

				for (int j = 0; j < seeds.Length; j++)
				{
					long currentSeedParameter = -1;
					
					for (int k = 0; k < map.Count; k++)
					{
						long diff = seeds[j] - map[k][1];
						if (diff > 0 && diff <= map[k][2])
						{
							currentSeedParameter = map[k][0] + diff;
							break;
						}
					}

					seeds[j] = currentSeedParameter < 0 ? seeds[j] : currentSeedParameter;
				}
			}

			return seeds.Min();
		}
	}
}
