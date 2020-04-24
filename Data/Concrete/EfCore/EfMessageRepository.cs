using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Data.Abstract;
using WebUI.Entity;

namespace WebUI.Data.Concrete.EfCore
{
    public class EfMessageRepository : IMessageRepository
    {
        private ApplicationIdentityDbContext _context;
        public EfMessageRepository(ApplicationIdentityDbContext context)
        {
            _context = context;
        }

        public void AddMessage(Message message)
        {
            _context.Messages.Add(message);
        }

        public void DeleteMessage(int messageId)
        {
            var message = _context.Messages.FirstOrDefault(c => c.MessageId == messageId);
            if (message != null)
            {
                _context.Messages.Remove(message);
                _context.SaveChanges();
            }
        }

        public IQueryable<Message> GetAll()
        {
            return _context.Messages;
        }

        public Message GetById(int messageId)
        {
            return _context.Messages.FirstOrDefault(m => m.MessageId==messageId);
        }

        public void SaveMessage(Message message)
        {
            if (message.MessageId == 0)
            {
                _context.Messages.Add(message);
            }
            else
            {
                var data = GetById(message.MessageId);
                if (data != null)
                {
                    data.Name = message.Name;
                    data.Subject = message.Subject;
                    data.Content = message.Content;
                    data.Date = DateTime.Now;
                    data.Status = message.Status;
                }
            }
            _context.SaveChanges();
        }
    }
}