namespace schoolManagementSystem.Model
{
    public class Card
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public decimal Balance { get; set; }
        public string CardNumber { get; set; }
        public bool IsBlocked { get; set; }
    }
}