using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DrogStore.Web.Models
{
    public class Laboratorio
    {

        //[Required]
        //[MaxLength(50)]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Nit { get; set; }

        public string Ubicacion { get; set; }

        public string Tipo { get; set; }

        public ICollection<Medicamento> Medicamentos { get; set; }
        [DisplayName("Medicamentos Number")]
        public int MedicamentosNumber => Medicamentos == null ? 0 : Medicamentos.Count;
    }



}




