namespace Domain.Entitis;

public class Quote
{
    public int Id { get; set; }
    public string Author { get; set; }
    public string QuoteText { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }

}