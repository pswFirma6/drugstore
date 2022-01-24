using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmacyLibrary.Exceptions;
using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
using PharmacyLibrary.Repository;
using PharmacyLibrary.Services;

namespace Pharmacy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbacksController : ControllerBase
    {
        private FeedbacksService feedbacksService;
        private IFeedbacksRepository feedbacksRepository;

        public FeedbacksController(DatabaseContext context)
        {
            feedbacksRepository = new FeedbacksRepository(context);
            feedbacksService = new FeedbacksService(feedbacksRepository);
        }

        // GET: api/Feedbacks
        [HttpGet]
        public List<Feedback> GetFeedbacks()
        {
            return feedbacksService.GetAll();
        }

        // GET: api/Feedbacks/5
        [HttpGet("{id}")]
        public Feedback GetFeedback(int id)
        {
            Feedback feedback = feedbacksService.FindById(id);
            if(feedback == null)
            {
                throw new CustomNotFoundException("Feedback with id: " + id + " doesn't exist!");
            }
            return feedbacksService.FindById(id);
        }

        [HttpPost]
        public IActionResult PostFeedback(Feedback feedback)
        {
            feedbacksService.CreateFeedback(feedback);
            return CreatedAtAction("GetFeedback", new { id = feedback.Id }, feedback);
        }

    }
}
