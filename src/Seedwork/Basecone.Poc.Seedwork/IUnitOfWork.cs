using System.Threading;
using System.Threading.Tasks;

namespace Basecone.Poc.Seedwork
{
    public interface IUnitOfWork
    {
        void Commit();
        Task CommitAsync(CancellationToken cancellationToken = default(CancellationToken));
        void RollBack();
    }
}
