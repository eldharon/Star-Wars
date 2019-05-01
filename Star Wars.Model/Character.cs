using System;
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
        }
        [Key]
        [Required]
        public int CharacterId { get; set; }
        [Required(ErrorMessage = "Please fill the name property")]
        public string Name { get; set; }

        public string Planet { get; set; }
        
        public int? FriendId { get; set; }
        [ForeignKey("FriendId")]
        public List<Character> Friends { get; set; }
        public ICollection<Episode> Episodes { get; set; }


    }
}
