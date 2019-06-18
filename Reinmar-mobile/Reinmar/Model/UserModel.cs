using System;
namespace Reinmar.Model
{
    public class UserModel : BaseEntityModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public UserModel()
        {
        }
    }
}
