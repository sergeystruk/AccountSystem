using BLL.Interface.Interfaces;

namespace BLL.Interface.Entities
{
    class BaseAccount : AbstractBankAccount
    {
        public BaseAccount(PersonalInfo personalInfo, IBankAccountNumberGenerator generator) : base(personalInfo, generator)
        {
            SetCredit(0);
        }

        private BaseAccount() : base()
        {
            amountOfCredit = 0;
        }

        private static void SetCredit(decimal sum)
        {
            amountOfCredit = 0;
        }

        protected override void CalclateBenefitPoints(decimal sum)
        {
            benefitPoints = 0;
        }
    }
}
