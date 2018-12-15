using Application.IO.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Application.IO.Services.Users
{
    public class UserUpdateServices : ServicesAbstraction
    {
        // ADD A DATA DE QUANDO O USUÁRIO CONFIRMA SUA CONTA POR E-MAIL
        public void UpdateUserEmailConfirm(string UserEmail)
        {
            var user = db.Users.Where(w => w.NormalizedEmail == UserEmail.ToUpper()).FirstOrDefault();
            if (user != null)
            {
                user.UserEmailConfirm = DateTime.Now;
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                user = null;
            }
        }
    }
}
