using Dapper;
using Domain.Entitis;
using Npgsql;

namespace Infrastructure.Services;

public class QuoteServices
{
    private string _conectionString = "Server=127.0.0.1;Port=5432;Database=Quotes_db;User Id=postgres;Password=2004;";

    public List<Quote> GetQuote()
    {
        using (var connection  = new NpgsqlConnection(_conectionString))
        {
            string sql = 
            $" select "+
            $" q.id, "+
            $" q.author, "+
            $" q.quotetext, "+
            $" q.categoryid, "+
            $" c.categoryname "+
            $" from quotes q "+
            $" join Сategories c on c.id = q.categoryid;";
            var quotes = connection.Query<Quote>(sql);
            return quotes.ToList();
        }
    }

    public void AddQuote(Quote quote)
    {
        using(var connection = new NpgsqlConnection(_conectionString))
        {
            string sql = 
            $"insert into quotes(id,author,quotetext,categoryid) "+
            $"values "+
            $"({quote.Id},'{quote.Author}','{quote.QuoteText}',{quote.CategoryId})";
            var add = connection.Execute(sql);
            if (add>0) System.Console.WriteLine("Added");
            else System.Console.WriteLine("Not Added");
        }
    }
    public void UpdateQuote(Quote quote)
    {
        using (var connection = new NpgsqlConnection(_conectionString))
        {
            string sql =  
            $" update quotes "+
            $" set author = '{quote.Author}',quotetext = '{quote.QuoteText}',categoryid = '{quote.CategoryId}' "+
            $" where id = {quote.Id}";
            var update = connection.Execute((sql));
            if (update>0) System.Console.WriteLine("Updated");
            else System.Console.WriteLine("Not Updaated");
        }
    }

    public void DeleteQuote(int id)
    {
        using(var connection = new NpgsqlConnection(_conectionString))
        {
            string sql = $"delete from quotes where id = {id} ";
            var delete = connection.Execute(sql);
            if (delete>0) System.Console.WriteLine("Deleted");
            else System.Console.WriteLine("Not Removed");
        }
    }

    public List<Quote> GetAllQuotesByCategory(int id)
    {
        using (var connection = new NpgsqlConnection(_conectionString))
        {
            string sql = 
                $" select "+
                $" q.id, "+
                $" q.author, "+
                $" q.quotetext, "+
                $" q.categoryid, "+
                $" c.categoryname "+
                $" from quotes q "+
                $" join Сategories c on c.id = q.categoryid " +
                $"where q.categoryid = {id};";
            var quotes = connection.Query<Quote>(sql);
            return quotes.ToList();
        }
    }

    public List<Quote> GetRandomQuote()
    {
        using (var connection  = new NpgsqlConnection(_conectionString))
        {
            string sql = 
            $"SELECT * from quotes "+ 
            $" order by Random() "+
            $" limit 1 ";
            var rand = connection.Query<Quote>(sql);
            return rand.ToList();
        }
    }

}
