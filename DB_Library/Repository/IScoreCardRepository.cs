using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Library.Repository
{
   public interface IScoreCardRepository
    {
         Task<List<GetScoreCardForUser_Result>> GetById(int id);
    }
}
