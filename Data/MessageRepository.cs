using Core.Interfaces;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class MessageRepository : IMessageService
    {
        private readonly kotalkDbContext _context;

        public MessageRepository(kotalkDbContext context)
        {
            _context = context;
        }

        public void SendMessage(Message message)
        {
            _context.Messages.Add(message);
            _context.SaveChanges();
        }

        public IEnumerable<Message> GetMessagesForUser(int userId)
        {
            return _context.Messages
                .Where(m => m.SenderId == userId || m.ReceiverId == userId)
                .Include(m => m.Sender)
                .Include(m => m.Receiver)
                .ToList();
        }
    }
}
