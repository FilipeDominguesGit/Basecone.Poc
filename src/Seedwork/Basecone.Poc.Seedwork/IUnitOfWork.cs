using System.Threading;
using System.Threading.Tasks;

namespace Basecone.Poc.Seedwork
{
    public interface IUnitOfWork
    {
        Task Commit();
        void RollBack();
    }
}
