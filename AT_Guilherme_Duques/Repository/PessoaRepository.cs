using AT_Guilherme_Duques.Data;
using AT_Guilherme_Duques.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AT_Guilherme_Duques.Repository
{
    public class PessoaRepository
    {
        public static Pessoa Index(AT_Guilherme_DuquesContext _context)
        {
            var Pessoas = from f in _context.Pessoa select f;

            return (Pessoa)Pessoas;
        }

        // GET: Pessoas/Details/5
        public static Pessoa Details(int? id, AT_Guilherme_DuquesContext _context)
        {

            var Pessoa = _context.Pessoa.FirstOrDefault(m => m.iD == id);

            return Pessoa;
        }

        public static Pessoa Edit(int? id, AT_Guilherme_DuquesContext _context)
        {
            var Pessoa = _context.Pessoa.Find(id);

            return Pessoa;
        }

        public static Pessoa Delete(int? id, AT_Guilherme_DuquesContext _context)
        {
            var Pessoa = _context.Pessoa.FirstOrDefault(m => m.iD == id);

            return Pessoa;
        }
    }
}
