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
    public class TeamAPIController : ApiController
    {
        private readonly GenericRepository<TeamEntity> _objTeamGenericRepository = new GenericRepository<TeamEntity>();

        public List<TeamEntity> GetTeamList(int TeamId)
        {
            var TeamIdparam = new SqlParameter { ParameterName = "TeamId", DbType = DbType.Int32, Value = TeamId };
            var result = _objTeamGenericRepository.ExecuteSQL<TeamEntity>("GetTeamList", TeamIdparam);
            var TeamList = result.ToList();
            return TeamList;
        }

        public List<TeamEntity> GetTeamMember(int TeamId)
        {
            var TeamIdparam = new SqlParameter { ParameterName = "TeamId", DbType = DbType.Int32, Value = TeamId };
            var result = _objTeamGenericRepository.ExecuteSQL<TeamEntity>("ViewTeamMember", TeamIdparam).ToList();

            return result;

        }

        public int AddTeam(TeamEntity model)
        {
            var TeamNameparam = new SqlParameter { ParameterName = "TeamName", DbType = DbType.String, Value = model.TeamName };
            var EffectiveDateparam = new SqlParameter { ParameterName = "EffectiveDate", DbType = DbType.DateTime, Value = model.EffectiveDate };
            var UserIdparam = new SqlParameter { ParameterName = "UserId", DbType = DbType.Int32, Value = model.CreatedBy};
            var result = _objTeamGenericRepository.ExecuteSQL<int>("AddTeam", TeamNameparam, EffectiveDateparam, UserIdparam).FirstOrDefault();
            return result;


        }

        public int EditTeam(TeamEntity model)
        {
            var TeamIdparam = new SqlParameter { ParameterName = "TeamId", DbType = DbType.Int32, Value = model.TeamId };
            var TeamNameparam = new SqlParameter { ParameterName = "TeamName", DbType = DbType.String, Value = model.TeamName };
            var EffectiveDateparam = new SqlParameter { ParameterName = "EffectiveDate", DbType = DbType.DateTime, Value = model.EffectiveDate };
            var UserIdparam = new SqlParameter { ParameterName = "UserId", DbType = DbType.Int32, Value = model.ModifiedBy };
            var result = _objTeamGenericRepository.ExecuteSQL<int>("EditTeam ", TeamIdparam, TeamNameparam, EffectiveDateparam, UserIdparam).FirstOrDefault();
            return result;

        }

      

        public int AddTeamMember(int TeamId, string UserId, int loginUserId)
        {
            var TeamIdParam = new SqlParameter { ParameterName = "TeamId", DbType = DbType.Int32, Value = TeamId };
            var UserIdParam = new SqlParameter { ParameterName = "UserIdCSV", DbType = DbType.String, Value = UserId };
            var loginUserIdParam = new SqlParameter { ParameterName = "loginUserId", DbType = DbType.Int32, Value = loginUserId };
            var result = _objTeamGenericRepository.ExecuteSQL<int>("AddTeamMember", TeamIdParam, UserIdParam, loginUserIdParam).FirstOrDefault();
            return result;
        }

        public int DeleteTeamMember(int TeamId, string UserIdCSV)
        {
            var TeamIdParam = new SqlParameter { ParameterName = "TeamId", DbType = DbType.Int32, Value = TeamId };
            var UserIdParam = new SqlParameter { ParameterName = "UserId", DbType = DbType.String, Value = UserIdCSV };
            var result = _objTeamGenericRepository.ExecuteSQL<int>("DeleteTeamMember", UserIdParam, TeamIdParam).FirstOrDefault();
            return result;
        }

    }
}
