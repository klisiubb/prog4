using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4_MVVM.Model
{
    [Table("Songs")]
    public class Song
    {
        [Key]
        public int SongID { get; set; }

        [Required]
        public string SongName { get; set; }

        [Required]
        public string SongDuration { get; set; }

        [Required]
        public string SongLink { get; set; }
        public int AlbumID { get; set; }
        public Album Album { get; set; }
    }
}
