using System.Text;

namespace AdventOfCode2023.src
{
	public static class Day15
	{
		public static int Get_v1()
		{
			string fileName = @"..\..\..\resources\Day15-Input.txt";
			List<string> lines = new List<string>();

			if (File.Exists(fileName))
			{
				lines = File.ReadAllLines(fileName).ToList();
			}

			string[] substrings = lines[0].Split(',');
			List<int> currentValues = new List<int>();

			foreach (var substring in substrings)
			{
				byte[] bytes = Encoding.ASCII.GetBytes(substring);
				int currentValue = 0;

				foreach (var b in bytes)
				{
					currentValue = (currentValue + b) * 17 % 256;
				}
				currentValues.Add(currentValue);
			}

			return currentValues.Sum();
		}
	}
}
