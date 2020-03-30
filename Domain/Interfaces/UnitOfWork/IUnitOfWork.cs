using System.Threading.Tasks;

namespace Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
      Task<bool> Commit();
       
    }
}
