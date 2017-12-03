using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MarketimWebApi.Base;

namespace MarketimWebApi.Controllers
{
    [Route("[controller]")]
    public class ValuesController : BaseController
    {
        //// GET values
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET values/5
        [HttpGet("{id}")]
        [Validate(ValidateSessionType = ValidateSessiondTypeEnum.BeforeLogin,OperationCode = OperationsCodeEnum.GetCustomerInfo)]
        public int Get(int id)
        {
            int i = GetSessionIntValue("test",0);
            i += 1;
            SetSessionIntValue("test",i);

            return i;
        }

        //// POST values
        //[HttpPost]
        //public IEnumerable<string> Post([FromBody]string value)
        //{
        //    return new string[] { value };
        //}

        //// PUT values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
