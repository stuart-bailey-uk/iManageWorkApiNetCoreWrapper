using WorkWrapper.Session;

namespace WorkWrapper.Comms;

public interface IWorkApiClientFactory
{
    IWorkApiClient Create(ISession session);
}