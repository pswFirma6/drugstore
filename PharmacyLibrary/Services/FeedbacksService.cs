using PhramacyLibrary.Model;
using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
using PharmacyLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Services
{
    public class FeedbacksService: IFeedbacksRepository
    {
        private readonly IFeedbacksRepository feedbacksRepository;

        public FeedbacksService(IFeedbacksRepository iFeedbacksRepository)
        {
            feedbacksRepository = iFeedbacksRepository;
        }
        public List<Feedback> GetAll()
        {
            return feedbacksRepository.GetAll();
        }
        public Feedback FindById(int id)
        {
            return feedbacksRepository.FindById(id);
        }
        public void Add(Feedback feedback)
        {
            feedbacksRepository.Add(feedback);
        }
        public void Update(Feedback feedback)
        {
            feedbacksRepository.Update(feedback);
        }
        public void Delete(int id)
        {
            feedbacksRepository.Delete(id);
        }
        public void Save()
        {
            feedbacksRepository.Save();
        }

        public void CreateFeedback(Feedback feedback)
        {
            feedback.Id = feedbacksRepository.GetAll().Count + 1;
            Add(feedback);
            Save();
        }
    }
}
