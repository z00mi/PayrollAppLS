using System.Collections.Generic;
using System.Linq;
using PayrollApp.Domain.Model;
using PayrollApp.Domain.Specifications;

namespace PayrollApp.Domain.Repositories
{
    public interface IRepository<TAggr, in TUid> where TAggr : AggregateRoot<TUid>
    {
        TAggr Get(TUid uid);
        TAggr GetOrDefault(TUid uid);
        IEnumerable<TAggr> GetAll();

        void Update(TAggr aggregate);
        void Insert(TAggr aggregate);
        void Delete(TAggr aggregate);

        void Save();
    }
}
