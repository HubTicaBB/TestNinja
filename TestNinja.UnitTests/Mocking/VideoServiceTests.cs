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
        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            var fileReader = new Mock<IFileReader>();
            fileReader.Setup(fr => fr.Read("video.txt")).Returns("");
            var service = new VideoService(fileReader.Object);

            var result = service.ReadVideoTitle();

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }
    }
}
