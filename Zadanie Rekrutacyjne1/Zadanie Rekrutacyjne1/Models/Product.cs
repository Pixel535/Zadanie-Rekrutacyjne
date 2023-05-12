using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Zadanie_Rekrutacyjne.Models
{
    public class Product
    {
        [Required]
        [XmlElement("ID")]
        public int ID { get; set; }
        [Required]
        [XmlElement("Name")]
        public string Name { get; set; }
        [Required]
        [XmlElement("Price")]
        public int Price { get; set; }
    }
}