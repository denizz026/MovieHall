
namespace MovieHall.Models
{
    public class UpcomingMovie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Imdb { get; set; }
        public string ImageUrl { get; set; }
        public DateTime ReleaseDate { get; internal set; }
    }
}
