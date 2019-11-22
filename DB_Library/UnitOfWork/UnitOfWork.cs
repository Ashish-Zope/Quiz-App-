using DataModel;
using DB_Library.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_Library;
namespace DB_Library.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly QuizzesDbEntities _context;
        private IGenericRepository<QuizzSubject> _modelRepository;
        private IScoreCardRepository _scoreCardRepository;
        // private IQuizzRepository _modelQuizzRepository;
        private Dictionary<Type, object> repositories = new Dictionary<Type, object>();
        public UnitOfWork(QuizzesDbEntities context)
        {
            _context = context;
            _scoreCardRepository = new ScoreCardRepository(_context);
 //         repositories.Add(typeof(QuizzSubject), new QuizzSubjectRepository(_context));
        }
        public IScoreCardRepository ScoreCardRepository()
        {
            return this._scoreCardRepository;
        }

        public IGenericRepository<T> Repository<T>() where T : class
        {
            if (repositories.Keys.Contains(typeof(T)) == true)
            {
                return repositories[typeof(T)] as IGenericRepository<T>;
            }
            IGenericRepository<T> repo = new GenericRepository<T>(_context);
            repositories.Add(typeof(T), repo);
            return repo;
        }


       

        //public IGenericRepository<QuizzSubject> QuizzSubjectRepository
        //{
        //    get { return _modelRepository ?? (_modelRepository = new GenericRepository<QuizzSubject>(_context)); }
        //}



        //public IQuizzRepository QuizzSubjectRepository
        //{
        //    get { return _modelQuizzRepository ?? (_modelQuizzRepository = new QuizzRepository<QuizzModel> (_context)); }
        //}



        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }

    }
}
