using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAtendimento
{
    internal class Senha
    {
        private int id;
        private DateTime dataGerac;
        private DateTime horaGerac;
        private DateTime? dataAtend;
        private DateTime? horaAtend;

        public Senha(int id)
        {
            this.id = id;
            this.dataGerac = DateTime.Now.Date;
            this.horaGerac = DateTime.Now;
        }

        public string DadosParciais()
        {
            return $"{id} - {dataGerac.ToShortDateString()} - {horaGerac.ToShortTimeString()}";
        }

        public string DadosCompletos()
        {
            return $"{id} - {dataGerac.ToShortDateString()} - {horaGerac.ToShortTimeString()} - " +
                   $"{(dataAtend.HasValue ? dataAtend.Value.ToShortDateString() : "N/A")} - " +
                   $"{(horaAtend.HasValue ? horaAtend.Value.ToShortTimeString() : "N/A")}";
        }

        public void RegistrarAtendimento()
        {
            this.dataAtend = DateTime.Now.Date;
            this.horaAtend = DateTime.Now;
        }
    }
}
