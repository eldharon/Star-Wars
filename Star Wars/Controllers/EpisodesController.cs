using Star_Wars.DAL;
using Star_Wars.Model;
using Star_Wars.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Star_Wars.Controllers
{
    public class EpisodesController : ApiController
    {
        //Calling the Database
        private StarWarsContext db = new StarWarsContext();

        //Calling the Service layer
        private IService<Episode> _episode;

        //implement data init? probably not a good place to do it
        //Initialize using a ctor
        public EpisodesController(IService<Episode> episode)
        {
            _episode = episode;
        }

        // READ in CRUD
        public async Task<IEnumerable<Episode>> Get()
        {
            //return all episodes
            return await _episode.GetAllAsync();
        }

        // GET: api/Episodes/5
        // READ in CRUD (specifc episode by id)
        [ResponseType(typeof(Episode))]
        public async Task<HttpResponseMessage> Get(int? id)
        {
            //Check if id is provided
            if (id == null)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            //Try to locate the specified episode
            var episode = await _episode.FindAsync(x => x.EpisodeId == id);

            //Check if the requested episode exists
            if (episode == null)
            {
                return new HttpRequestMessage().CreateResponse(HttpStatusCode.NotFound);
            }

            //return the episode if nothing fails      
            return new HttpRequestMessage().CreateResponse(HttpStatusCode.OK, episode);
        }

        // POST: api/Episodes
        // CREATE in CRUD
        public async Task<HttpResponseMessage> Post([FromBody]Episode episode)
        {
            //Validate parsed episode
            if (ModelState.IsValid)
            {
                db.Episodes.Add(episode);
                await db.SaveChangesAsync();
                return new HttpRequestMessage().CreateResponse(HttpStatusCode.OK);
            }
            //If this line of code is reached, the validation went sideways
            //Throw the custom validation error TODO
            return new HttpRequestMessage().CreateResponse(HttpStatusCode.BadRequest);
        }

        // PUT: api/Episodes/5
        // UPDATE in CRUD
        public async Task<HttpResponseMessage> Put(int? id, [FromBody]Episode episode)
        {
            //Check if id is provided
            if (id == null)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            //Validate parsed episode
            if (ModelState.IsValid)
            {
                //ASK AWAY??? DO RESEARCH
                db.Entry(episode).State = System.Data.Entity.EntityState.Modified;
                await db.SaveChangesAsync();
            }

            //If this line of code is reached, the validation went sideways
            //Throw the custom validation error TODO
            return new HttpRequestMessage().CreateResponse(HttpStatusCode.InternalServerError);
        }

        // DELETE: api/Episodes/5
        // DELETE in CRUD
        public async Task<HttpResponseMessage> Delete(int? id)
        {
            //Check if id is provided
            if (id == null)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            //Try to locate the specified episode
            var character = await _episode.FindAsync(x => x.EpisodeId == id);

            //Check if the requested episode exists
            if (character == null)
            {
                return new HttpRequestMessage().CreateResponse(HttpStatusCode.NotFound);
            }

            //Perform deletion if id is not null and the episode does exist
            await _episode.DeleteAsync(character);

            //When deletion was performed succesfully
            return new HttpRequestMessage().CreateResponse(HttpStatusCode.OK);
        }
    }
}
