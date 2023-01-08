using Microsoft.Data.SqlClient;
using Newtonsoft.Json;

namespace dotnet_webapi_SimpleTest;

public class SimpleTestData
{
    private static SqlConnection GetConnection()
    {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

        builder.DataSource = @".\SQLEXPRESS_2016";
        builder.InitialCatalog = "SimpleTest";
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

                String sql =
                    "SELECT PersonID, FullName, EmailAddress, PhoneNumber " +
                    "FROM [People]";

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
                                FullName = reader.GetString(1),
                                EmailAddress = reader.GetString(2),
                                PhoneNumber = reader.GetString(3),
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
                    "SELECT PersonID, FullName, EmailAddress, PhoneNumber " +
                    "FROM [People] " +
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
                                FullName = reader.GetString(1),
                                EmailAddress = reader.GetString(2),
                                PhoneNumber = reader.GetString(3),
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


    internal static int AddPerson(Person person)
    {
        try
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                String sql =
                    "INSERT INTO [People] (FullName, EmailAddress, PhoneNumber) " +
                    "VALUES (@FullName, @EmailAddress, @PhoneNumber) ";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@FullName", person.FullName);
                    command.Parameters.AddWithValue("@EmailAddress", person.FullName);
                    command.Parameters.AddWithValue("@PhoneNumber", person.FullName);

                    return command.ExecuteNonQuery();
                }
            }
        }
        catch (SqlException)
        {
            return -2;
        }
    }

    internal static int UpdatePerson(int id, Person person)
    {
        System.Diagnostics.Debug.WriteLine(JsonConvert.SerializeObject(person));
        try
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                String sql =
                    "UPDATE [People] " +
                    "SET FullName = @FullName, " +
                    "   EmailAddress = @EmailAddress, " +
                    "   PhoneNumber = @PhoneNumber " +
                    "WHERE PersonID = @PersonID ";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", id);
                    command.Parameters.AddWithValue("@FullName", person.FullName);
                    command.Parameters.AddWithValue("@EmailAddress", person.EmailAddress);
                    command.Parameters.AddWithValue("@PhoneNumber", person.PhoneNumber);

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
                    "DELETE FROM [People] " +
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