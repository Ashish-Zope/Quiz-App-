using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Library.Repository
{
   public class QuizzSubjectRepository:GenericRepository<QuizzSubject>, IGenericRepository<QuizzSubject> 
    {
      public QuizzSubjectRepository(QuizzesDbEntities context):base(context)
       { 
       
       }

       public Task<List<QuizzSubject>> Get(System.Linq.Expressions.Expression<Func<QuizzSubject, bool>> filter = null, Func<IQueryable<QuizzSubject>, IOrderedQueryable<QuizzSubject>> orderBy = null, params System.Linq.Expressions.Expression<Func<QuizzSubject, object>>[] includes)
       {
           throw new NotImplementedException();
       }

       public IQueryable<QuizzSubject> Query(System.Linq.Expressions.Expression<Func<QuizzSubject, bool>> filter = null, Func<IQueryable<QuizzSubject>, IOrderedQueryable<QuizzSubject>> orderBy = null)
       {
           throw new NotImplementedException();
       }

       public Task<QuizzSubject> GetById(object id)
       {
           throw new NotImplementedException();
       }

       public Task<QuizzSubject> GetFirstOrDefault(System.Linq.Expressions.Expression<Func<QuizzSubject, bool>> filter = null, params System.Linq.Expressions.Expression<Func<QuizzSubject, object>>[] includes)
       {
           throw new NotImplementedException();
       }

       public void Insert(QuizzSubject entity)
       {
           throw new NotImplementedException();
       }

       public void Update(QuizzSubject entity)
       {
           throw new NotImplementedException();
       }

       public void Delete(object id)
       {
           throw new NotImplementedException();
       }
    }
}
