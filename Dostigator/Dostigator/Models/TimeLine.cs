using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Dostigator.Models
{
    public class TimeLine
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Text { get; set; }

        [Required]
        public string PreviewText { get; set; }

        [Required]
        public string Date { get; set; }

        public int? AimId { get; set; }
        public Aim Aim { get; set; }
    }
}