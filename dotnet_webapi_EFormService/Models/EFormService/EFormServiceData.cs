using Microsoft.Data.SqlClient;

namespace dotnet_webapi_EFormService.Models.EFormService;

public class EFormServiceData
{
    public static DateTime Date { get; set; }
    public static int MasterLogId_Min { get; set; }

    static EFormServiceData()
    {
        Date = DateTime.Today;
        MasterLogId_Min = int.MaxValue;
    }

    private static SqlConnection GetConnection()
    {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

        builder.DataSource = "SQL16PRODF";
        builder.InitialCatalog = "Eforms";
        builder.IntegratedSecurity = true;
        builder.TrustServerCertificate = true;

        return new SqlConnection(builder.ConnectionString);
    }

    public static EFormServiceLogDate[] GetEFormServiceLogDate()
    {
        List<EFormServiceLogDate> ss = new List<EFormServiceLogDate>();

        try
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                String sql =
                    $"SELECT MIN([MasterLogId]) as [MasterLogId] " +
                    $", CAST([CreatedDate] as date) as [CreatedDate] " +
                    $"FROM [Eforms].[dbo].[Eforms_MasterLog] " +
                    $"where CreatedDate >= CAST(GETDATE() as date) " +
                    $"group by CAST([CreatedDate] as date) " +
                    $"order by [CreatedDate] desc";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ss.Add(new EFormServiceLogDate
                            {
                                MasterLogId = reader.GetInt32(0),
                                CreatedDate = reader.GetDateTime(1)
                            });
                        }
                    }
                }
                return ss.ToArray();
            }
        }
        catch (SqlException)
        {
            return ss.ToArray();
        }
    }

    public static int Get_MasterLogId_Min(DateTime date)
    {
        using (SqlConnection connection = GetConnection())
        {
            connection.Open();

            String sql =
                $"SELECT " +
                $"  MIN([MasterLogId]) as [MasterLogId] " +
                $"  , CAST([CreatedDate] as date) as [CreatedDate] " +
                $"FROM " +
                $"  [Eforms].[dbo].[Eforms_MasterLog] " +
                $"where " +
                $"  CreatedDate >= @dateStart " +
                $"  and " +
                $"  CreatedDate < @dateEnd ";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@dateStart", date);
                command.Parameters.AddWithValue("@dateEnd", date.AddDays(1));

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var r = new EFormServiceLogDate
                        {
                            MasterLogId = reader.GetInt32(0),
                            CreatedDate = reader.GetDateTime(1)
                        };

                        return r.MasterLogId;
                    }
                }
            }
        }
        return int.MaxValue;
    }

    public static EFormServiceEnvStatus[] GetEFormServiceEnvStatuses()
    {
        var ss = new List<EFormServiceEnvStatus>();
        try
        {
            if (Date != DateTime.Today)
            {
                MasterLogId_Min = Get_MasterLogId_Min(Date);
            }

            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                String sql =
                    $"SELECT [ServerName] " +
                    $"  ,sum(case when [ReqStatus] = 'success' then 1 else 0 end) as [success] " +
                    $"  ,sum(case when [ReqStatus] = 'success' then 0 else 1 end) as [failed] " +
                    $"FROM [Eforms].[dbo].[Eforms_MasterLog] WITH (NOLOCK) " +
                    $"where " +
                    $"  CreatedDate >= @CreatedDate " +
                    $"  and " +
                    $"  ServerName in ('eforms01','eforms02','eforms03','eforms04','eforms05','eforms06','eforms07') " +
                    $"group by ServerName " +
                    $"order by ServerName ";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    //command.Parameters.AddWithValue("@masterLogId", MasterLogId_Min);
                    command.Parameters.AddWithValue("@CreatedDate", DateTime.Today);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ss.Add(new EFormServiceEnvStatus
                            {
                                ServerName = reader.GetString(0),
                                Success = reader.GetInt32(1),
                                Failed = reader.GetInt32(2)
                            });
                        }
                    }
                }
                return ss.ToArray();
            }
        }
        catch (SqlException)
        {
            return ss.ToArray();
        }
    }
}
