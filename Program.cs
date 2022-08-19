using Unit25;
using Unit25.Models;
using Unit25.Repositories;
using AppContext = Unit25.AppContext;

UserRepository userRepository = new UserRepository();

var newUser = userRepository.AddNewUser("qwe", "1@2.3");
var newUser2 = userRepository.AddNewUser("qwe2", "1@2.3");

var allUsers = userRepository.GetAllUsers();
var userById = userRepository.GetUserById(6);
var usersWithSimilarEmail = userRepository.GetUsersWithSimilarEmail("@2.");

var updatedUser = userRepository.UpdateUser(5, "Иван", "1@222.3");

var deletedUser = userRepository.DeleteUser(6);


BookRepository bookRepository = new BookRepository();
var newBook1 = bookRepository.AddNewBook("QQQ1", "qqq", 1990, "qq");
var newBook2 = bookRepository.AddNewBook("WWW2", "www", 1992, "ww");

using (var db = new AppContext())
{
    var v1 = db.Books.FirstOrDefault();
    v1.UserId = 1;

    var v2 = db.Books.OrderByDescending(x => x.Id).FirstOrDefault();
    v2.UserId = 1;
    db.SaveChanges();
}

