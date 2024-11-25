using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAtendimento
{
    internal class Guiches
    {
        private List<Guiche> listaGuiches;

        public Guiches()
        {
            this.listaGuiches = new List<Guiche>();
        }

        public void Adicionar(Guiche guiche)
        {
            listaGuiches.Add(guiche);
        }

        public List<Guiche> ObterLista()
        {
            return listaGuiches;
        }
    }
}
