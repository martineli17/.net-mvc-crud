using Crosscuting.Notification;
using Domain.Interfaces.UnitOfWork;
using Repository.Context;
using System;
using System.Threading.Tasks;

namespace Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContextBase _context;
        private readonly INotify _notify;
        public UnitOfWork(ContextBase context, INotify notify)
        {
            _context = context;
            _notify = notify;
        }
        public async Task<bool> Commit() 
        {
            try
            {
                return (await _context.SaveChangesAsync()) > 0;
            }
            catch (Exception ex)
            {
                _notify.AddNotification(new NotificationMessage("Ocorreu um erro ao processar a operação."));
                return false;
            }
           
        } 
    }
}
