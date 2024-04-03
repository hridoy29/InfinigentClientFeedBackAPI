using Infinigent_ClientFeednback.DTOs;
using Infinigent_ClientFeednback.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infinigent_ClientFeednback.Mappers
{
    public static class UserMapper
    {
        public static ad_UserDTO MapAd_UserToAd_UserDTO(ad_User ad_User)
        {
            var obj = new ad_UserDTO()
            {
                UserId= ad_User.UserId,
                Client_Type_Id=ad_User.Client_Type_Id,
                UserType=ad_User.ad_Client_Type.ClientType,
                IsActive=(bool)ad_User.IsActive,
                CreationDate=ad_User.CreationDate,
                Creator=ad_User.Creator
            };
            return obj;
        }

        public static ad_User MapAd_UserDTOToAd_User(ad_UserDTO ad_UserDTO)
        {
            var obj = new ad_User()
            {
                UserId = ad_UserDTO.UserId,
                Client_Type_Id = ad_UserDTO.Client_Type_Id,
                UserPassword=ad_UserDTO.UserPassword,
                IsActive = ad_UserDTO.IsActive,
                CreationDate = ad_UserDTO.CreationDate,
                Creator = ad_UserDTO.Creator
            };
            return obj;
        }

    }
}