using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using app.Models;

namespace app.Services
{   
    public class ContactRepository

    {
        private const string CacheKey = "ContactStore";
        public Contact[] GetAllContacts()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                return (Contact[])ctx.Cache[CacheKey];
            }

            return new Contact[]
        {
            new Contact
            {
                Id = 0,
                Name = "Placeholder"
            }
        };
        }

        public ContactRepository()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                if (ctx.Cache[CacheKey] == null)
                {
                    var contacts = new Contact[]
            {
                new Contact
                {
                    Id = 1, Name = "Glenn Block"
                },
                new Contact
                {
                    Id = 2, Name = "Dan Roth"
                }
            };

                    ctx.Cache[CacheKey] = contacts;
                }
            }
        }

    }

}