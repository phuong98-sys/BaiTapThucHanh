﻿using Abp.Threading;
using Microsoft.Owin.Security.Cookies;
using Newtonsoft.Json;
using OutlookFW.Mails;
using OutlookFW.Mails.Dto;
using OutlookFW.Senders.Dto;
using OutlookFW.Sessions;
using OutlookFW.Tokens;
using OutlookFW.Tokens.Dto;
using OutlookFW.Web.Models.Layout;
using OutlookFW.Web.Models.Outlooks;
using OutlookFW.Web.TokenStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace OutlookFW.Web.Controllers
{
    public class OutlookController : Controller
    {

        // GET: Outlook
        public static IMailAppService _mailAppService;
        public static ITokenAppService _tokenAppService;
        public static string email= null ;
        public static bool isSendSuccess = false;
        public static bool check = false;
        private readonly ISessionAppService _sessionAppService;
        public OutlookController(IMailAppService mailAppService,
            ITokenAppService tokenAppService,
             ISessionAppService sessionAppService
            )
        {
            _sessionAppService = sessionAppService;
            _mailAppService = mailAppService;
            _tokenAppService = tokenAppService;
        }
        public async Task<ActionResult> Index()
        {
          if(Session["Token"] != null)
            {
                Session["Email"] = await GetUserDetails();
                email = await GetUserDetails();
                //get list mail
                var listMail = await GetMail();

                
                var model = new IndexViewMail(listMail, email, isSendSuccess);
                model.isAuthenticated = true;
                return View(model);
            }
            else
            {
                var model = new IndexViewMail();
                return View(model);
            }
           
            
        }
        public ActionResult Error(string message, string debug)
        {
          
            return RedirectToAction("Index");
        }
        #region to Fetch Response from mail API 
        // lay ma uy quyen

       
        
        

        #endregion
        #region to Create AccessToken by using this Parameters
        // Lay ma truy cap
        public async Task<ActionResult> CreateOauthTokenForMail(string code)
        {
            var result = await _tokenAppService.CreateOauthTokenForMailAsync(code);
            //Lay userID de luu vao bang Token
            var userId = GetUserId();
            // kiem tra access Token da co trong Db chua
            // Neu chua co thi them vao, co roi thi thoi
            var isCheck = _tokenAppService.GetToken(userId,0);
            if (isCheck==null)
            {
                // luu accessToken vao Db
                await SaveToken(result.access_token, result.refresh_token, userId);
                Session["Token"] = result.access_token;
            }  
            else
            {
                Session["Token"] = isCheck.access_token;
               
            }
           
            return RedirectToAction("Index");
           
        }
        #endregion
        public async Task<List<MailListDto>> GetMail()
        {
            var listMail = await _mailAppService.GetMailAsync(Session["Token"].ToString());
            //var model = new IndexViewMail(listMail);
            return listMail;
        }
        public async Task<ActionResult> SendMail(string subject, string to, string body)
        {
            var vm = new IndexViewMail();
            try
            {
                var result = await _mailAppService.SendMailAsync(Session["Token"].ToString(), subject, to, body);
                if(result)
               isSendSuccess = true;
                else
                    isSendSuccess = false;
            }
            catch (Exception ex)
            {
                if (ex.Data == null)
                {
                    throw;
                    
                }
               isSendSuccess = false;
            }
            return RedirectToAction("Index");

        }

        public async Task<string> GetUserDetails()
        {
            var userDetail = await _mailAppService.GetUserDetailsAsync(Session["Token"].ToString());
            var email = userDetail.Email;
            return email;
        }
        public async Task<ActionResult> SignOut()
        {
          
            this.Session.Clear();
            this.Session.Abandon();
           
            check = false;
            Session["Token"] = null;
            var userId = GetUserId();
             _tokenAppService.DeleteToken(userId,0);
            return RedirectToAction("Index");

        }

        [ChildActionOnly]
        public int GetUserId()
        {
            var model = new SideBarUserAreaViewModel
            {
                LoginInformations = AsyncHelper.RunSync(() => _sessionAppService.GetCurrentLoginInformations())
            };

            return (int)model.LoginInformations.User.Id;
        }
        // Luu access token vao DB
        public async Task SaveToken(string accessToken, string refreshToken, int userId)
        {
            var token = new SaveToken();
            token.access_token = accessToken;
            token.refresh_token = refreshToken;
            token.user_Id = userId;
            token.type = 0;
            token.gmail = null;
            await _tokenAppService.SaveTokenAsync(token);


        }
    }
}