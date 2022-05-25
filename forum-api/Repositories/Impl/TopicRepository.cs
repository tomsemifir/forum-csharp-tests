using forum_api.Models;
using Microsoft.EntityFrameworkCore;

namespace forum_api.Repositories.Impl
{
    public class TopicRepository : GenericRepository<Topic>
    {
        private readonly forumContext _context;

        public TopicRepository(forumContext context)
        {
            _context = context;
        }

        public Topic Create(Topic entity)
        {
            _context.Topics.Add(entity);
            Save();
            return entity;
        }

        public Topic Delete(Topic topic)
        {
            _context.Topics.Remove(topic);
            Save();
            return topic;
        }

        public IEnumerable<Topic> GetAll()
        {
            return _context.Topics.Include(t => t.Messages);
        }

        public Topic GetById(int id)
        {
            return _context.Topics.Include(t => t.Messages).FirstOrDefault(t => t.Id == id);
        }

        public Topic Update(Topic entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            Save();
            return entity;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
