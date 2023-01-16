using Domain.Entitis;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class QuoteController : ControllerBase
{
    private QuoteServices _quoteServices;

    public QuoteController()
    {
        _quoteServices = new QuoteServices();
    }

    [HttpGet("GetQuote")]
    public List<Quote> GetQuote()
    { 
        return _quoteServices.GetQuote();
    }

    [HttpPost("AddQuote")]
    public void AddQuote(Quote quote)
    {
        _quoteServices.AddQuote(quote);
    }

    [HttpPut("UpdateQuotes")]
    public void UpdateQuotes(Quote quote)
    {
        _quoteServices.UpdateQuote(quote);
    }
    [HttpDelete("DeleteQuote")]
    public void DeleteQuote(int id)
    {
        _quoteServices.DeleteQuote(id);
    }

    [HttpGet("GetByCategory")]
    public List<Quote> GetByCategory(int id)
    {
       return _quoteServices.GetAllQuotesByCategory(id);
    }
    
    [HttpGet("GetRandomQuote")]
    public List<Quote> GetRandomQuote()
    {
        return _quoteServices.GetRandomQuote();
    }
}