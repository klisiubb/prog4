using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4_MVVM.Model
{
    [Table("Albums")]
    public class Album
    {

        [Key]
        public int AlbumID { get; set; }

        [Required]
        public string AlbumTitle { get; set; } 

        [Required]
        public DateTime RelaseDate { get; set; }

        [Required]
        public string CoverArtLink { get; set; }

        public int ArtistID { get; set; }
        public Artist Artist { get; set; }

        public List<Song> Songs { get; set; }
    }
}