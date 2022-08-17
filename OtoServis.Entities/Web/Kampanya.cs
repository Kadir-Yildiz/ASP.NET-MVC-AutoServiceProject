using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServis.Entities.Web
{
    public class Kampanya
    {
        [Key]
        public int KampanyaId { get; set; }
        public string Icerik { get; set; }
    }
}
