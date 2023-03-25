
namespace ForCycle
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            string filePath = @"C:\Users\rogoz\source\repos\ForCycle\ForCycle\Wells.csv";
            string[] lines = ReadFile(filePath);
            Well[] wells=ConvertStringsToWells(lines);

            double totalOilRate = GetTotalOilRate(wells);
            double avgOilRate=GetAverageOilRate(wells);

            Console.WriteLine($"Суммарный дебит по нефти: {totalOilRate}");
            Console.WriteLine($"Средний дебит по нефти: {avgOilRate:0.00}");



        }

        /// <summary>
        /// Возвращает суммарный дебит скважин
        /// </summary>
        /// <param name="wells"></param>
        /// <returns></returns>
        private static double GetTotalOilRate(Well[] wells)
        {
            double sum = 0d;
            for (int i = 0; i < wells.Length; i++)
            {
                sum += wells[i].oilRate;
            }
            return sum;
        }

        /// <summary>
        /// Возвращает средний дебит скважин
        /// </summary>
        /// <param name="wells"></param>
        /// <returns></returns>
        private static double GetAverageOilRate(Well[] wells)
        {
            double totalOilRate = GetTotalOilRate(wells);
            double averageRate=totalOilRate/wells.Length;
            return averageRate;
        }


        /// <summary>
        /// Конвертирует строки в массив скважин
        /// </summary>
        /// <param name="lines"></param>
        /// <returns></returns>
        private static Well[] ConvertStringsToWells(string[] lines)
        {
            Well[] result = new Well[lines.Length-1];
            for (int i = 1; i < lines.Length; i++)
            {
                var items = lines[i].Split(';');
                Well well = new()
                {
                    oilFieldName = items[0],
                    platform = items[1],
                    wellNumber = items[2],
                    liquidRate = Convert.ToDouble(items[3]),
                    oilRate = Convert.ToDouble(items[4])
                };
                result[i - 1] = well;
            }
            return result;
        }

        /// <summary>
        /// Считывает информацию из файла по указанному пути
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        static string[] ReadFile(string filePath)
        {
            string[] strings= File.ReadAllLines(filePath);
            return strings;
        }
    }
}