using APIService.BLL;
using APIService.BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIService.Controllers
{
    [RoutePrefix("api/Project")]
    public class ProjectController : ApiController
    {
        ProjectBLL pbll = new ProjectBLL();

        [Route("Insert")]
        [HttpPost]
        public IHttpActionResult Insert(ProjectBO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            pbll.Insert(model);
            return Ok();
        }

        [Route("GetAll")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            Response res = new Response();
            res = pbll.GetAll();
            return Ok(res.Data);
        }


        [Route("Delete")]
        [HttpPost]
        public IHttpActionResult projectDelete(ProjectBO model)
        {

            DataTable dt = pbll.Delete(model.ID);
            return Ok(dt);
            //Returning DT because we don't want to call two api for post and get at a time from frontend
        }

        [Route("GetbyId")]
        [HttpPost]
        public IHttpActionResult GetbyId(ProjectBO model)
        {
            DataTable dt = pbll.GetbyId(model.ID);
            return Ok(dt);
        }
    }
}
