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
        private qt_Infinigent_FeedbackEntities feedbackDB;

        public HomeController()
        {
            feedbackDB = new qt_Infinigent_FeedbackEntities();
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
        public IHttpActionResult GetUserByUserIdAndPassword(string userId, string password)
        {
            try
            {
                var user = feedbackDB.ad_User.FirstOrDefault(x => x.UserId == userId && x.UserPassword == password);

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
        public IHttpActionResult CreateCFFClientFeedback(cff_Client_FeedbackDTO newFeedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                feedbackDB.cff_Client_Feedback.Add(new cff_Client_Feedback()
                {
                    QuestionId = newFeedback.QuestionId,
                    ResponseRatingId = newFeedback.ResponseRatingId,
                    UserId = newFeedback.UserId,
                    IsActive = true,
                    CreationDate = DateTime.Now,
                    Creator = newFeedback.Creator
                });
                feedbackDB.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

       
      
        [HttpPost]
        [Route("api/home/createBPOClientFeedback")]
        public IHttpActionResult CreateBPOClientFeedback(bpo_Client_FeedbackDTO newFeedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                feedbackDB.bpo_Client_Feedback.Add(new bpo_Client_Feedback()
                {
                    QuestionId = newFeedback.QuestionId,
                    ResponseRatingId = newFeedback.ResponseRatingId,
                    UserId = newFeedback.UserId,
                    IsActive = true,
                    CreationDate = DateTime.Now,
                    Creator = newFeedback.Creator
                });
                feedbackDB.SaveChanges();
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



    }
}
