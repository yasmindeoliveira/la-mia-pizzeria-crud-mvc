using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaMiaPizzeriaEfPost.Models
{
    public class Pizza
    {
  
        [Key]
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string nome { get; set; }

        [Url]
        [Required]
        [Column(TypeName = "varchar(300)")]
        public string foto { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string descrizione { get; set; }

        [Required]
        [Range(0,15000)]
        public double prezzo { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }


        public List<Ingredient>? Ingredients { get; set; }
        
        public Pizza()
        {

        }
        public Pizza(string nome, string foto, string descrizione, double prezzo)
        {
            this.nome = nome;
            this.foto = foto;
            this.descrizione = descrizione;
            this.prezzo = prezzo;
        }
    }
}
