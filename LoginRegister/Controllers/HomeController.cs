using LoginRegister.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static System.Collections.Specialized.BitVector32;
using System.Security.Cryptography;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Data.SqlClient;
using System.Data;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Principal;
using Microsoft.Ajax.Utilities;
using System.Collections.ObjectModel;
using LoginRegister.Migrations;
using System.Data.Entity.Validation;
using Transaction = LoginRegister.Models.Transaction;

namespace LoginRegister.Controllers
{
    public class HomeController : Controller
    {
        private DB_Entities _db = new DB_Entities();
        // GET: Home
        public ActionResult Index()
        {
            if (Session["AccountNumber"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        //Dashboard

        public ActionResult Dashboard()
        {
            return View();
        }

        //GET: Register

        public ActionResult Register()
        {
            return View();
        }

        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User _user)
        {
            if (ModelState.IsValid)
            {
                var check = _db.User.FirstOrDefault(s => s.Email == _user.Email);
                if (check == null)
                {
                    _user.Password = GetMD5(_user.Password);
                    _db.Configuration.ValidateOnSaveEnabled = false;
                    _db.User.Add(_user);
                    _db.SaveChanges();
                    
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
                }


            }

           

            // email notfication
            MailMessage mm = new MailMessage("casestudyonlinebanking@gmail.com", _user.Email);

            mm.Subject = "Welcome to Online Banking";
            mm.Body =  "Hello"+" "+ _user.FullName + " "+"Thank you for Registeration In OnlineBanking Application."+ "This is your Username:" + _user.Email.ToString() + "   and this is your password: " + _user.Password.ToString() + ""+"You can now Login and get the benefit of Online Banking application";
            mm.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            NetworkCredential nc = new NetworkCredential("casestudyonlinebanking", "ndneepwnmskhnawt");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;

            smtp.Send(mm);

            ViewBag.message = "Thank you for Connecting with us!Your password has been sent to your regsitered mail id  ";

            
            return RedirectToAction("Index");
        }


        
       
    




    public ActionResult Login()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {


                var f_password = GetMD5(password);
                var data = _db.User.Where(s => s.Email.Equals(email) && s.Password.Equals(f_password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["FullName"] = data.FirstOrDefault().FullName + " "; //+ data.FirstOrDefault().LastName;
                    Session["Email"] = data.FirstOrDefault().Email;
                    Session["AccountNumber"] = data.FirstOrDefault().AccountNumber;
                    return RedirectToAction("Dashboard");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }
        //Account Details

        public ActionResult AccountDetails()
        {
            return View(_db.AccountDetails.ToList());
        }
       
        //get transaction
        public ActionResult Transaction()
        {
  
            return View();
            

        }

        [HttpPost]
        
         public ActionResult Transaction(Transaction _transfer)
        {
            // var check = _db.Transaction.FirstOrDefault(s => s.TransationAmount == _transfer.AccBalance);

            var check = _db.AccountDetails.FirstOrDefault(s => s.Balance >= _transfer.AccBalance);
            if ( _transfer.TransationAmount<= 0 )
            {
                throw new ApplicationException("Transfer Balance must be positive");
                //ViewBag.error = "Balance is insuffient to make transaction";
        
            }
            else if(_transfer.TransationAmount == 0)
            {
                throw new ApplicationException("Invalid Transfer Amount");
            }
            //




           //check.Balance-= check.Balance;
            // check.Balance += _transfer.TransationAmount;
            var temp = check.Balance - _transfer.TransationAmount;
            temp =check.Balance;
            

            _db.Transaction.Add(_transfer);
            try
            {
                
                _db.SaveChanges();
            }
            catch(DbEntityValidationException ex)
            {
                foreach(var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach(var validationError in entityValidationErrors.ValidationErrors) {
                        Response.Write("Property:"+validationError.PropertyName+"Error:"+validationError.ErrorMessage);
                    }
                }
            }
                return View();
            
        }


        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }


        //create a string MD5
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

        //Money

       /* [HttpPost]
        public ActionResult MoneyTransfer()
        {
            return View();
        }
       [HttpPost]
        public ActionResult MoneyTransfer(Transaction transfer)
        {
            var checkingFunds = _db.Transactions.Find(transfer.AccountNumber);
            if (checkingFunds. < transfer.)
            {
                ModelState.AddModelError("Amount", "You do not have enough money!");
            }

            var checkingExistedAccount = DB.checkAccounts.Where(account => account.AccountNumber == transfer.checkingExistedAccount).FirstOrDefault();
            if (checkingExistedAccount == null)
            {
                ModelState.AddModelError("checkingExistedAccount", "Account does not exist!");
            }


            if (ModelState.IsValid)
            {
                //Transaction transaction = new Transaction();
                //transaction.TransactionDate = DateTime.Now;       
                DB.Transactions.Add(new Transaction { CheckAccountId = transfer.CheckAccountId, Amount = -transfer.Amount });
                DB.Transactions.Add(new Transaction { CheckAccountId = checkingExistedAccount.Id, Amount = transfer.Amount });
                DB.SaveChanges();
                return RedirectToAction("Index", "Home");


            }

            return View();
        }*/


        //Benificary

                                       


    }
    }


          