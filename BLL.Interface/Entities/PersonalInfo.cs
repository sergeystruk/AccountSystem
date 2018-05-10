using System;

namespace BLL.Interface.Entities
{
    public class PersonalInfo
    {
        public string Name { get; }
        public string Surname { get; }
        public string Email { get; }

        internal PersonalInfo(string name, string surname, string email)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Surname = surname ?? throw new ArgumentNullException(nameof(surname));
            Email = email ?? throw new ArgumentNullException(nameof(email));
        }
    }
}
