namespace WorkWrapper.Comms;

public class ResultsCollection<TResponse>
{
    public IEnumerable<TResponse>? Results { get; set; }
}