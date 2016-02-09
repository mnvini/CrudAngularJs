

using System.ComponentModel.DataAnnotations;

namespace Angular.App.Data.EntityConfig
{
    public class CelularModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Preencha o campo Marca")]
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public string TipoChip { get; set; }
        public string MemoriaInterna { get; set; }

    }
}
