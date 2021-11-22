using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class RegistrodeCidades
    {
        //Não pertencem ao banco de dados
        [NotMapped]
        public string Cidade { get; set; }

        [NotMapped]
        [DisplayName("Mulheres") ]
        public List<int> MulheresMes { get; set; }

        [NotMapped]
        [DisplayName("Homens")]
        public List<int> HomensMes { get; set; }

        [NotMapped]
        [DisplayName("Total/Mês")]
        public List<int> TotalMes { get; set; }

        public int HomensTotal{ get; set; }

        public int MulheresTotal { get; set; }

        public int Total { get; set; }

        [NotMapped]
        public List<string> Meses { get; set; }

        [NotMapped]
        [DisplayName("Total")]
        public int TodosRegistrados { get; set; }

        [NotMapped]
        [DisplayName("Homens")]
        public int HomensRegistrados { get; set; }

        [NotMapped]
        [DisplayName("Mulheres")]
        public int MulheresRegistrados { get; set; }
        
        public string Filtro { get; set; }





    }
}