using DataModel;
using DB_Library.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Library.UnitOfWork
{
  public  interface IUnitOfWork
    {
        //IGenericRepository<QuizzSubject> QuizzSubjectRepository { get; }
      IGenericRepository<T> Repository<T>() where T : class;
      IScoreCardRepository ScoreCardRepository();
      void Save();

    }
}
