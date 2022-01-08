using PhramacyLibrary.Model;
using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Repository
{
    public class FeedbacksRepository : Repo<Feedback>, IFeedbacksRepository
    {
        public FeedbacksRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
