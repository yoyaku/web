using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using web.Models;

namespace web.Controllers
{
    public class BookingController : RavenDbController
    {
        // GET api/booking
        public IEnumerable<Booking> Get()
        {
            return Session.Query<Booking>();
        }

        // GET api/booking/5
        public Booking Get(string id)
        {
            return Session.Query<Booking>().Single(x => x.Id == id);
        }

        // POST api/booking
        public async Task<HttpResponseMessage> Post([FromBody]Booking booking)
        {
            if (ModelState.IsValid)
            {
                await Session.StoreAsync(booking);
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            throw new HttpResponseException(HttpStatusCode.BadRequest);
        }

        // PUT api/booking/5
        public async Task<HttpResponseMessage> Put([FromBody]Booking booking)
        {
            if (ModelState.IsValid)
            {
                await Session.StoreAsync(booking);
                return new HttpResponseMessage(HttpStatusCode.NoContent);
            }
            throw new HttpResponseException(HttpStatusCode.BadRequest);
        }

        // DELETE api/booking/5
        public async Task<HttpResponseMessage> Delete(string id)
        {
            var booking = Get(id);
            booking.Deleted = true;
            await Session.StoreAsync(booking);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
