namespace MyTeam.Models
{
    public class TableItem
    {
        public int Id { get; set; }
        public int Position { get; set; }
        public Team Team  { get; set; }
        public int Points  { get; set; }
        public int Won  { get; set; }
        public int PlayedGames { get; set; }
        public int Lost  { get; set; }
        public int Draw  { get; set; }
    }
}