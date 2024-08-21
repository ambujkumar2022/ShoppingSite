namespace ShoppingSite.Models
{
	public class CartItem
	{
		public int Id { get; set; }
		public int ShirtId { get; set; }
		public Shirt Shirt { get; set; }
		public int Qty { get; set; }
	}
}
