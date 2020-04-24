using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Entity;

namespace WebUI.Data.Abstract
{
    public interface IMessageRepository
    {
        Message GetById(int messageId);
        IQueryable<Message> GetAll();
        void AddMessage(Message message);
        void DeleteMessage(int messageId);
        void SaveMessage(Message message);
    }
}
