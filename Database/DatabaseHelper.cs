using System.Data.SqlClient;
using System.Windows.Forms;

namespace CasaSchimbValutar.Database
{
    public static class DatabaseHelper
    {
        public static string ConnectionString =>
            @"Data Source=(LocalDB)\MSSQLLocalDB;" +
            @"AttachDbFilename=|DataDirectory|\CasaSchimbValutar.mdf;" +
            @"Integrated Security=True";

        public static void InitializeazaTabele()
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(@"
                    IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Valute' AND xtype='U')
                    CREATE TABLE Valute (
                        Id      INT IDENTITY(1,1) PRIMARY KEY,
                        Cod     NVARCHAR(10)  NOT NULL,
                        Nume    NVARCHAR(100) NOT NULL,
                        Simbol  NVARCHAR(10)  NOT NULL
                    );

                    IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='CursuriValutare' AND xtype='U')
                    CREATE TABLE CursuriValutare (
                        Id          INT IDENTITY(1,1) PRIMARY KEY,
                        ValutaId    INT            NOT NULL REFERENCES Valute(Id),
                        DataCurs    DATE           NOT NULL,
                        CursLaRON   DECIMAL(10,4)  NOT NULL
                    );

                    IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Tranzactii' AND xtype='U')
                    CREATE TABLE Tranzactii (
                        Id              INT IDENTITY(1,1) PRIMARY KEY,
                        ValutaId        INT             NOT NULL REFERENCES Valute(Id),
                        SumaValuta      DECIMAL(18,2)   NOT NULL,
                        CursUtilizat    DECIMAL(10,4)   NOT NULL,
                        SumaRON         DECIMAL(18,2)   NOT NULL,
                        Tip             NVARCHAR(20)    NOT NULL,
                        DataTranzactie  DATETIME        NOT NULL
                    );", conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}