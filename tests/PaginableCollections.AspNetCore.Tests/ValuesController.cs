namespace PaginableCollections.AspNetCore.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly int[] values = new int[] { };

        [HttpGet]
        public IEnumerable<int> Get()
        {
            return values;
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}