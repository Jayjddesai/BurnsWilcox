using BurnsWilcoxCLP.API.Utility;
using BurnsWilcoxCLP.Models;
using BurnsWilcoxCLP.Models.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BurnsWilcoxCLP.API.API
{
    public class UserAPIController : ApiController
    {
        private readonly GenericRepository<LoginEntity> _objGenericRepository = new GenericRepository<LoginEntity>();
        private readonly GenericRepository<UserEntity> _objUserGenericRepository = new GenericRepository<UserEntity>();
        private readonly GenericRepository<UserAgency> _objUserAgencyGenericRepository = new GenericRepository<UserAgency>();

        public User.LoginUser AuthenticateUser(string emailAddress, string password)
        {
            var loginEntity = new User.LoginUser();
            //  var result = _objGenericRepository.ExecuteSQL<StateDetailEntity>("GetStateList");
            // var dealList = result.ToList();
            //return dealList;
            try
            {
                var emailParam = new SqlParameter
                {
                    ParameterName = "Email",
                    DbType = DbType.String,
                    Value = emailAddress
                };
                var passwordParam = new SqlParameter
                {
                    ParameterName = "Password",
                    DbType = DbType.String,
                    Value = Security.Encrypt(password)
                };

                loginEntity = _objGenericRepository.ExecuteSQL<User.LoginUser>("UserMaster_AuthenticateUser", emailParam, passwordParam).FirstOrDefault();
                //loginUser = userList.FirstOrDefault();
                
            }
           
             catch (Exception ex)
            {
                // _logger.Error(ex);
            }
            return loginEntity;
        }

        /// <summary>
        /// Method to get menus based on user access permissions
        /// </summary>
        /// <param name="userTypeId">User TypeId</param>
        /// <returns></returns>
        public List<UserAccessPermissions> UserAccessPermissions(short userTypeId)
        {
            var userTypeIdParam = new SqlParameter
            {
                ParameterName = "UserTypeId",
                DbType = DbType.Int16,
                Value = userTypeId
            };

            var userAccessPermissionsList = _objGenericRepository.ExecuteSQL<UserAccessPermissions>("UserAccessPermissions", userTypeIdParam).ToList();
            return userAccessPermissionsList;
        }

      // Add Details to User Master
        public string AddUser(UserAgency model)
        {
            var UserIdParam = new SqlParameter { ParameterName = "UserId", DbType = DbType.Int32, Value = model.UserId };
            var AgencyIdParam = new SqlParameter { ParameterName = "AgencyId", DbType = DbType.Int32, Value = model.AgencyId };
            var DisplayNameparam = new SqlParameter { ParameterName = "DisplayName", DbType = DbType.String, Value = model.DisplayName };
            var EmailAddressparam = new SqlParameter { ParameterName = "EmailAddress", DbType = DbType.String, Value = model.EmailAddress != null ? model.EmailAddress : "" };
            var Passwordparam = new SqlParameter { ParameterName = "Password", DbType = DbType.String, Value = Security.Encrypt(model.Password) != null ? Security.Encrypt(model.Password) : "" };
            var AgencyNameparam = new SqlParameter { ParameterName = "Name", DbType = DbType.String, Value = model.Name };
            var Addressparam = new SqlParameter { ParameterName = "Address", DbType = DbType.String, Value = model.Address };
            var Zipparam = new SqlParameter { ParameterName = "Zip", DbType = DbType.String, Value = model.Zip };
            var Cityparam = new SqlParameter { ParameterName = "City", DbType = DbType.String, Value = model.City };
            var StateIdparam = new SqlParameter { ParameterName = "StateId", DbType = DbType.Int32, Value = model.StateId };
            var CountryIdparam = new SqlParameter { ParameterName = "CountryId", DbType = DbType.Int32, Value = model.CountryId };
            var Phoneparam = new SqlParameter { ParameterName = "Phone", DbType = DbType.String, Value = model.Phone };
            var OfficeIdparam = new SqlParameter { ParameterName = "OfficeId", DbType = DbType.Int32, Value = model.OfficeId };
            var ProducerIdparam = new SqlParameter { ParameterName = "ProducerId", DbType = DbType.Int32, Value = model.ProducerId };
            var AccessCodeparam = new SqlParameter { ParameterName = "AccessCode", DbType = DbType.String, Value = model.AccessCode };
            var UserTypeIdParam = new SqlParameter { ParameterName = "UserTypeId", DbType = DbType.Int32, Value = (object) model.UserTypeId ?? DBNull.Value };
            var IsEmailVerifiedParam = new SqlParameter { ParameterName = "IsEmailVerified", DbType = DbType.Boolean, Value = model.IsEmailVerified };
            var IsUserVerifiedParam = new SqlParameter { ParameterName = "IsUserVerified", DbType = DbType.Boolean, Value = model.IsUserVerified };
            var IsActiveParam = new SqlParameter { ParameterName = "IsActive", DbType = DbType.Boolean, Value = model.IsActive };
            var CreatedByParam = new SqlParameter { ParameterName = "CreatedBy", DbType = DbType.Int32, Value = model.CreatedBy };

            var result = _objUserAgencyGenericRepository.ExecuteSQL<string>("UserMaster_Save",UserIdParam,AgencyIdParam, DisplayNameparam, EmailAddressparam, 
                                                                    Passwordparam, AgencyNameparam, Addressparam,Zipparam, Cityparam, StateIdparam, 
                                                                    CountryIdparam, Phoneparam, OfficeIdparam, ProducerIdparam, AccessCodeparam, UserTypeIdParam,
                                                                    IsEmailVerifiedParam, IsUserVerifiedParam, IsActiveParam, CreatedByParam).FirstOrDefault();


            return result;


        }

        public UserEntity UserExistbasedonEmail(string EmailAdress)
        {
            var EmailAdressparam = new SqlParameter { ParameterName = "EmailAdress", DbType = DbType.String, Value = EmailAdress };
            var result = _objUserGenericRepository.ExecuteSQL<UserEntity>("UserExistbasedonEmail", EmailAdressparam).FirstOrDefault();
            return result;
        }

        public UserEntity GetUserById(int UserId)
        {
            var UserIdparam = new SqlParameter { ParameterName = "UserId", DbType = DbType.Int32, Value = UserId };
            var result = _objUserGenericRepository.ExecuteSQL<UserEntity>("GetUserById", UserIdparam).FirstOrDefault();
            return result;
        }

        // Get User Master Details Based On ID
        public UserAgency GetUserDetailsById(int UserId)
        {
            var UserIdparam = new SqlParameter { ParameterName = "UserId", DbType = DbType.Int32, Value = UserId };
            var result = _objUserGenericRepository.ExecuteSQL<UserAgency>("GetUserDetailsById", UserIdparam).FirstOrDefault();
            return result;
        }


        public string DeleteUserById(int UserId)
        {
            var UserIdparam = new SqlParameter { ParameterName = "UserId", DbType = DbType.Int32, Value = UserId };
            var result = _objUserGenericRepository.ExecuteSQL<string>("DeleteUserById", UserIdparam).FirstOrDefault();
            return result;
        }

        public List<UserMasterList> GetUserMasterList()
        {
            List<UserMasterList> result = _objUserGenericRepository.ExecuteSQL<UserMasterList>("GetUserMasterList").ToList();
            return result;
        }

        public int ResetPassword(UserEntity model)
        {
            var UserIdparam = new SqlParameter { ParameterName = "UserId", DbType = DbType.Int32, Value = model.UserId };
            var Passwordparam = new SqlParameter { ParameterName = "Password", DbType = DbType.String, Value = Security.Encrypt(model.Password) != null ? Security.Encrypt(model.Password) : "" };
            var result = _objUserGenericRepository.ExecuteSQL<int>("ResetPassword", UserIdparam, Passwordparam).FirstOrDefault();
            return result;

        }



        public List<UserTypeEntity> GetUserTypelist()
        {
            var result = _objGenericRepository.ExecuteSQL<UserTypeEntity>("GetUserTypeList").ToList();
            return result;
        }

        //public List<UserTypeEntity> GetUserTypeList()
        //{
        //    var userTypeList = _objGenericRepository.ExecuteSQL<UserTypeEntity>("GetUserTypeList").ToList();
        //    return userTypeList;
        //}

        public List<UserTypeMenuSearch> GetUserTypeMenuSearchlist(short userTypeId)
        {
            var userTypeIdParam = new SqlParameter
            {
                ParameterName = "UserTypeId",
                DbType = DbType.Int16,
                Value = userTypeId
            };

            var result = _objGenericRepository.ExecuteSQL<UserTypeMenuSearch>("GetAccessRightsByUserType", userTypeIdParam).ToList();
            return result;
        }

        public int SaveUserTypeActions(DataTable model)
        {
            var userTypeMenusDataParam = new SqlParameter
            {
                ParameterName = "UserTypeMenusData",
                SqlDbType = SqlDbType.Structured,
                Value = model,
                TypeName = "dbo.UserTypeMenusTable"
            };

            var result = _objGenericRepository.ExecuteSQL<int>("SaveUserTypeMenu", userTypeMenusDataParam);

            return result.FirstOrDefault();
        }
        
        public List<UserEntity> GetUserList(int TeamId)
        {
            var TeamIdParam = new SqlParameter { ParameterName = "TeamId", DbType = DbType.Int32, Value = TeamId };
            var result = _objUserGenericRepository.ExecuteSQL<UserEntity>("GetUserListForTeam", TeamIdParam);
            var TeamList= result.ToList();
            return TeamList;
        }
        /// <summary>
        /// List of External User 
        /// </summary>
        /// <returns>List</returns>
        /// 
        public List<UserEntity> GetExternalUserList()
        {
            var ExternaluserList = _objUserGenericRepository.ExecuteSQL<UserEntity>("GetExternalUserList").ToList();
            return ExternaluserList;
        }

     
    }
}