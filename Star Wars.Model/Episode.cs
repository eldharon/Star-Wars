using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Star_Wars.Model
{
    public class Episode
    {
        public Episode()
        {
            Characters = new HashSet<Character>();
        }

        [Key]
        [Required]
        public int EpisodeId { get; set; }
        [Required(ErrorMessage ="Please fill the name property")]
        public string Name { get; set; }
        public ICollection<Character> Characters { get; set; }

    }
}
