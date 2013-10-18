using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OmegaSoftware_Adresar_kontakata.Models
{
    public class Contact
    { 
        // Contact implementation
        public Contact()
        {
            this.Numbers = new HashSet<ContactNumber>();
        }

        [ScaffoldColumn(false)]
        public int ContactID { get; set; }

        [Required, StringLength(20), Display(Name = "Ime")]
        public string FirstName { get; set; }

        [Required, StringLength(20), Display(Name = "Prezime")]
        public string SecondName { get; set; }

        [Required, StringLength(20), Display(Name = "Grad")]
        public string City { get; set; }

        [Display(Name = "Opis")]
        public string Description { get; set; }

        public virtual ICollection<ContactNumber> Numbers { get; set; }

        internal void CreatePhoneNumbers(int count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                Numbers.Add(new ContactNumber());
            }
        }

        /*public string GetPhones()
        {
            string s = "";
            foreach (ContactNumber cn in Numbers)
            {
                s += cn.Number + ",";
            }
            s = s.Remove(s.Length - 1);
            return s;
        }*/
    }
}