using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using OmegaSoftware_Adresar_kontakata.Models;

namespace OmegaSoftware_Adresar_kontakata.Models
{
    public class AdresarContext : DbContext
    {
        public AdresarContext() : base("OmegaSoftware-Adresar_kontakata") 
        {
            Database.SetInitializer<AdresarContext>(null);
        }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactNumber> ContactNumbers { get; set; }
    }
}