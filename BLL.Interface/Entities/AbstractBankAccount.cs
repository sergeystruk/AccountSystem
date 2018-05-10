using System;
using System.Collections.Generic;
using BLL.Interface.Interfaces;

namespace BLL.Interface.Entities
{
    public abstract class AbstractBankAccount
    {
        private PersonalInfo personalInfo;
        private int number;
        private decimal amountOfMoney;
        protected static decimal amountOfCredit { get; set; }
        internal int benefitPoints;

        public AbstractBankAccount(PersonalInfo personalInfo, IBankAccountNumberGenerator generator)
        {
            this.personalInfo = personalInfo ?? throw new ArgumentNullException(nameof(personalInfo));
            number = generator.Generate();
            this.amountOfMoney = 0;
            this.benefitPoints = 0;
        }
        public AbstractBankAccount() { }

        public void Withdraw(decimal sum)
        {
            if(sum <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(sum));
            }

            if(sum <= amountOfMoney)
            {
                amountOfMoney -= sum;
            }

            if(sum > amountOfMoney)
            {
                if(sum - amountOfMoney < amountOfCredit)
                {
                    amountOfMoney -= sum;
                }
                else
                {
                    throw new ArgumentException(nameof(sum));
                }
            }

            CalclateBenefitPoints(-sum);
        }

        public void Deposit(decimal sum)
        {
            if (sum <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(sum));
            }

            amountOfMoney += sum;
            CalclateBenefitPoints(sum);
        }
        
        protected abstract void CalclateBenefitPoints(decimal sum);

        public override bool Equals(object obj)
        {
            var account = obj as AbstractBankAccount;
            return account != null &&
                   EqualityComparer<PersonalInfo>.Default.Equals(personalInfo, account.personalInfo) &&
                   number == account.number &&
                   amountOfMoney == account.amountOfMoney &&
                   benefitPoints == account.benefitPoints;
        }

        public override int GetHashCode()
        {
            var hashCode = 59772328;
            hashCode = hashCode * -1521134295 + EqualityComparer<PersonalInfo>.Default.GetHashCode(personalInfo);
            hashCode = hashCode * -1521134295 + number.GetHashCode();
            hashCode = hashCode * -1521134295 + amountOfMoney.GetHashCode();
            hashCode = hashCode * -1521134295 + benefitPoints.GetHashCode();
            return hashCode;
        }
    }
}
