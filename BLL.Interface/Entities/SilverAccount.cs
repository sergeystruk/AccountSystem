using System;
using BLL.Interface.Interfaces;

namespace BLL.Interface.Entities
{
    class SilverAccount : AbstractBankAccount
    {
        public SilverAccount(PersonalInfo personalInfo, IBankAccountNumberGenerator generator) : base(personalInfo, generator) { }

        private SilverAccount() : base()
        {
            amountOfCredit = 1000;
        }

        protected override void CalclateBenefitPoints(decimal sum)
        {
            throw new NotImplementedException();
        }
    }
}
