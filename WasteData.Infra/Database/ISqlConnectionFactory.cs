using System.Data;

namespace WasteData.Infra.Database
{
    public interface ISqlConnectionFactory
    {
        IDbConnection GetOpenConnection();
    }
}