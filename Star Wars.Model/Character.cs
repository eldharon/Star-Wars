﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Star_Wars.Model
{
    
    public class Character
    {
        public Character()
        {
            Episodes = new HashSet<Episode>();
            Friends = new HashSet<Character>();
        }
        public int CharacterId { get; set; }
        [Required(ErrorMessage = "Please fill in the name")]
        public string Name { get; set; }
        public string Planet { get; set; }        
        public ICollection<Character> Friends { get; set; }
        public ICollection<Episode> Episodes { get; set; }
    }
}
