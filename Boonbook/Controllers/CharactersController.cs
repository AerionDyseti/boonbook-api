using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using Boonbook.Factories;
using Boonbook.Models;
using Boonbook.Models.Characters;
using Boonbook.Models.Characters.ViewModels;

namespace Boonbook.Controllers
{
    [RoutePrefix("api/Characters")]
    public class CharactersController : ApiController
    {
        private BoonbookContext db = new BoonbookContext();
        // GET: api/Characters
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(List<CharacterSummaryViewModel>))]
        public IHttpActionResult GetCharacters()
        {
            var characters = db.Characters
                .Include(c => c.Clan)
                .Include(c => c.Sect)
                .Include(c => c.SocialClass)
                .ToList();
            var output = characters.Select(ViewModelFactory.CharacterSummary).ToList();

            return Ok(output);
        }

        // GET: api/Characters/5
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(CharacterDetailViewModel))]
        public IHttpActionResult GetCharacter(int id)
        {
            var character = db.Characters
                .Include(c => c.Player)
                .Include(c => c.Clan)
                .Include(c => c.Sect)
                .Include(c => c.SocialClass)
                .SingleOrDefault(c => c.Id == id);

            if (character == null)
                return NotFound();

            var output = ViewModelFactory.CharacterDetail(character);

            return Ok(output);
        }

        #region Helper Methods

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion
    }
}