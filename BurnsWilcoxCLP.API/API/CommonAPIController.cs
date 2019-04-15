using BurnsWilcoxCLP.API.Utility;
using BurnsWilcoxCLP.Models;
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
    public class CommonAPIController : ApiController
    {
        private readonly GenericRepository<StateEntity> _objStateGenericRepository = new GenericRepository<StateEntity>();

        private readonly GenericRepository<CountryEntity> _objCountryGenericRepository = new GenericRepository<CountryEntity>();


        public List<StateEntity> GetStateList(int CountryId)
        {
            var Countryparam = new SqlParameter { ParameterName = "CountryId", DbType = DbType.Int32, Value = CountryId };
            var result = _objStateGenericRepository.ExecuteSQL<StateEntity>("GetStateList", Countryparam);
            var StateList = result.ToList();
            return StateList;
        }
        public List<CountryEntity> GetCountryList()
        {
            var result = _objStateGenericRepository.ExecuteSQL<CountryEntity>("GetCountryList");
            var CountryList = result.ToList();
            return CountryList;
        }
    }
}
