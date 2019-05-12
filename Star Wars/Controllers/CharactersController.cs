﻿using Star_Wars.DAL;
using Star_Wars.Model;
using Star_Wars.Repository;
using Star_Wars.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;

namespace Star_Wars.Controllers
{
    public class CharactersController : ApiController
    {

        //Calling the Service layer
        private IService<Character> _character;
        //nieudana próba DI        
        //private Repository<Character> _character = new Repository<Character>();
        //implement data init? probably not a good place to do it
        //Initialize using a ctor
        public CharactersController(IService<Character> character)
        {
            _character = character;
        }

        // READ in CRUD
        public async Task<IEnumerable<Character>> Get()
        {
            //return all characters
            return await _character.GetAllAsync();
        }

        // GET: api/Characters/5
        // READ in CRUD (specifc character by id)
        [ResponseType(typeof(Character))]
        public async Task<HttpResponseMessage> Get(int? id)
        {
            //Check if id is provided
            if (id == null)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            //Try to locate the specified character
            var character = await _character.FindAsync(x => x.CharacterId == id);

            //Check if the requested character exists
            if (character == null)
            {
                return new HttpRequestMessage().CreateResponse(HttpStatusCode.NotFound);
            }

            //return the character if nothing fails      
            return new HttpRequestMessage().CreateResponse(HttpStatusCode.OK, character);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> Post([FromBody]Character character)
        {
            //Validate parsed character
            if (ModelState.IsValid)
            {
                await _character.AddAsync(character);
                return new HttpRequestMessage().CreateResponse(HttpStatusCode.OK);
            }
            //If this line of code is reached, the validation went sideways
            //Throw the custom validation error TODO
            return new HttpRequestMessage().CreateResponse(HttpStatusCode.InternalServerError);
        }

        // PUT: api/Characters/5
        // UPDATE in CRUD
        public async Task<HttpResponseMessage> Put(int? id, [FromBody]Character character)
        {
            //Check if id is provided
            if (id == null)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            //Validate parsed character
            if (ModelState.IsValid)
            {
                await _character.UpdateAsync(character, id.Value);
                return new HttpRequestMessage().CreateResponse(HttpStatusCode.OK);
            }

            //If this line of code is reached, the validation went sideways
            //Throw the custom validation error TODO
            return new HttpRequestMessage().CreateResponse(HttpStatusCode.InternalServerError);
        }

        // DELETE: api/Characters/5
        // DELETE in CRUD
        public async Task<HttpResponseMessage> Delete(int? id)
        {
            //Check if id is provided
            if (id == null)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            //Try to locate the specified character
            var character = await _character.FindAsync(x => x.CharacterId == id);

            //Check if the requested character exists
            if (character == null)
            {
                return new HttpRequestMessage().CreateResponse(HttpStatusCode.NotFound);
            }

            //Perform deletion if id is not null and the character does exist
            await _character.DeleteAsync(character);

            //When deletion was performed succesfully
            return new HttpRequestMessage().CreateResponse(HttpStatusCode.OK);
        }
    }
}
