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

    public static IEnumerable<EFormServiceStatus> GetEFormServiceEnvStatuses()
    {
        var ess = new List<EFormServiceStatus>();
        try
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                String sql =
                    $"SELECT " +
                    $"  GETDATE() as [StatusDateTime] " +
                    $"  ,[ServerName] " +
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
                            ess.Add(new EFormServiceStatus
                            {
                                StatusDateTime = reader.GetDateTime(0),
                                ServerName = reader.GetString(1),
                                Success = reader.GetInt32(2),
                                Failed = reader.GetInt32(3)
                            });
                        }
                    }
                }
                return ess;
            }
        }
        catch (SqlException)
        {
            return ess;
        }
    }

    public static IEnumerable<EFormServiceRequestTypeStatus> GetEFormServiceRequestTypeStatus(string servername)
    {
        var ess = new List<EFormServiceRequestTypeStatus>();
        try
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                String sql =
                    $"SELECT " + 
                    $"  GETDATE() as [StatusDateTime] " +
                    $"  ,[ServerName] " +
                    $"  ,[RequestType] " +
                    $"  ,sum(case when [ReqStatus] = 'success' then 1 else 0 end) as [success] " +
                    $"  ,sum(case when [ReqStatus] = 'success' then 0 else 1 end) as [failed] " +
                    $"FROM [Eforms].[dbo].[Eforms_MasterLog] WITH (NOLOCK) " +
                    $"where " +
                    $"  CreatedDate >= @CreatedDate " +
                    $"  and " +
                    $"  ServerName = @ServerName " +
                    $"group by ServerName, RequestType " +
                    $"order by ServerName, RequestType ";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@CreatedDate", DateTime.Today);
                    command.Parameters.AddWithValue("@ServerName", servername);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ess.Add(new EFormServiceRequestTypeStatus
                            {
                                StatusDateTime = reader.GetDateTime(0),
                                ServerName = reader.GetString(1),
                                RequestType = reader.GetString(2),
                                Success = reader.GetInt32(3),
                                Failed = reader.GetInt32(4)
                            });
                        }
                    }
                }
                return ess;
            }
        }
        catch (SqlException)
        {
            return ess;
        }
    }
}
