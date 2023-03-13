namespace TestAPI.Models
{
    public class Order
    {   public int Id { get; set; }
        public int Qty { get; set; }
        public double Price { get; set; }

        public string Phone { get; set; }

        public int MoveId { get; set; }

        public int UserId { get; set; }
    }
}
