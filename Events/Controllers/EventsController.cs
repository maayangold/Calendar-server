using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Events.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {    
        private static List<Event> events = new List<Event> { new Event { Id = 1,Title="I hate this project",Start=new DateOnly(2023,9,1) } , new Event { Id = 2, Title = " event2" , Start = new DateOnly(2023, 9, 8) } ,
            new Event { Id = 3, Title = "default event",Start = new DateOnly(2023, 6, 1) }, new Event {Id = 4, Title = "borred",Start = new DateOnly(2023, 6, 1) } };
        private static int counter = 5;
        // GET: api/<EventsController>
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return events;
        }

        //GET api/<EventsController>/5
       //[HttpGet("{id}")]
       // public Event Get(int id)
       // {   
           
       //      Event eve= events.Find(e => e.Id == id);
       //     return eve;
       // }

        //POST api/<EventsController>
        [HttpPost]
        public void Post([FromBody]Event newEvent)
        {
            events.Add(new Event {Id = ++counter, Title = newEvent.Title,Start=newEvent.Start});
        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Event newEvent)
        {
            
            var e = events.Find(ev => ev.Id == id);
            events.Remove(e);
            events.Add(new Event { Id = id, Title = newEvent.Title, Start = newEvent.Start });

        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var eve = events.Find(e => e.Id == id);
            events.Remove(eve);
        }
    }
}
