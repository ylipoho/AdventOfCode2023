namespace AdventOfCode2023.src
{
	public static class Day11
	{
		public static long GetLengthsSum_v1()
		{
			List<string> space = ExpandUniverse(FileReader.ReadFile("11").ToList());
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

			for (int i = 0; i < galaxies.Count; i++)
			{
				for (int j = i + 1; j < galaxies.Count; j++)
				{
					sum += (Math.Abs(galaxies[i].Item1 - galaxies[j].Item1) + Math.Abs(galaxies[i].Item2 - galaxies[j].Item2));
				}
			}

			return sum;
		}

		public static long GetLengthsSum_v2()
		{
		
			List<string> lines = FileReader.ReadFile("11").ToList();
			List<(int, int)> galaxies = new List<(int, int)>();

			for (int i = 0; i < lines.Count; i++)
			{
				for (int j = 0; j < lines[i].Length; j++)
				{
					if (lines[i][j] == '#')
					{
						galaxies.Add((i, j));
					}
				}
			}

			List<int> rowIndexes = new List<int>();
			List<int> columnIndexes = new List<int>();

			for (int i = 0; i < lines.Count; i++)
			{
				if (lines[i].All(s => s == '.'))
				{
					rowIndexes.Add(i);
				}
			}

			for (int i = 0; i < lines[0].Length; i++)
			{
				if (lines.All(s => s[i] == '.'))
				{
					columnIndexes.Add(i);
				}
			}

			long sum = 0;

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

			string newRow = new string('.', space[0].Length);

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
	}
}
