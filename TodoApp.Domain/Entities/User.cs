using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Domain.Entities
{

    public class User
    {
        #region builders
        protected User() { }
        public User(string username, string passwordHash)
        {
            Username = username;
            PasswordHash = passwordHash;
            CreatedAt = DateTime.UtcNow;
        }
        #endregion

        #region properties
        public int Id { get; private set; }
        public string Username { get; private set; }
        public string PasswordHash { get; private set; }
        public DateTime CreatedAt { get; private set; }
        #endregion

    }

}
