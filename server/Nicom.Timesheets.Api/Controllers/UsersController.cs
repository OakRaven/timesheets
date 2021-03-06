﻿using Nicom.Timesheets.Data.Repositories;
using Nicom.Timesheets.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Nicom.Timesheets.Api.Controllers
{
    public class UsersController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<UserModel> Get()
        {
            return RepositoryFactory.UserRepository.List(new[] { "Timesheets" });
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}