using WorkWrapper.Session;

namespace WorkWrapper.Comms;

public class WorkApiClientFactory : IWorkApiClientFactory
{
    public IWorkApiClient Create(ISession session)
    {
        var proxy = new HttpClientProxy(session.Uri);

        return new WorkApiClient(session, proxy);
    }
}