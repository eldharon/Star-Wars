using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Star_Wars.Controllers;
using Star_Wars.Model;
using Star_Wars.Repository;
using Star_Wars.Service;

namespace Star_Wars.Tests
{
    [TestClass]
    public class CharactersControllerTests
    {
        static Mock<IService<Character>> _service;
        static CharactersController _charactersController;
        public CharactersControllerTests()
        {
            _service=new Mock<IService<Character>>();
            _charactersController = new CharactersController(_service.Object);
        }
        [TestMethod]
        public void AddCharacter_ShouldBe_True()
        {
            var character = new Character
            {
                CharacterId = 9999,
                Name = "Test Character"
            };
            _service.Setup(x => x.AddAsync(character));
            var result = _charactersController.Get(9999);
            Assert.IsTrue(result.Result.IsSuccessStatusCode);
        }
        [TestMethod]
        public async Task GetCharacterById_ShouldntBe_Null()
        {
            var result = await _charactersController.Get(2);
            Assert.IsTrue(result.IsSuccessStatusCode);
        }
    }
}
