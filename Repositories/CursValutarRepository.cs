using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CasaSchimbValutar.Database;
using CasaSchimbValutar.Models;

namespace CasaSchimbValutar.Repositories
{
    public class CursValutarRepository
    {
        private readonly string _connectionString = DatabaseHelper.ConnectionString;

        public List<CursValutar> GetAll()
        {
            var result = new List<CursValutar>();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(
                    @"SELECT cv.Id, cv.ValutaId, cv.DataCurs, cv.CursLaRON, v.Cod
                      FROM CursuriValutare cv
                      INNER JOIN Valute v ON cv.ValutaId = v.Id", conn))
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        result.Add(Map(reader));
            }
            return result;
        }

        public CursValutar GetCurentByValutaId(int valutaId)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(
                    @"SELECT TOP 1 cv.Id, cv.ValutaId, cv.DataCurs, cv.CursLaRON, v.Cod
                      FROM CursuriValutare cv
                      INNER JOIN Valute v ON cv.ValutaId = v.Id
                      WHERE cv.ValutaId = @valutaId
                      ORDER BY cv.DataCurs DESC", conn))
                {
                    cmd.Parameters.AddWithValue("valutaId", valutaId);
                    using (var reader = cmd.ExecuteReader())
                        if (reader.Read())
                            return Map(reader);
                }
            }
            return null;
        }

        public void Add(CursValutar curs)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(
                    @"INSERT INTO CursuriValutare (ValutaId, DataCurs, CursLaRON)
                      VALUES (@valutaId, @dataCurs, @cursLaRON)", conn))
                {
                    cmd.Parameters.AddWithValue("valutaId", curs.ValutaId);
                    cmd.Parameters.AddWithValue("dataCurs", curs.DataCurs);
                    cmd.Parameters.AddWithValue("cursLaRON", curs.CursLaRON);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(CursValutar curs)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(
                    @"UPDATE CursuriValutare
                      SET ValutaId = @valutaId, DataCurs = @dataCurs, CursLaRON = @cursLaRON
                      WHERE Id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("valutaId", curs.ValutaId);
                    cmd.Parameters.AddWithValue("dataCurs", curs.DataCurs);
                    cmd.Parameters.AddWithValue("cursLaRON", curs.CursLaRON);
                    cmd.Parameters.AddWithValue("id", curs.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(
                    "DELETE FROM CursuriValutare WHERE Id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private CursValutar Map(SqlDataReader r) => new CursValutar
        {
            Id = r.GetInt32(r.GetOrdinal("Id")),
            ValutaId = r.GetInt32(r.GetOrdinal("ValutaId")),
            CodValuta = r.GetString(r.GetOrdinal("Cod")),
            DataCurs = r.GetDateTime(r.GetOrdinal("DataCurs")),
            CursLaRON = r.GetDecimal(r.GetOrdinal("CursLaRON"))
        };
    }
}