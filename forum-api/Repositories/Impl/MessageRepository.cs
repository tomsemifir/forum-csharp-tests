using forum_api.Models;
using Microsoft.EntityFrameworkCore;

namespace forum_api.Repositories.Impl
{
    public class MessageRepository : GenericRepository<Message>
    {
        private readonly forumContext _context;

        public MessageRepository(forumContext context)
        {
            _context = context;
        }

        public virtual Message Create(Message entity)
        {
            _context.Messages.Add(entity);
            Save();
            return entity;
        }

        public virtual Message Delete(Message entity)
        {
            _context.Remove(entity);
            Save();
            return entity;
        }

        public virtual IEnumerable<Message> GetAll()
        {
            return _context.Messages;
        }

        public virtual Message GetById(int id)
        {
            return _context.Messages.Find(id);
        }

        public virtual Message Update(Message entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            Save();
            return entity;
        }

        public virtual void Save()
        {
            _context.SaveChanges();
        }
    }
}
