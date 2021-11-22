using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Nome")]
        public string NOME { get; set; }
        [Required]
        [DisplayName("Sexo")]
        public string SEXO { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Data de Registro")]
        public DateTime DATA { get; set; }
        [Required]
        [DisplayName("Cidade")]
        public string CIDADE { get; set; }
        [Required]
        [DisplayName("Código de Contato")]
        [MinLength(4), MaxLength(4)]
        public string CODCONTATO { get; set; }
        
        
        
        


    }
}