using Microsoft.Data.SqlClient;

namespace dotnet_webapi;

public class TheData
{
    private static SqlConnection GetConnection()
    {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

        builder.DataSource = @".\SQLEXPRESS";
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
}