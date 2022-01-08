using PhramacyLibrary.Model;
using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Repository
{

    public class FeedbackResponsesRepository : Repo<FeedbackResponse>, IFeedbackResponsesRepository
    {
        public FeedbackResponsesRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
