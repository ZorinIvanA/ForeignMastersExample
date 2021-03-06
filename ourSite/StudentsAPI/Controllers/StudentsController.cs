﻿using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentsAPI.Controllers
{
    public class StudentsController : ApiController
    {
        [HttpGet]
        public IList<DALStudent> Get()
        {
            return new List<DALStudent>
            {
                new DALStudent() { id=0, Name="Ivanov Ivan", Birthday= DateTime.Parse("01.04.2000")},
                new DALStudent() { id=0, Name="Petrov Petr", Birthday= DateTime.Parse("01.08.2000")},
            };
        }

        [HttpGet]
        public DALStudent Get(Int32 id)
        {
            return new DALStudent
            { id = 0, Name = "Petrov Petr", Birthday = DateTime.Parse("01.08.2000") };
            
        }
        [HttpPut]
        public void Put(DALStudent student)
        {
            var x = 3;
        }

        [HttpDelete]
        public void Delete(Int32 id) { }

        [HttpPost]
        public void Update(DALStudent student)
        { }
    }
}
