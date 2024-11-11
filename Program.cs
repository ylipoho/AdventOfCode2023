using AdventOfCode2023.src;

namespace AdventOfCode2023
{
	internal static class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine($" 1.1: {Day1.GetCalibrationValuesSum_v1()}");
			Console.WriteLine($" 1.2: {Day1.GetCalibrationValuesSum_v2()}");
			Console.WriteLine($" 2.1: {Day2.GetPossibleGamesIdsSum_v1()}");
			Console.WriteLine($" 2.2: {Day2.GetPossibleGamesIdsSum_v2()}");
			Console.WriteLine($" 3.1: {Day3.GetEngineNumbersSum_v1()}");
			Console.WriteLine($" 3.2: {Day3.GetEngineNumbersSum_v2()}");
			Console.WriteLine($" 4.1: {Day4.GetCardsWorth_v1()}");
			Console.WriteLine($" 4.2: {Day4.GetCardsWorth_v2()}");
			Console.WriteLine($" 5.1: {Day5.GetLowestLocation_v1()}");
			//Console.WriteLine($" 5.2: {Day5.GetLowestLocation_v2()}");
			Console.WriteLine($" 6.1: {Day6.GetWaysToWinNumberMultiplication_v1()}");
			Console.WriteLine($" 6.2: {Day6.GetWaysToWinNumberMultiplication_v2()}");
			Console.WriteLine($" 7.1: {Day7.GetTotalWinnings_v1()}");
			Console.WriteLine($" 7.2: {Day7.GetTotalWinnings_v2()}");
			Console.WriteLine($" 8.1: {Day8.GetStepsCount_v1()}");
			Console.WriteLine($" 8.2: {Day8.GetStepsCount_v2()}");
			Console.WriteLine($" 9.1: {Day9.GetNewHistorySum_v1()}");
			//Console.WriteLine($"11.1: {Day11.GetLengthsSum_v1()}");
			Console.WriteLine($"11.2: {Day11.GetLengthsSum_v2()}");
			Console.WriteLine($"15.1: {Day15.Get_v1()}");
		}
	}
}