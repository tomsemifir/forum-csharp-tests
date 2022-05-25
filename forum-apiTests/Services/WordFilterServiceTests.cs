using Microsoft.VisualStudio.TestTools.UnitTesting;
using forum_api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forum_api.Services.Tests
{
    [TestClass()]
    public class WordFilterServiceTests
    {
        private WordFilterService _service;

        [TestInitialize]
        public void Initialize()
        {
            _service = new WordFilterService();
        }

        [TestMethod()]
        [DataRow(2420)]
        public void Initialize_ListeDeMotsOk(int index)
        {
            String[] banWords = _service.BanWords;
            String expectedWord = "youpine";
            Assert.AreEqual(expectedWord, banWords[index]);
        }

        [TestMethod()]
        [DataRow("C0nn@rd que tu es...")]
        public void FilterContent_RemplacementOk(String text)
        {
            String expectedOutput = "C*****d que tu es...";
            String actualOutput = _service.FilterContent(text);
            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}