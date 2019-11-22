using DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Library.Repository
{
    public class ScoreCardRepository : IScoreCardRepository
    {
       protected QuizzesDbEntities context;
        public ScoreCardRepository(QuizzesDbEntities context)
        {
            this.context = context;
        }

        public Task<List<GetScoreCardForUser_Result>> GetById(int id )
        {
            return Task.Run(()=> context.GetScoreCardForUser(id).ToList());
        }

    }
}
