using System;
using System.Collections.Generic;
using DAL.Interface.Interfaces;
using BLL.Interface.Entities;

namespace DAL.Fake.Repositories
{
    class FakeRepository : IRepository<AbstractBankAccount>
    {
        private List<AbstractBankAccount> list;

        public void Delete(AbstractBankAccount t)
        {
            if(ReferenceEquals(t, null))
            {
                throw new ArgumentNullException(nameof(t));
            }

            if (list.Contains(t))
            {
                list.Remove(t);
            }
            else
            {
                throw new ArgumentException(nameof(t));
            }
        }

        public void Insert(AbstractBankAccount t)
        {
            if(ReferenceEquals(t, null))
            {
                throw new ArgumentNullException(nameof(t));
            }

            list.Add(t);
        }

        public void Update(AbstractBankAccount t)
        {
            throw new NotImplementedException();
        }
    }
}
