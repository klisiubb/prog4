using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4_MVVM.Model
{
    [Table("Artists")]
    public class Artist
    {

        [Key]
        public int ArtistID { get; set; }

        [Required]
        public string ArtistName { get; set; }

        [Required]
        public string ShortDescription { get; set; }

        [Required]
        public string CountryOfOrgin { get; set; }

        [Required]
        public string ArtistPhotoLink { get; set; }

        [Required]
        public string Genre { get; set; }
        public List<Album> Albums { get; set; }
    }
}
