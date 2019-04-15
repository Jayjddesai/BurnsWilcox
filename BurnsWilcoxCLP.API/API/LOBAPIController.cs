using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using BurnsWilcoxCLP.API.Utility;
using BurnsWilcoxCLP.Models;
using BurnsWilcoxCLP.Models.Common;
using log4net;


// ReSharper disable InconsistentNaming

namespace BurnsWilcoxCLP.API.API
{
    public class LOBAPIController : ApiController
    {
        private readonly GenericRepository<LOBEntity> _objGenericRepository = new GenericRepository<LOBEntity>();
        private readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public BaseApiResponse SavePolicyLOB(LOBEntity model)
        {
            var response = new BaseApiResponse();

            try
            {
                #region Parameters 

                var policyNumberParam = new SqlParameter
                {
                    ParameterName = "PolicyNumber",
                    DbType = DbType.String,
                    Value = model.PolicyNumber
                };

                var lOBIdParam = new SqlParameter
                {
                    ParameterName = "LOBId",
                    DbType = DbType.Int32,
                    Value = model.LOBId
                };

                var productIdParam = new SqlParameter
                {
                    ParameterName = "ProductId",
                    DbType = DbType.Int32,
                    Value = model.ProductId
                };

                var stateIdParam = new SqlParameter
                {
                    ParameterName = "StateId",
                    DbType = DbType.Int32,
                    Value = model.StateId
                };

                #endregion

                var result = _objGenericRepository.ExecuteSQL<int>("SavePolicyLOB", policyNumberParam, lOBIdParam, productIdParam, stateIdParam);
                var rowCount = result.FirstOrDefault();
                response.Success = rowCount > 0;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }
    }
}
