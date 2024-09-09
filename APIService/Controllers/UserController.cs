using APIService.BLL;
using APIService.BO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIService.Controllers
{
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        UserBLL userbll = new UserBLL();


        [Route("Insert")]
        [HttpPost]
        public IHttpActionResult Register(UserBO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            userbll.Insert(model);
            return Ok();
        }

        [Route("GetAll")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            //Response res = new Response();
            ////res = userbll.GetAll();
            //res = userbll.GetAllUser();
            //return Ok(res.Data);

            //Response res = userbll.GetAllUser();
            //var data = JsonConvert.SerializeObject(res.Data);
            //return Ok(data);

            Response res = userbll.GetAllUser();
            return Ok(res.Data);
        }


        [Route("Delete")]
        [HttpPost]
        public IHttpActionResult userDelete(UserBO model)
        {

            //DataTable dt =userbll.Delete(Convert.ToInt32(Id));
            DataTable dt = userbll.Delete(Convert.ToInt32(model.user_id));
            return Ok(dt);
            //Returning DT because we don't want to call two api for post and get at a time from frontend
        }


        [Route("Update")]
        [HttpPost]
        public IHttpActionResult Update(UserBO model)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            userbll.Update(model);
            return Ok();
        }

        [Route("GetbyId")]
        [HttpPost]
        public IHttpActionResult GetbyId(UserBO model)
        {
            DataTable dt = userbll.GetbyId(Convert.ToInt32(model.user_id));
            return Ok(dt);
        }


    }
}
