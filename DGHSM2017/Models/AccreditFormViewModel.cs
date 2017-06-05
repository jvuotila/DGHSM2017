using System.ComponentModel.DataAnnotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using System.Web.Script.Serialization;

namespace DGHSM2017.Models
{
    public class AccreditFormViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        [Display(Name = "Etunimi *")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        [Display(Name = "Sukunimi *")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Anna validi sähköpostiosoite")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Sähköposti *")]
        //[StringLength(50, MinimumLength = 3)]
        public string EmailAddress { get; set; }
        
        [Required]
        [StringLength(100, MinimumLength = 2)]
        [Display(Name = "Mediatalo *")]
        public string Media { get; set; }

        [Required]
        //[DataType(DataType.PhoneNumber)]
        [StringLength(20, MinimumLength = 6)]
        [Display(Name = "Puhelinnumero *")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Videointi")]
        public bool Video { get; set; }

        [Display(Name = "Valokuvaus")]
        public bool Photography { get; set; }

        [Display(Name = "Haastattelu")]
        public bool Interview { get; set; }

        [Display(Name = "Torstai")]
        public bool Day1 { get; set; }

        [Display(Name = "Perjantai")]
        public bool Day2 { get; set; }

        [Display(Name = "Lauantai")]
        public bool Day3 { get; set; }

        [Display(Name = "Sunnuntai")]
        public bool Day4 { get; set; }
        
        [StringLength(5000, MinimumLength = 2)]
        [Display(Name = "Muuta")]
        public string FreeMessage { get; set; }

        [Required]
        [Range(14, 14, ErrorMessage = "Vastaus ei ole oikein.")]
        [Display(Name = "Paljonko on 10 + 4? *")]
        public decimal checkCode { get; set; }
    }
}