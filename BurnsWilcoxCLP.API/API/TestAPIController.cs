using BurnsWilcoxCLP.API.Utility;
using BurnsWilcoxCLP.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BurnsWilcoxCLP.API.API
{
    public class TestAPIController : ApiController
    {
        private readonly GenericRepository<StateEntity> _objGenericRepository = new GenericRepository<StateEntity>();

        public List<StateEntity> GetStateNameList()
        {
            var result = _objGenericRepository.ExecuteSQL<StateEntity>("GetStateList");
            var dealList = result.ToList();
            return dealList;
        }
    }
}
