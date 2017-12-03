using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Formatters.Json;
using Microsoft.AspNetCore.Http;
namespace MarketimWebApi.Base
{
    public class Validate: ActionFilterAttribute
    {

        public ValidateSessiondTypeEnum ValidateSessionType;
        public OperationsCodeEnum OperationCode;



        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = (BaseController)context.Controller;
            String UserId = controller.GetSessionCustomer();
            if (!ValidateSession(UserId)){
                context.Result = getInvalidSessionResult();
                return;
            }else if(!ValidateRights(UserId)){
                context.Result = getUserRightsDeniedResult();
                return;
            }else{
                base.OnActionExecuting(context);
            }
        }

        private IActionResult getUserRightsDeniedResult()
        {
            var result = new JsonResult("{value='getUserRightsDeniedResult'}")
            {
                StatusCode = 0
            };
            return result;
        }

        private IActionResult getInvalidSessionResult()
        {
            var result = new JsonResult("{value='getInvalidSessionResult'}")
            {
                StatusCode = 0
            };
            return result;
        }

        public bool ValidateRights(string userCode)
        {

            return true;
        }
        public bool ValidateSession(string userCode)
        {
            return true;
        }


    }
}
