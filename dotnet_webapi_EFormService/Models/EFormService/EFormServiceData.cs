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

    public static EFormServiceEnvStatus GetEFormServiceEnvStatuses()
    {
        var envStatus = new EFormServiceEnvStatus
        {
            StatusDateTime = DateTime.Now,
            EFormServiceStatusList = new List<EFormServiceStatus>()
        };

        try
        {
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
                    $"  ServerName in ('eforms01','eforms02','eforms03','eforms04','eforms05','eforms06','eforms07', 'eformsnp01', 'eformsnp02') " +
                    $"group by ServerName " +
                    $"order by ServerName ";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@CreatedDate", DateTime.Today);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            envStatus.EFormServiceStatusList.Add(new EFormServiceStatus
                            {
                                ServerName = reader.GetString(0),
                                Success = reader.GetInt32(1),
                                Failed = reader.GetInt32(2)
                            });
                        }
                    }
                }
                return envStatus;
            }
        }
        catch (SqlException)
        {
            return envStatus;
        }
    }
}
