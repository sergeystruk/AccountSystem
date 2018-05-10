using System;
using DAL.Interface.Interfaces;
using BLL.Interface.Entities;

namespace BLL.ServiceImplementation
{
    sealed class Service
    {
        #region Singleton realization
        private static readonly Lazy<Service> lazy =
        new Lazy<Service>(() => new Service());

        public static Service Instance { get { return lazy.Value; } }

        private Service() { }
        #endregion

        public IRepository<AbstractBankAccount> repository { get; }

        public void AddNewAccount(AbstractBankAccount account)
        {
            repository.Insert(account);
        }

        public void DeleteAccount(AbstractBankAccount account)
        {
            repository.Delete(account);
        }

        public void WithdrawAccount(AbstractBankAccount account, decimal sum)
        {
            account.Withdraw(sum);
        }

        public void DepositAccount(AbstractBankAccount account, decimal sum)
        {
            account.Deposit(sum);
        }
    }
}
