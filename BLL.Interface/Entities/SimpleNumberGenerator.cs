using BLL.Interface.Interfaces;

namespace BLL.Interface.Entities
{
    class SimpleNumberGenerator : IBankAccountNumberGenerator
    {
        private int number = 0;

        public int Generate()
        {
            return ++number;
        }
    }
}
