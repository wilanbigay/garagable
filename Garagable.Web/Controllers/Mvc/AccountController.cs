using System;
using System.Web.Mvc;
using System.Web.Security;
using Garagable.Model;
using Garagable.Service;
using Garagable.Web.ViewModels;

namespace Garagable.Web.Controllers.Mvc {

    [Authorize]
    public class AccountController : Controller {

        private readonly SecurityService _securityService;

        public AccountController(SecurityService securityService) {
            _securityService = securityService;
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl) {
            if (ModelState.IsValid) {
                User user = _securityService.ValidateUser(model.UserName, model.Password);
                if (user != null) {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl)) {
                        return Redirect(returnUrl);
                    } else {
                        return RedirectToAction("Index", "Home");
                    }
                } else {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult Register() {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Register(RegisterViewModel model) {
            if (ModelState.IsValid) {
                // Attempt to register the user

                var newUser = new User { UserName = model.UserName, Email = model.Email };
                bool isUserCreated = _securityService.CreateUser(newUser, model.Password);
                if (isUserCreated) {
                    FormsAuthentication.SetAuthCookie(model.UserName, createPersistentCookie: false);
                    return RedirectToAction("Index", "Home");
                } else {
                    ModelState.AddModelError("", "Error Registering");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public ActionResult LogOff() {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }


        public ActionResult ChangePassword() {
            return View();
        }


        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel model) {
            if (ModelState.IsValid) {

                try {
                    User currentUser = _securityService.GetUserByName(User.Identity.Name);
                    currentUser.HashedPassword = model.NewPassword;
                    _securityService.Save();
                    return RedirectToAction("ChangePasswordSuccess");
                } catch (Exception) {
                    ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public ActionResult ChangePasswordSuccess() {
            return View();
        }

    }
}
