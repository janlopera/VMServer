using VMServer.Models;

namespace VMServer.Services;

public interface IDatabaseService
{
    public ConnectionModel? GetAvailableVM();

    public void ReleaseVM(ConnectionModel conn);

    public void HeartBeat(ConnectionModel conn);

    public void Shutdown(ConnectionModel conn);
}