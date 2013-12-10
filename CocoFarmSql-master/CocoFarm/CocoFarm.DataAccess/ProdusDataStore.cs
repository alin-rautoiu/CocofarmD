using CocoFarm.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocoFarm.DataAccess
{
    public class ProdusDataStore : IDataStore<Produs>
    {
        public IEnumerable<Produs> GetAll()
        {
            List<Produs> produse = new List<Produs>();

            using (SqlConnection connection = new SqlConnection(DB.ConnectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from dbo.Produs";

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Produs prod = new Produs();
                        prod.Id = (System.Guid) reader["Id"];
                        prod.Cod = (string) reader["Cod"];
                        prod.Denumire = (string)reader["Denumire"];
                        prod.Descriere = (string)reader["Descriere"];

                        produse.Add(prod);
                    }
                }
            }

            return produse;
        }

        public Produs GetById(Guid id)
        {
            Produs patient = null;

            using (SqlConnection conn = new SqlConnection(DB.ConnectionString))
            {
                conn.Open();

                using (SqlCommand command = conn.CreateCommand())
                {

                    command.CommandText = "uspGetProdusById";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Id", id);

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    dataAdapter.Fill(table);
                   
                    if (table.Rows.Count > 0) 
                    {
                        DataRow row = table.Rows[0];
                        patient = new Produs()
                        {
                            Cod = (string)row["Cod"],
                            Descriere = (string)row["Descriere"],
                            Denumire = (string)row["Denumire"],
                            Id = (System.Guid)row["Id"]
                        };
                    }

                }
            }
            return patient;
        }

        public Produs GetByIdSimple(Guid id)
        {
            Produs produs = new Produs();

            using (SqlConnection conn = new SqlConnection(DB.ConnectionString))
            {
                conn.Open();

                using (SqlCommand command = conn.CreateCommand())
                {

                    command.CommandText = "uspGetProdusById";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            produs.Id = (System.Guid)reader["Id"];
                            produs.Denumire = (string)reader["Denumire"];
                            produs.Cod = (string)reader["Cod"];
                            produs.Descriere = (string)reader["Descriere"];
                        }
                    }
                }
            }

            return produs;
        }

        public Produs Create(Produs entity)
        {
            using (SqlConnection conn = new SqlConnection(DB.ConnectionString))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = @"
                    INSERT INTO [dbo].[Produs] ([Denumire], [Cod], [Descriere])
                    VALUES( @Denumire, @Cod, @Descriere);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);";

                command.Parameters.AddWithValue("@Denumire", entity.Denumire);
                command.Parameters.AddWithValue("@Cod", entity.Cod);
                command.Parameters.AddWithValue("@Descriere",entity.Descriere);


                entity.Id = (System.Guid)command.ExecuteScalar();
          
            }

            return entity;
        }

        public Produs Update(Produs entity)
        {
            using (SqlConnection conn = new SqlConnection(DB.ConnectionString))
            {
                conn.Open();

                using (SqlCommand command = conn.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "uspUpdateProdus";

                    command.Parameters.AddWithValue("@Id", entity.Id);
                    command.Parameters.AddWithValue("@Denumire", entity.Denumire);
                    command.Parameters.AddWithValue("@Cod", entity.Cod);
                    command.Parameters.AddWithValue("@Descriere", entity.Descriere);

                    command.ExecuteNonQuery();
                }
            }

            return entity;
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
