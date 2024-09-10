using System.Data;

namespace BookMyHome.Domain.Helpers
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Serializable);
    }
}
