using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using Boonbook.Factories;
using Boonbook.Models;
using Boonbook.Models.Boons;

namespace Boonbook.Controllers
{
    [RoutePrefix("api/Boons")]
    public class BoonController : ApiController
    {
        private BoonbookContext db = new BoonbookContext();
        // GET api/Boons
        [HttpGet]
        [Route("")]
        [ResponseType(typeof (List<Boon>))]
        public IHttpActionResult GetBoons()
        {
            var boons = db.Boons
                .Include(b => b.Level)
                .Include(b => b.Creditor)
                .Include(b => b.Debtor)
                .Include(b => b.Registrar)
            .ToList();
            var output = boons.Select(ViewModelFactory.BoonSummary).ToList();

            return Ok(output);
        }

        // GET api/Boons/5
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof (Boon))]
        public IHttpActionResult GetBoon(int id)
        {
            var boon = db.Boons
                .Include(b => b.Level)
                .Include(b => b.Creditor)
                .Include(b => b.Debtor)
                .Include(b => b.Registrar)
            .SingleOrDefault(b => b.Id == id);

            if (boon == null)
                return NotFound();

            var output = ViewModelFactory.BoonDetail(boon);

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