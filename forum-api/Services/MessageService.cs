using forum_api.Models;
using forum_api.Repositories.Impl;

namespace forum_api.Services
{
    public class MessageService
    {
        private readonly MessageRepository _repository;
        private readonly WordFilterService _wordFilterService;

        public MessageService(MessageRepository repository, WordFilterService wordFilterService)
        {
            _repository = repository;
            _wordFilterService = wordFilterService;
        }

        public IEnumerable<Message> GetAll()
        {
            return _repository.GetAll();
        }

        public Message GetById(int id)
        {
            Message message = _repository.GetById(id);
            if(message == null)
            {
                throw new NullReferenceException($"Aucun message n'a été trouvé avec l'id {id}");
            }
            return message;
        }

        public Message Create(Message entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.UpdatedDate = DateTime.Now;
            entity.Content = _wordFilterService.FilterContent(entity.Content);
            return _repository.Create(entity);
        }

        public Message Update(int id, Message entity)
        {
            entity.UpdatedDate = DateTime.Now;
            entity.Content = _wordFilterService.FilterContent(entity.Content);
            entity.Id = id;
            Message message = _repository.Update(entity);
            if(message == null)
            {
                throw new NullReferenceException($"Aucun message n'a été trouvé avec l'id {id}");
            }
            return message;
        }

        public Message Delete(int id)
        {
            Message message = GetById(id);
            message = _repository.Delete(message);
            if(message == null)
            {
                throw new NullReferenceException($"Aucun message n'a été trouvé avec l'id {id}");
            }
            return message;
        }
    }
}
