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

        public FeedbackResponsesService(IFeedbackResponsesRepository iFeedbackResponsesRepository)
        {
            feedbackResponsesRepository = iFeedbackResponsesRepository;
        }
        public List<FeedbackResponse> GetAll()
        {
            return feedbackResponsesRepository.GetAll();
        }
        public FeedbackResponse FindById(int id)
        {
            return feedbackResponsesRepository.FindById(id);
        }
        
    }
}
