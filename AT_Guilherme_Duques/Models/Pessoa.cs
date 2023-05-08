using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AT_Guilherme_Duques.Models
{
    public class Pessoa
    {
        public int iD { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }

        [DataType(DataType.Date)]

        public DateTime DataPessoa { get; set; }


    }
}
