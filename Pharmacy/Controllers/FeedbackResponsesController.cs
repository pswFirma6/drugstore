using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
using PharmacyLibrary.Repository;
using PharmacyLibrary.Services;

namespace Pharmacy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackResponsesController : ControllerBase
    {
        private FeedbackResponsesService feedbackResponsesService;
        private IFeedbackResponsesRepository feedbackResponsesRepository;
        public FeedbackResponsesController(DatabaseContext context)
        {
            feedbackResponsesRepository = new FeedbackResponsesRepository(context);
            feedbackResponsesService = new FeedbackResponsesService(feedbackResponsesRepository);
        }

        // GET: api/FeedbackResponses
        [HttpGet]
        public List<FeedbackResponse> GetFeedbacResponses()
        {
            return feedbackResponsesService.GetAll();
        }

        // GET: api/FeedbackResponses/5
        [HttpGet("{id}")]
        public FeedbackResponse GetFeedbackResponse(int id)
        {
            return feedbackResponsesService.FindById(id);
        }
    }
}
