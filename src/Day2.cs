﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2023.src
{
	public static class Day2
	{
		public static int GetPossibleGamesIdsSum_v1()
		{
			// Initially the bag contained only 12 red cubes, 13 green cubes, and 14 blue cubes
			int[] bag = { 12, 13, 14 };
			string fileName = @"..\..\..\resources\Day2-Input.txt";
			string[] lines = new string[0];

			if (File.Exists(fileName))
			{
				lines = File.ReadAllLines(fileName);
			}

			string redRegex = @"(?<=[:|,|;] )(\d+)(?= red)";
			string greenRegex = @"(?<=[:|,|;] )(\d+)(?= green)";
			string blueRegex = @"(?<=[:|,|;] )(\d+)(?= blue)";

			int sum = 0;

			foreach (var line in lines)
			{
				int redMax = Regex.Matches(line, redRegex)
								.Select(m => int.Parse(m.Value)).Max();
				int greenMax = Regex.Matches(line, greenRegex)
								.Select(m => int.Parse(m.Value)).Max();
				int blueMax = Regex.Matches(line, blueRegex)
								.Select(m => int.Parse(m.Value)).Max();

				if (redMax <= bag[0] && greenMax <= bag[1] && blueMax <= bag[2])
				{
					sum += int.Parse(Regex.Match(line, @"\d+").Value);
				}
			}

			return sum;	
		}

		public static int GetPossibleGamesIdsSum_v2()
		{
			string fileName = @"..\..\..\resources\Day2-Input.txt";
			string[] lines = new string[0];

			if (File.Exists(fileName))
			{
				lines = File.ReadAllLines(fileName);
			}

			string redRegex = @"(?<=[:|,|;] )(\d+)(?= red)";
			string greenRegex = @"(?<=[:|,|;] )(\d+)(?= green)";
			string blueRegex = @"(?<=[:|,|;] )(\d+)(?= blue)";

			int sum = 0;

			foreach (var line in lines)
			{
				int redMax = Regex.Matches(line, redRegex)
								.Select(m => int.Parse(m.Value)).Max();
				int greenMax = Regex.Matches(line, greenRegex)
								.Select(m => int.Parse(m.Value)).Max();
				int blueMax = Regex.Matches(line, blueRegex)
								.Select(m => int.Parse(m.Value)).Max();

				sum += redMax * greenMax * blueMax; 
			}

			return sum;
		}
	}
}