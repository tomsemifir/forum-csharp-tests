using Microsoft.VisualStudio.TestTools.UnitTesting;
using forum_api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using forum_api.Models;
using Moq;
using forum_api.Repositories.Impl;

namespace forum_api.Services.Tests
{
    [TestClass()]
    public class MessageServiceTests
    {
        private MessageService _service;
        private WordFilterService _wordFilterService;
        private Mock<MessageRepository> _repository;
        private List<Message> _messages;
        private DateTime initDate;

        [TestInitialize]
        public void Initialize()
        {
            initDate = DateTime.Now;
            _repository = new Mock<MessageRepository>(null);
            _wordFilterService = new WordFilterService();
            _service = new MessageService(_repository.Object, _wordFilterService);
            _messages = new List<Message>();
            _messages.Add(new Message() { Id = 1, Content = "Hello", CreatedDate = initDate, UpdatedDate = initDate });
            _messages.Add(new Message() { Id = 2, Content = "Bonjour", CreatedDate = initDate, UpdatedDate = initDate });
            _messages.Add(new Message() { Id = 3, Content = "Hola", CreatedDate = initDate, UpdatedDate = initDate });
        }

        [TestMethod()]
        [DataRow(1)]
        [DataRow(2)]
        public void GetById_IdOk(int id)
        {
            //GIVEN
            _repository.Setup(repo => repo.GetById(id)).Returns(_messages.Find(m => m.Id == id));
            Message expectedMessage = _messages.Find(m => m.Id == id);
            //WHEN
            Message endMessage = _service.GetById(id);
            Assert.AreEqual(expectedMessage.Content, endMessage.Content);
        }

        [TestMethod()]
        [DataRow(5)]
        [DataRow(0)]
        public void GetById_IdPasOk(int id)
        {
            //GIVEN
            _repository.Setup(repo => repo.GetById(id)).Returns(_messages.Find(m => m.Id == id));
            Message expectedMessage = _messages.Find(m => m.Id == id);
            //WHEN
            
            Assert.ThrowsException<NullReferenceException>(() =>
            {
                _service.GetById(id);
            });
        }

        [TestMethod()]
        public void GetAll_TailleOk()
        {
            //GIVEN
            _repository.Setup(repo => repo.GetAll()).Returns(_messages);
            //WHEN
            List<Message> endMessages = (List<Message>)_service.GetAll();
            Assert.AreEqual(3, endMessages.Count);
            Assert.AreSame(_messages, endMessages);
        }

        [TestMethod()]
        public void Create_MessageOk()
        {
            //GIVEN
            Message sendMessage = new Message(){ Content = "Bonjour les amis" };
            Message returnedMessage = new Message();
            _repository.Setup(repo => repo.Create(sendMessage)).Callback<Message>(msg =>
                {
                    msg.Id = 4;
                    returnedMessage = msg;
                });

            Message expectedMessage = new Message { Id = 4, Content = sendMessage.Content, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now };
            //WHEN
            _service.Create(sendMessage);
            //THEN
            Assert.AreEqual(expectedMessage.Id, returnedMessage.Id);
            Assert.IsNotNull(returnedMessage.CreatedDate);
            Assert.IsNotNull(returnedMessage.UpdatedDate);
            Assert.AreEqual(expectedMessage.Content, returnedMessage.Content);
        }

        [TestMethod()]
        public void Create_MessageFilteredOk()
        {
            //GIVEN
            Message sendMessage = new Message() { Content = "Bonjour les salope" };
            Message returnedMessage = new Message();
            _repository.Setup(repo => repo.Create(sendMessage)).Callback<Message>(msg =>
            {
                msg.Id = 4;
                returnedMessage = msg;
            });

            Message expectedMessage = new Message { Id = 4, Content = "Bonjour les s****e", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now };
            //WHEN
            _service.Create(sendMessage);
            //THEN
            Assert.AreEqual(expectedMessage.Id, returnedMessage.Id);
            Assert.IsNotNull(returnedMessage.CreatedDate);
            Assert.IsNotNull(returnedMessage.UpdatedDate);
            Assert.AreEqual(expectedMessage.Content, returnedMessage.Content);
        }

        [TestMethod()]
        public void Update_IdOk_MessageOk()
        {
            //GIVEN
            Message sendMessage = new Message { Id = 3, Content = "Contenu du message modifié", CreatedDate = initDate, UpdatedDate = initDate };
            DateTime newDate = DateTime.Now;
            Message returnedMessage = new Message();
            _repository.Setup(repo => repo.Update(sendMessage)).Returns<Message>(msg =>
            {
                returnedMessage = msg;
                return returnedMessage;
            });
            Message expectedMessage = new Message{Id = 3, Content = "Contenu du message modifié", CreatedDate = initDate, UpdatedDate = newDate};
            //WHEN
            _service.Update(sendMessage.Id, sendMessage);
            //THEN
            Assert.AreEqual(expectedMessage.Content, returnedMessage.Content);
        }

        [TestMethod()]
        public void Update_IdOk_MessageFilteredOk()
        {
            //GIVEN
            Message sendMessage = new Message { Id = 3, Content = "Connard , le contenu du message est modifié", CreatedDate = initDate, UpdatedDate = initDate };           
            Message returnedMessage = new Message();
            DateTime newDate = DateTime.Now;
            _repository.Setup(repo => repo.Update(sendMessage)).Returns<Message>(msg =>
            {
                returnedMessage = msg;
                return returnedMessage;
            });
            Message expectedMessage = new Message { Id = 3, Content = "C*****d , le contenu du message est modifié", CreatedDate = initDate, UpdatedDate = newDate };
            //WHEN
            _service.Update(sendMessage.Id, sendMessage);
            //THEN
            Assert.AreEqual(expectedMessage.Content, returnedMessage.Content);
        }

        [TestMethod()]
        [DataRow(1)]
        [DataRow(2)]
        public void Delete_IdOk(int index)
        {
            //GIVEN
            _repository.Setup(repo => repo.Delete(index)).Returns(() =>
            {
                Message message = _messages.Find(msg => msg.Id == index);
                _messages.RemoveAll(msg => msg.Id == index);
                return message;
            });
            //WHEN
            _service.Delete(index);
            Assert.IsFalse(_messages.Any(msg => msg.Id == index));
            Assert.IsTrue(_messages.Count == 2);
        }

        [TestMethod()]
        [DataRow(5)]
        [DataRow(0)]
        public void Delete_IdPasOk(int index)
        {
            //GIVEN
            _repository.Setup(repo => repo.Delete(index)).Returns(() =>
            {
                Message message = _messages.Find(msg => msg.Id == index);
                _messages.RemoveAll(msg => msg.Id == index);
                return message;
            });

            //WHEN // THEN
            Assert.ThrowsException<NullReferenceException>(() =>
            {
                _service.Delete(index);
            });
            Assert.IsFalse(_messages.Any(msg => msg.Id == index));
            Assert.IsTrue(_messages.Count == 3);
        }
    }
}