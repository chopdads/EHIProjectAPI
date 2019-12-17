using ContactAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;

namespace ContactAPI.Controllers
{
    [RoutePrefix("api/Contact")]
    public class ContactController : ApiController
    {
        [Route("GetContact")]
        [HttpGet]
        public HttpResponseMessage GetDetails()
        {
            try
            {
                using (ContactDBContext dbContext = new ContactDBContext())
                {
                    var Employees = dbContext.Contacts.ToList();
                    return Request.CreateResponse(HttpStatusCode.OK, Employees);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                //Logging mechanism
                //Console.WriteLine("Some Error has occured: " + ex.Message);
                //throw;
            }
        }

        [Route("GetContact/{id}")]
        [HttpGet]
        public HttpResponseMessage GetDetailsById(int id)
        {
            try
            {
                using (ContactDBContext dbContext = new ContactDBContext())
                {
                    var entity = dbContext.Contacts.FirstOrDefault(e => e.ContactId == id);
                    if (entity != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "Contact with ID " + id.ToString() + " not found");
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                //Logging mechanism
                //Console.WriteLine("Some Error has occured: " + ex.Message);
                //throw;
            }
        }

        [Route("CreateContact")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody] Contact contact)
        {
            try
            {
                using (ContactDBContext dbContext = new ContactDBContext())
                {
                    dbContext.Contacts.Add(contact);
                    dbContext.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, contact);
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                //Logging mechanism
            }
        }

        [Route("UpdateContact/{id}")]
        [HttpPut]
        public HttpResponseMessage Put(int id, [FromBody]Contact contact)
        {
            try
            {
                using (ContactDBContext dbContext = new ContactDBContext())
                {
                    var entity = dbContext.Contacts.FirstOrDefault(e => e.ContactId == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "Contact with Id " + id.ToString() + " not found to update");
                    }
                    else
                    {
                        entity.FirstName = contact.FirstName;
                        entity.LastName = contact.LastName;
                        entity.Email = contact.Email;
                        entity.Phone = contact.Phone;
                        entity.Status = contact.Status;
                        dbContext.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                //Logging mechanism
            }
        }

        [Route("DeleteContact/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (ContactDBContext dbContext = new ContactDBContext())
                {
                    var entity = dbContext.Contacts.FirstOrDefault(e => e.ContactId == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "Contact with Id = " + id.ToString() + " not found to delete");
                    }
                    else
                    {
                        dbContext.Contacts.Remove(entity);
                        dbContext.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                //Logging mechanism
            }
        }
    }
}
