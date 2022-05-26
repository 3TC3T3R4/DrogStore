using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DrogStore.Web.Models
{
    public class Medicamento
    {
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Cantidad { get; set; }

        public string Lote { get; set; }

        public string Descripcion { get; set; }

        public string Tipo { get; set; }

        public int CodigoTipo { get; set; }
        public ICollection<Proovedor> Proovedores { get; set; }
        [DisplayName("Proovedores Number")]
        public int ProovedoresNumber => Proovedores == null ? 0 : Proovedores.Count;

        [JsonIgnore] //lo ignora en la respuesta json
        [NotMapped] //no se crea en la base de datos
        public int IdLaboratorio { get; set; }




    }
}
