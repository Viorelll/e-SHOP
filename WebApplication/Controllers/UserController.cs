using System.Collections.Generic;
using DomainModel.Shop;
using WebApplication.Filtres;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    using System.Net;
    using System.Web.Mvc;
    using Repository.Interfaces;
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        // GET: Users
        public ActionResult Index()
        {
            var users =_userRepository.GetAll();
            var usersViewModel = AutoMapper.Mapper.Map<IList<User>, IList<UserViewModel>>(users);

            return View(usersViewModel);
           
        }

        // GET: Users/Details/5
        public ActionResult Details(long ? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = _userRepository.GetUserById(id);
            UserViewModel userViewModel = AutoMapper.Mapper.Map<User, UserViewModel>(user);
                

            if (userViewModel == null)
            {
                return HttpNotFound();
            }
            return View(userViewModel);
        }

        // GET: Users/CreateUser
        [AjaxOrChildActionOnly]
        public ActionResult CreateUser()
        {
            return PartialView("Create");
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerViewModel customer)
        {
            if (ModelState.IsValid)
            {
                Customer cust = AutoMapper.Mapper.Map<CustomerViewModel, Customer>(customer);
                _userRepository.Save(cust);
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = _userRepository.GetUserById(id);
            UserViewModel userViewModel = AutoMapper.Mapper.Map<User, UserViewModel>(user);

            if (userViewModel == null)
            {
                return HttpNotFound();
            }
            return View(userViewModel);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(long id, CustomerViewModel user)
        {
            if (ModelState.IsValid)
            {
             
                var userUpdate = _userRepository.GetUserById(id);

                userUpdate.Id = user.Id;
                userUpdate.Username = user.Username;
                userUpdate.FirstName = user.FirstName;
                userUpdate.LastName = user.LastName;
                userUpdate.Adress = user.Adress;
                userUpdate.Email = user.Email;
                userUpdate.Password = user.Password;

                _userRepository.Update(userUpdate);
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = _userRepository.GetUserById(id);
            var usersViewModel = AutoMapper.Mapper.Map<User, UserViewModel>(user);

            if (usersViewModel == null)
            {
                return HttpNotFound();
            }

            return View(usersViewModel);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            User user = _userRepository.GetUserById(id);
            _userRepository.Delete(user);
           
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
               _userRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
