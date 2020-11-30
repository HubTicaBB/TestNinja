using System.Collections.Generic;
using TestNinja.Mocking;
using System.Linq;


namespace TestNinja.UnitTests.Mocking
{
    public class VideoRepository
    {
        public IEnumerable<Video> GetUnprocessedVideos()
        {
            using var context = new VideoContext();
            var videos = (from video in context.Videos
                          where !video.IsProcessed
                          select video).ToList();

            return videos;
        }
    }
}
