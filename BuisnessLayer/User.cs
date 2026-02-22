using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace BusinessLayer
{
    public class User : IdentityUser
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Range(10, 150, ErrorMessage = "Age must be between 10 and 150!")]
        public int Age { get; set; }

        public User()
        {
        }

        public User(string username, string email, int age, string name)
        {
            this.UserName = username;
            this.Email = email;
            this.Age = age;
            this.Name = name;
        }

        public User(string id, string username, string email, int age, string name)
            : this(username, email, age, name)
        {
            this.Id = id;
        }
        public override string ToString()
        {
            return string.Format($"{Id} {Name} {Age}");
        }

        public static explicit operator User(ValueTask<IdentityUser> v)
        {
            throw new NotImplementedException();
        }
    }
}