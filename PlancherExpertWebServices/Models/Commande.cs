using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Build.Framework;

namespace PlancherExpertWebServices.Models
{
    public class Commande
    {
        [Key]
        public Guid CommandeId { get; set; }

        public double Largeur { get; set; }

        public double Longueur { get; set; }
        public string ClientData { get; set; }
        [ForeignKey("CouvrePlancher")]
        public int Id { get; set; }
        public CouvrePlancher CP { get; set; }
       

        public Commande() {
            ClientData = "";
            CP= new CouvrePlancher();
        }




    }
}
