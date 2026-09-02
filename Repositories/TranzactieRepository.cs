using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CasaSchimbValutar.Database;
using CasaSchimbValutar.Models;

namespace CasaSchimbValutar.Repositories
{
    public class TranzactieRepository
    {
        private readonly string _connectionString = DatabaseHelper.ConnectionString;

        public List<Tranzactie> GetAll()
        {
            var result = new List<Tranzactie>();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(
                    @"SELECT t.Id, t.ValutaId, t.SumaValuta, t.CursUtilizat,
                             t.SumaRON, t.Tip, t.DataTranzactie, v.Cod
                      FROM Tranzactii t
                      INNER JOIN Valute v ON t.ValutaId = v.Id", conn))
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        result.Add(Map(reader));
            }
            return result;
        }

        public void Add(Tranzactie tranzactie)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(
                    @"INSERT INTO Tranzactii (ValutaId, SumaValuta, CursUtilizat, SumaRON, Tip, DataTranzactie)
                      VALUES (@valutaId, @sumaValuta, @cursUtilizat, @sumaRON, @tip, @dataTranzactie)", conn))
                {
                    cmd.Parameters.AddWithValue("valutaId", tranzactie.ValutaId);
                    cmd.Parameters.AddWithValue("sumaValuta", tranzactie.SumaValuta);
                    cmd.Parameters.AddWithValue("cursUtilizat", tranzactie.CursUtilizat);
                    cmd.Parameters.AddWithValue("sumaRON", tranzactie.SumaRON);
                    cmd.Parameters.AddWithValue("tip", tranzactie.Tip.ToString());
                    cmd.Parameters.AddWithValue("dataTranzactie", tranzactie.DataTranzactie);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Tranzactie tranzactie)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(
                    @"UPDATE Tranzactii
                      SET ValutaId = @valutaId, SumaValuta = @sumaValuta,
                          CursUtilizat = @cursUtilizat, SumaRON = @sumaRON,
                          Tip = @tip, DataTranzactie = @dataTranzactie
                      WHERE Id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("valutaId", tranzactie.ValutaId);
                    cmd.Parameters.AddWithValue("sumaValuta", tranzactie.SumaValuta);
                    cmd.Parameters.AddWithValue("cursUtilizat", tranzactie.CursUtilizat);
                    cmd.Parameters.AddWithValue("sumaRON", tranzactie.SumaRON);
                    cmd.Parameters.AddWithValue("tip", tranzactie.Tip.ToString());
                    cmd.Parameters.AddWithValue("dataTranzactie", tranzactie.DataTranzactie);
                    cmd.Parameters.AddWithValue("id", tranzactie.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("DELETE FROM Tranzactii WHERE Id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private Tranzactie Map(SqlDataReader r) => new Tranzactie
        {
            Id = r.GetInt32(r.GetOrdinal("Id")),
            ValutaId = r.GetInt32(r.GetOrdinal("ValutaId")),
            CodValuta = r.GetString(r.GetOrdinal("Cod")),
            SumaValuta = r.GetDecimal(r.GetOrdinal("SumaValuta")),
            CursUtilizat = r.GetDecimal(r.GetOrdinal("CursUtilizat")),
            SumaRON = r.GetDecimal(r.GetOrdinal("SumaRON")),
            Tip = (TipTranzactie)Enum.Parse(typeof(TipTranzactie), r.GetString(r.GetOrdinal("Tip"))),
            DataTranzactie = r.GetDateTime(r.GetOrdinal("DataTranzactie"))
        };
    }
}