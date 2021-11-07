using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmacyLibrary.Model;

namespace Pharmacy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackResponsesController : ControllerBase
    {
        private readonly FeedbackResponseDbContext _context;

        public FeedbackResponsesController(FeedbackResponseDbContext context)
        {
            _context = context;
        }

        // GET: api/FeedbackResponses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeedbackResponse>>> GetFeedbacResponses()
        {
            return await _context.FeedbackResponses.ToListAsync();
        }

        // GET: api/FeedbackResponses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FeedbackResponse>> GetFeedbackResponse(int id)
        {
            var feedbackResponse = await _context.FeedbackResponses.FindAsync(id);

            if (feedbackResponse == null)
            {
                return NotFound();
            }

            return feedbackResponse;
        }
    }
}
