using Infinigent_ClientFeednback.DTOs;
using Infinigent_ClientFeednback.Mappers;
using Infinigent_ClientFeednback.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;

namespace Infinigent_ClientFeednback.Controllers
{
    public class HomeController : ApiController
    {
        private qt_Infinigent_FeedbackEntities1 feedbackDB;

        public HomeController()
        {
            feedbackDB = new qt_Infinigent_FeedbackEntities1();
        }


        [HttpGet]
        [Route("api/home/getAllUsers")]

        public IHttpActionResult GetAllUsers()
        {
            try
            {
                var user = feedbackDB.ad_User.ToList();

                if (user == null)
                {
                    return NotFound();
                }
                List<ad_UserDTO> userlist = new List<ad_UserDTO>();
                foreach (var item in user)
                {
                    userlist.Add(UserMapper.MapAd_UserToAd_UserDTO(item));
                }

                return Ok(userlist);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        [HttpGet]
        [Route("api/home/getUserByUserIdAndPassword")]
        public IHttpActionResult GetUserByUserIdAndPassword(string userId, string password, string type)
        {
            try
            {
                var userType = 1;
                switch (type)
                {
                    case "bpo":
                        userType = 2;
                        break;
                    case "consultancy":
                        userType = 3;
                        break;
                    case "admin":
                        userType = 1;
                        break;
                    default:
                        break;
                }
                var user = new ad_User();
                if (userType == 2 || userType == 3)
                {
                    user = feedbackDB.ad_User.FirstOrDefault(x => x.UserId == userId && x.UserPassword == password && (x.Client_Type_Id == userType || x.Client_Type_Id == 4));
                }
                else
                {
                    user = feedbackDB.ad_User.FirstOrDefault(x => x.UserId == userId && x.UserPassword == password && x.Client_Type_Id == userType);
                }

                if (user == null)
                {
                    return NotFound();
                }

                return Ok(UserMapper.MapAd_UserToAd_UserDTO(user));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("api/home/createUser")]
        public IHttpActionResult CreateUser([FromBody] ad_UserDTO newUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var existingUser = feedbackDB.ad_User.FirstOrDefault(x => x.UserId == newUser.UserId);
                if (existingUser != null)
                {
                    return BadRequest("UserId already exists");
                }

                newUser.CreationDate = DateTime.Now;
                feedbackDB.ad_User.Add(UserMapper.MapAd_UserDTOToAd_User(newUser));
                feedbackDB.SaveChanges();
                return Ok(newUser);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("api/home/createCFFClientFeedback")]
        public IHttpActionResult CreateCFFClientFeedback(List<cff_Client_FeedbackDTO> newFeedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                foreach (var item in newFeedback)
                {
                    feedbackDB.cff_Client_Feedback.Add(new cff_Client_Feedback()
                    {
                        QuestionId = item.QuestionId,
                        ResponseRatingId = item.ResponseRatingId,
                        UserId = item.UserId,
                        IsActive = true,
                        CreationDate = DateTime.Now,
                        Creator = item.Creator
                    });
                    feedbackDB.SaveChanges();
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }



        [HttpPost]
        [Route("api/home/createBPOClientFeedback")]
        public IHttpActionResult CreateBPOClientFeedback(List<bpo_Client_FeedbackDTO> newFeedback)
        {

            try
            {
                foreach (var item in newFeedback)
                {
                    feedbackDB.bpo_Client_Feedback.Add(new bpo_Client_Feedback()
                    {
                        QuestionId = item.QuestionId,
                        ResponseRatingId = item.ResponseRatingId,
                        UserId = item.UserId,
                        IsActive = true,
                        CreationDate = DateTime.Now,
                        Creator = item.Creator
                    });
                    feedbackDB.SaveChanges();
                }
                
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/home/ClientFeedback/{fromDate}/{toDate}/{formType}")]

        public IHttpActionResult GetClientFeedback(DateTime fromDate, DateTime toDate, int formType)
        {
            try
            {

                var feedbackList = feedbackDB.Database.SqlQuery<ClientFeedBackDataDTO>("EXEC sp_GetClientFeedbackData @FromDate, @ToDate, @FormType",
                    new SqlParameter("FromDate", fromDate),
                    new SqlParameter("ToDate", toDate),
                    new SqlParameter("FormType", formType)
                ).ToList();

                return Ok(feedbackList);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPatch]
        [Route("api/home/updateUserIsActive/{userId}")]
        public IHttpActionResult UpdateUserIsActive(string userId, [FromBody] bool isActive)
        {
            try
            {
                var user = feedbackDB.ad_User.FirstOrDefault(x => x.UserId == userId);

                if (user == null)
                {
                    return NotFound();
                }

                // Convert isActive to nullable boolean (true for active, false for inactive)
                bool? isActiveValue = isActive ? true : false;
                user.IsActive = isActiveValue;

                feedbackDB.SaveChanges();

                return Ok("User IsActive updated successfully");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }






    }
}
