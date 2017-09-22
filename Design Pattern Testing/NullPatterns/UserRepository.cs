using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Pattern_Testing.NullPatterns
{
    class UserRepository
    {
        private IEnumerable<IUser> _userList;

        public UserRepository()
        {
            _userList = new List<IUser>();
            //_userList.Add(new User {Name = "Joe Blow "});
            //    { new User { Name = "Mary Smith" }}
        }

        public IEnumerable<IUser> Find(string username)
        {
            return new IUser[0];
        }
    }
}
