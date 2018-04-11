namespace Webapp.Models
{
    public class Tape
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}