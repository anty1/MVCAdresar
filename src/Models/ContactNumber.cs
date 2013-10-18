using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace OmegaSoftware_Adresar_kontakata.Models
{
    public class ContactNumber
    {
        public ContactNumber() 
        {
            this.DeletePhone = true;
        }

        public bool DeletePhone { get; set; }

        [ScaffoldColumn(false)]
        public int ContactNumberID { get; set; }

        [Required, StringLength(15), Display(Name = "Phone Number")]
        public string Number { get; set; }

        [Required, StringLength(20), Display(Name = "Number Type")]
        public int NumberTypeID { get; set; }

        public int ContactID { get; set; }

        //public virtual Contact Contact { get; set; }

        [StringLength(10000), Display(Name = "Number Description"), DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}

namespace System.Web.Mvc
{
    public class NumberType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public static class HtmlLists
    {
        public static IEnumerable<NumberType> NumberTypes = new List<NumberType> 
        { 
            new NumberType { Id = 1, Name = "Mobilni" },
            new NumberType { Id = 2, Name = "Fiksni" },
            new NumberType { Id = 3, Name = "Poslovni" },
            new NumberType { Id = 4, Name = "Drugi" }
        };
    }
}