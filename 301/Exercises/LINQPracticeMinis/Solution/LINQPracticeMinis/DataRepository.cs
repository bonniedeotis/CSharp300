﻿namespace LINQPracticeMinis
{
    public class DataRepository
    {
        private readonly string _filePath;

        public DataRepository(string filePath)
        {
            _filePath = filePath;
        }

        public List<Luchador> Load()
        {
            var luchadores = new List<Luchador>();

            try
            {
                var lines = File.ReadAllLines(_filePath).Skip(1); // Skip the header row
                foreach (var line in lines)
                {
                    var columns = line.Split(',');

                    var luchador = new Luchador
                    {
                        Alias = columns[0],
                        FirstName = columns[1],
                        LastName = columns[2],
                        DoB = DateTime.Parse(columns[3]),
                        Country = columns[4],
                        HeightCm = int.Parse(columns[5]),
                        WeightKg = int.Parse(columns[6]),
                        Wins = int.Parse(columns[7]),
                        Losses = int.Parse(columns[8]),
                        Draws = int.Parse(columns[9]),
                        Championships = int.Parse(columns[10])
                    };

                    luchadores.Add(luchador);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading data: {ex.Message}");
            }

            return luchadores;
        }
    }
}
