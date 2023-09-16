using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.Models
{
    [Table("Kullanicilar")]
    public class Kullanici:BaseModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; } = false;

        public virtual ICollection<Yazar> Yazarlar { get; set; }= new List<Yazar>();
        public virtual ICollection<Kitap> Kitaplar { get; set; } = new List<Kitap>();
        public virtual ICollection<YayinEvi> YayinEvleri { get; set; } = new List<YayinEvi>();
    }
}
