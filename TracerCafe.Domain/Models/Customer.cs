using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracerCafe.Domain.Models
{
    /// <summary>
    /// Entity that contains the person information
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Identifier
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Title of the person
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// First name of the person
        /// </summary>
        public string Firstname { get; set; }

        /// <summary>
        /// Surname of the person
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Post code of the person
        /// </summary>
        public string PostCode { get; set; }

        /// <summary>
        /// Telephone number
        /// </summary>
        public string Telephone { get; set; }

        /// <summary>
        /// Age of the person
        /// </summary>
        public int Age { get; set; }
        
        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Address3 { get; set; }

        public string Address4 { get; set; }
    }
}
