using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web_API_Connect_To_PostgreSQL_Net.Datas;
using Web_API_Connect_To_PostgreSQL_Net.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_API_Connect_To_PostgreSQL_Net.Controllers
{
    [Route("api/[controller]")]
    public class PersonController : Controller
    {

        private readonly DataContext context;

        public PersonController(DataContext context)
        {
            this.context = context;
        }

        // GET: api/Person
        [HttpGet]
        public async Task<IActionResult> GetAllPerson()
        {
            List<Person> people = await this.context.people.ToListAsync();
            return Ok(people);
        }

        // GET api/Person/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var person = await this.context.people.FindAsync(id);
            if (person == null)
            {
                return BadRequest("person doesn't exist");
            }
            return Ok(person);
        }

        // POST api/Person
        [HttpPost]
        public async Task<IActionResult> Post(Person person)
        {
            this.context.people.Add(person);
            await this.context.SaveChangesAsync();
            List<Person> people = await this.context.people.ToListAsync();
            return Ok(people);
        }

        // PUT api/Person/5
        [HttpPut]
        public async Task<IActionResult> Put(Person person)
        {
            var updatePerson = await this.context.people.FindAsync(person.Id);

            if (updatePerson == null)
            {
                return BadRequest("person doesn't exist");
            }

            updatePerson.FirstName = person.FirstName;
            updatePerson.LastName = person.LastName;
            updatePerson.Place = person.Place;

            await this.context.SaveChangesAsync();

            List<Person> people = await this.context.people.ToListAsync();
            return Ok(people);

        }

        // DELETE api/Person/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var person = await this.context.people.FindAsync(id);
            if (person == null)
            {
                return BadRequest("person doesn't exist");
            }

            this.context.people.Remove(person);
            await this.context.SaveChangesAsync();

            List<Person> people = await this.context.people.ToListAsync();
            return Ok(people);

        }
    }
}

