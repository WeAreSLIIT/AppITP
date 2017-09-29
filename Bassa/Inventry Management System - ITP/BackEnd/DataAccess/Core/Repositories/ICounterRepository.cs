using DataAccess.Core.Domain;

namespace DataAccess.Core.Repositories
{
    public interface ICounterRepository : IRepository<Counter>
    {
        long? GetCounterCountInBranch(long BranchID);
        long? GetCounterID(long BranchID, long CounterNo);
    }
}
