using forum_api.Models;
using forum_api.Repositories.Impl;

namespace forum_api.Services
{
    public class TopicService
    {
        private readonly TopicRepository repository;

        public TopicService(TopicRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Topic> GetAll()
        {
            return repository.GetAll();
        }

        public Topic GetById(int id)
        {
            Topic topic = repository.GetById(id);
            if(topic == null)
            {
                throw new NullReferenceException($"Aucun topic n'a été trouvé avec l'id {id}");
            }
            return topic;
        }

        public Topic Create(Topic entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.UpdatedDate = DateTime.Now;
            entity.Messages = new List<Message>();
            return repository.Create(entity);
        }

        public Topic Update(int id, Topic entity)
        {
            entity.UpdatedDate = DateTime.Now;
            entity.Id = id;
            Topic topic = repository.Update(entity);
            if(topic == null)
            {
                throw new NullReferenceException($"Aucun topic n'a été trouvé avec l'id {id}");
            }
            return topic;
        }

        public Topic Delete(int id)
        {
            Topic topic = GetById(id);
            topic = repository.Delete(topic);
            if (topic == null)
            {
                throw new NullReferenceException($"Aucun topic n'a été trouvé avec l'id {id}");
            }
            return topic;
        }
    }
}
