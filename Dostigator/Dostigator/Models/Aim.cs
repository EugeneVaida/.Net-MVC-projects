using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dostigator.Models
{
    public class Aim
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string Date { get; set; }
        public string Img { get; set; }
        public string Group { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }
    }
}