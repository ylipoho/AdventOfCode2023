namespace AdventOfCode2023.src
{
	public static class Day11
	{
		public static long GetLengthsSum_v1()
		{
			string fileName = @"..\..\..\resources\Day11-Input.txt";
			List<string> lines = new List<string>();

			if (File.Exists(fileName))
			{
				lines = File.ReadAllLines(fileName).ToList();
			}

			List<string> space = ExpandUniverse(lines.ToList());

			foreach (var s in space)
			{
				Console.WriteLine(s);
			}

			List<(int, int)> galaxies = new List<(int, int)>();

			for (int i = 0; i < space.Count; i++)
			{
				for (int j = 0; j < space[i].Length; j++)
				{
					if (space[i][j] == '#')
					{
						galaxies.Add((i, j));
					}
				}
			}

			long sum = 0;

			// number of pairs is 96141 , its correct.
			for (int i = 0; i < galaxies.Count; i++)
			{
				for (int j = i + 1; j < galaxies.Count; j++)
				{
					sum += (Math.Abs(galaxies[i].Item1 - galaxies[j].Item1) + Math.Abs(galaxies[i].Item2 - galaxies[j].Item2));
				}
			}

			return sum;
		}

		static List<string> ExpandUniverse(List<string> space)
		{
			List<int> rowIndexes = new List<int>();
			List<int> columnIndexes = new List<int>();

			for (int i = 0; i < space.Count; i++)
			{
				if (space[i].All(s => s == '.'))
				{
					rowIndexes.Add(i);
				}
			}

			for (int i = 0; i < space[0].Length; i++)
			{
				if (space.All(s => s[i] == '.'))
				{
					columnIndexes.Add(i);
				}
			}

			rowIndexes.Reverse();
			columnIndexes.Reverse();

			string newRow = new string('.', space[0].Count());

			foreach (var rowIndex in rowIndexes)
			{
				space.Insert(rowIndex, newRow);
			}

			foreach (var columnIndex in columnIndexes)
			{
				for (int i = 0; i < 1000000; i++)
				{
					space = space.Select(s => s.Insert(columnIndex, ".")).ToList();
				}
			}

			return space;
		}

		public static long GetLengthsSum_v2()
		{
			string fileName = @"..\..\..\resources\Day11-Input.txt";
			List<string> lines = new List<string>();

			if (File.Exists(fileName))
			{
				lines = File.ReadAllLines(fileName).ToList();
			}

			List<string> space = lines;

			List<(int, int)> galaxies = new List<(int, int)>();

			for (int i = 0; i < space.Count; i++)
			{
				for (int j = 0; j < space[i].Length; j++)
				{
					if (space[i][j] == '#')
					{
						galaxies.Add((i, j));
					}
				}
			}

			List<int> rowIndexes = new List<int>();
			List<int> columnIndexes = new List<int>();

			for (int i = 0; i < space.Count; i++)
			{
				if (space[i].All(s => s == '.'))
				{
					rowIndexes.Add(i);
				}
			}

			for (int i = 0; i < space[0].Length; i++)
			{
				if (space.All(s => s[i] == '.'))
				{
					columnIndexes.Add(i);
				}
			}

			long sum = 0;

			// number of pairs is 96141 , its correct.
			for (int i = 0; i < galaxies.Count; i++)
			{
				for (int j = i + 1; j < galaxies.Count; j++)
				{
					int maxX = Math.Max(galaxies[i].Item1, galaxies[j].Item1);
					int minX = Math.Min(galaxies[i].Item1, galaxies[j].Item1);
					int maxY = Math.Max(galaxies[i].Item2, galaxies[j].Item2);
					int minY = Math.Min(galaxies[i].Item2, galaxies[j].Item2);

					sum += (maxX - minX) + (maxY - minY);

					int count = rowIndexes.Count(x => (minX < x) && (x < maxX));
					int count2 = columnIndexes.Count(y => (minY < y) && (y < maxY));
					sum += (count + count2) * (1000000 - 1);
				}
			}

			return sum;
			// 46529995056210 is too high-.-
			//   630729056210 is too high-.-
			//   630728425490
			//   622231056210 is too low-.-
			//   diff is 8498 times. (*000 000)
		}
	}
}
