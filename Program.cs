using Unit25;
using Unit25.Models;
using AppContext = Unit25.AppContext;

using (var db = new AppContext())
{
    var user1 = new User { Name = "Arthur", Email = "q@we.rty" };
    var user2 = new User { Name = "Klim", Email = "a@sdf.gh" };

    db.Users.Add(user1);
    db.Users.Add(user2);
    db.SaveChanges();
}
