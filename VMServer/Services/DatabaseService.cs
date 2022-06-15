using VMServer.Models;

namespace VMServer.Services;

public class DatabaseService : IDatabaseService
{
    private List<ConnectionModel> _availableConn;
    private List<ConnectionModel> _servicedConn;

    public DatabaseService()
    {
        _availableConn = new ();
        _servicedConn = new ();
    }
    public ConnectionModel? GetAvailableVM()
    {
        var conn = _availableConn.FirstOrDefault();
        if (conn == null) return null;
        _availableConn.Remove(conn);
        _servicedConn.Add(conn);
        return conn;
    }
    public void ReleaseVM(ConnectionModel conn)
    {
        _availableConn.Add(conn);
        _servicedConn.Remove(conn);
    }
    public void HeartBeat(ConnectionModel conn)
    {
        if (!_availableConn.Exists(x => x?.Equals(conn) ?? false) && !_servicedConn.Exists(x => x?.Equals(conn) ?? false))
        {
            _availableConn.Add(conn);
        }
    }

    public void Shutdown(ConnectionModel conn)
    {
        _availableConn.Remove(conn);
        _servicedConn?.Remove(conn);
    }
}