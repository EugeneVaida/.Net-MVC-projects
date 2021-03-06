﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Dostigator.Models
{
    public class Aim
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Text { get; set; }

        [Required]
        public string PreviewText { get; set; }

        public string StartDate { get; set; }

        [Required]
        public string FinishDate { get; set; }
        
        public byte[] Img { get; set; }

        [Required]
        public string Group { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }

        public ICollection<TimeLine> TimeLines { get; set; }
        public Aim()
        {            
            TimeLines = new List<TimeLine>();
        }
    }
}