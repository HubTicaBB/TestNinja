using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Mocking;

namespace TestNinja.UnitTests
{
    [TestFixture]
    class VideoServiceTests
    {
        private Mock<IFileReader> _fileReader;
        private VideoService _service;

        [SetUp]
        public void SetUp()
        {
            _fileReader = new Mock<IFileReader>();
            _service = new VideoService(_fileReader.Object);
        }

        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            _fileReader.Setup(fr => fr.Read("video.txt")).Returns("");            

            var result = _service.ReadVideoTitle();

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }
    }
}
