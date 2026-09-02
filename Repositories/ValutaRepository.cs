using System.Collections.Generic;
using System.Data.SqlClient;
using CasaSchimbValutar.Database;
using CasaSchimbValutar.Models;

namespace CasaSchimbValutar.Repositories
{
    public class ValutaRepository
    {
        private readonly string _connectionString = DatabaseHelper.ConnectionString;

        public List<Valuta> GetAll()
        {
            var result = new List<Valuta>();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT Id, Cod, Nume, Simbol FROM Valute", conn))
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        result.Add(Map(reader));
            }
            return result;
        }

        public void Add(Valuta valuta)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(
                    "INSERT INTO Valute (Cod, Nume, Simbol) VALUES (@cod, @nume, @simbol)", conn))
                {
                    cmd.Parameters.AddWithValue("cod", valuta.Cod);
                    cmd.Parameters.AddWithValue("nume", valuta.Nume);
                    cmd.Parameters.AddWithValue("simbol", valuta.Simbol);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Valuta valuta)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(
                    "UPDATE Valute SET Cod = @cod, Nume = @nume, Simbol = @simbol WHERE Id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("cod", valuta.Cod);
                    cmd.Parameters.AddWithValue("nume", valuta.Nume);
                    cmd.Parameters.AddWithValue("simbol", valuta.Simbol);
                    cmd.Parameters.AddWithValue("id", valuta.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("DELETE FROM Valute WHERE Id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private Valuta Map(SqlDataReader r) => new Valuta
        {
            Id = r.GetInt32(r.GetOrdinal("Id")),
            Cod = r.GetString(r.GetOrdinal("Cod")),
            Nume = r.GetString(r.GetOrdinal("Nume")),
            Simbol = r.GetString(r.GetOrdinal("Simbol"))
        };
    }
}