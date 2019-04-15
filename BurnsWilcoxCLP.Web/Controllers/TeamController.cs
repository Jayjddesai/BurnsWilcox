using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using BurnsWilcoxCLP.API.API;
using BurnsWilcoxCLP.Models;
using BurnsWilcoxCLP.Web.EmailHelper;
using System.IO;
using System.Web.Script.Serialization;


namespace BurnsWilcoxCLP.Web.Controllers
{
    public class TeamController : BaseAdminController
    {
        private readonly TeamAPIController _teamapicontroller;
        private readonly UserAPIController _userapicontroller;
        // GET: Team
        public TeamController()
        {
            _teamapicontroller = new TeamAPIController();
            _userapicontroller = new UserAPIController();
        }
        public ActionResult Index()
        {
            TeamEntity model = new TeamEntity();
            return View();
        }

        public ActionResult GetTeamList()
        {
            var GetTeamList = _teamapicontroller.GetTeamList(0);
            return Json(new { GetTeamList }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ViewTeamMember(int Id)
        {
            List<TeamEntity> model = new List<TeamEntity>();
            model = _teamapicontroller.GetTeamMember(Id);
            return View(model);

        }

        [HttpGet]
        public ActionResult AddEditTeam(int teamId)
        {
            TeamEntity model = new TeamEntity();
            var allUsers = _userapicontroller.GetUserList(teamId);
            var GetAllUser = allUsers.Where(s => s.IsSelected == false);
            model.AvailableUser = new SelectList(GetAllUser, "UserId", "DisplayName");
            var GetAllSelectedUser = allUsers.Where(s => s.IsSelected == true);
            model.SelectUser = new SelectList(GetAllSelectedUser, "UserId", "DisplayName");
            if (teamId > 0)
            {
                model = _teamapicontroller.GetTeamList(teamId).FirstOrDefault();
                model.AvailableUser = new SelectList(GetAllUser, "UserId", "DisplayName");
                model.SelectUser = new SelectList(GetAllSelectedUser, "UserId", "DisplayName");

                return View(model);
            }
          

            return View(model);
        }

        [HttpPost]
        public ActionResult AddEditTeam(TeamEntity model)
        {
            var allUsers = _userapicontroller.GetUserList(Convert.ToInt32(model.TeamId));
            var GetAllUser = allUsers.Where(s => s.IsSelected == false);
            model.AvailableUser = new SelectList(GetAllUser, "UserId", "DisplayName");
            var GetAllSelectedUser = allUsers.Where(s => s.IsSelected == true);
            model.SelectUser = new SelectList(GetAllSelectedUser, "UserId", "DisplayName");

            if(model.TeamId>0)
            {
                model.ModifiedBy = ProjectSession.LoginUserDetails.UserId;
                int EditTeam = _teamapicontroller.EditTeam(model);
                if (EditTeam>0)
                {
                    this.SuccessNotification("Team update successfully");
                    return Redirect("Index");
                }
                else
                {
                    this.ErrorNotification("Team name already exist");
                    return View(model);
                }
              
                
            }
            else
            {
                model.CreatedBy = ProjectSession.LoginUserDetails.UserId;
                int AddTeam = _teamapicontroller.AddTeam(model);
                if (AddTeam > 0)
                {
                    this.SuccessNotification("Team added successfully now you can add team member");
                    return RedirectToAction("AddEditTeam", "Team", new { teamId = AddTeam });
                }
                else
                {
                    this.ErrorNotification("The team name already exist");
                    return View(model);
                }
            }
          
          
            return View(model);

        }

  


        [HttpGet]
        public ActionResult SaveTeamMember(int TeamId, string UserId)
        {
            var LoginUserId = ProjectSession.LoginUserDetails.UserId;
           
            int result = _teamapicontroller.AddTeamMember(TeamId, UserId, LoginUserId);
           
            return Json(true);
        }



        [HttpGet]
        public ActionResult DeleteTeamMember(int TeamId, string UserId)
        {
            var array_UserId = UserId.Split(',').ToList();

            int result = _teamapicontroller.DeleteTeamMember(TeamId, UserId);
         
            return Json(true);

        }


    }
}