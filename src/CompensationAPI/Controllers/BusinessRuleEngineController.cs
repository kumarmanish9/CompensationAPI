using AirlineCoreLibrary.Model;
using AirlineCoreLibrary.Service;
using AirlineCoreLibrary.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace CompensationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BusinessRuleEngineController(IRuleEngineService ruleEngineService) : ControllerBase
    {
        /// <summary>
        /// ExecuteRuleEngineRequest
        /// </summary>
        /// <param name="ruleEngineRequest"></param>
        /// <param name="requestId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Compensation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<RuleEngineResponse> ExecuteRuleEngineRequest(RuleEngineRequest ruleEngineRequest, string requestId)
        {
            string RequestId = Guid.NewGuid().ToString();
            RuleEngineResponse ruleEngineResponse = new();

            Stopwatch stopWatch = Stopwatch.StartNew();
            try
            {
                ruleEngineResponse = ruleEngineService.ExecuteRuleEngineRequest(ruleEngineRequest, requestId);
            }
            catch (Exception ex) when (ex.StackTrace != null || ex.Message != null)
            {
                AppLogger.LogInfo($"Request: {RequestId} \nError: ExecuteRuleEngineRequest \nMessage: {ex.Message} \nStackTrace: {ex.StackTrace}");
            }
            stopWatch.Stop();
            var timeElapse = stopWatch.ElapsedMilliseconds;
            AppLogger.LogInfo($"Request Id: {RequestId} \nBusiness Rule - Execution processed in milliseconds: {timeElapse} " +
                $"with output : {JsonConvert.SerializeObject(ruleEngineResponse, Formatting.Indented)}");
            return ruleEngineResponse;
        }


    }
}
