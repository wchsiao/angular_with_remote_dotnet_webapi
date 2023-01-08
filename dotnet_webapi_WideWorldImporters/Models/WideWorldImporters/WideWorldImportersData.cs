using Microsoft.Data.SqlClient;

namespace dotnet_webapi_WideWorldImporters.Models.WideWorldImporters;

public class WideWorldImportersData
{
    private static SqlConnection GetConnection()
    {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

        builder.DataSource = @".\SQLEXPRESS_2016";
        builder.InitialCatalog = "WideWorldImporters";
        builder.IntegratedSecurity = true;
        builder.TrustServerCertificate = true;

        return new SqlConnection(builder.ConnectionString);
    }

    public static Person[] GetPersons()
    {
        List<Person> ps = new List<Person>();

        try
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                String sql = "SELECT PersonID, FullName FROM [WideWorldImporters].[Application].[People]";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                            ps.Add(new Person
                            {
                                PersonId = reader.GetInt32(0),
                                FullName = reader.GetString(1)
                            });
                        }
                        return ps.ToArray();
                    }
                }
            }
        }
        catch (SqlException)
        {
            return ps.ToArray();
        }
    }

    internal static Person? GetPerson(int id)
    {
        try
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                String sql =
                    "SELECT PersonID, FullName " +
                    "FROM [WideWorldImporters].[Application].[People] " +
                    "WHERE PersonID = @PersonID ";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@PersonId", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                            return new Person
                            {
                                PersonId = reader.GetInt32(0),
                                FullName = reader.GetString(1)
                            };
                        }
                    }
                }
            }
            return null;
        }
        catch (SqlException)
        {
            return null;
        }
    }

    internal static int UpdatePerson(int id, Person person)
    {
        try
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                String sql =
                    "UPDATE [WideWorldImporters].[Application].[People] " +
                    "SET FullName = @FullName " +
                    "WHERE PersonID = @PersonID ";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", id);
                    command.Parameters.AddWithValue("@FullName", person.FullName);

                    return command.ExecuteNonQuery();
                }
            }
        }
        catch (SqlException)
        {
            return -2;
        }
    }

    internal static int DeletePerson(int id)
    {
        try
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                String sql =
                    "DELETE FROM [WideWorldImporters].[Application].[People] " +
                    "WHERE PersonID = @PersonID ";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", id);

                    return command.ExecuteNonQuery();
                }
            }
        }
        catch (SqlException)
        {
            return -2;
        }
    }
}