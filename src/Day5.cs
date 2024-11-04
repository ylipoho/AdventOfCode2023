using System.Text.RegularExpressions;

namespace AdventOfCode2023.src
{
	internal class Day5
	{
		public static long GetLowestLocation_v1()
		{
			string fileName = @"..\..\..\resources\Day5-Input.txt";
			string[] lines = new string[0];

			if (File.Exists(fileName))
			{
				lines = File.ReadAllLines(fileName);
			}

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

			// ПРОХОД ПО КАЖДОЙ МАПЕ
			for (int i = 0; i < mapHeaderLines.Count() - 1; i++)
			{
				List<long[]> map = new List<long[]>();

				// на каждом проходе заполнить 1 карту 
				while (firstDataLineIndex < lines.Count() && lines[firstDataLineIndex].Any(c => char.IsDigit(c)))
				{
					long[] threeValue = Regex.Matches(lines[firstDataLineIndex], @"\d+")
									.Select(v => long.Parse(v.Value))
									.ToArray();
					map.Add(threeValue);
					firstDataLineIndex++;
				}

				firstDataLineIndex += 2;

				// для каждой семечки
				for (int j = 0; j < seeds.Count(); j++)
				{
					long currentSeedParameter = -1;
					// пройтись по всем строкам 1ой мапы
					for (int k = 0; k < map.Count; k++)
					{
						long diff = seeds[j] - map[k][1];
						if (diff >0 && diff <= map[k][2])
						{
							currentSeedParameter = map[k][0] + diff;
							break;
						}
					}

					seeds[j] = currentSeedParameter < 0 ? seeds[j] : currentSeedParameter;
					Console.WriteLine("seeds[" + j+ "]= " + seeds[j]);
					// нашли location
				}

				int a = 0;
			}

			foreach (var r in seeds)
			{
				Console.WriteLine("r = "+r);
			}

			// 157211394
			return seeds.Min();
		}
	}
}
