using PhramacyLibrary.Model;
using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
using PharmacyLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Services
{
    public class FeedbackResponsesService
    {
        private readonly IFeedbackResponsesRepository feedbackResponsesRepository;
        public FeedbackResponsesService(DatabaseContext context)
        {
            feedbackResponsesRepository = new FeedbackResponsesRepository(context);
        }
        public List<FeedbackResponse> GetAll()
        {
            return feedbackResponsesRepository.GetAll();
        }
        public FeedbackResponse FindById(int id)
        {
            return feedbackResponsesRepository.FindById(id);
        }
        public void Add(FeedbackResponse feedbackResponse)
        {
            feedbackResponsesRepository.Add(feedbackResponse);
        }
        public void Update(FeedbackResponse feedbackResponse)
        {
            feedbackResponsesRepository.Update(feedbackResponse);
        }
        public void Delete(int id)
        {
            feedbackResponsesRepository.Delete(id);
        }
        public void Save()
        {
            feedbackResponsesRepository.Save();
        }
    }
}
