using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAtendimento
{
    internal class Guiche
    {
        public int Id { get; set; }
        public List<Senha> Atendimentos { get; private set; }

        public Guiche(int id)
        {
            Id = id;
            Atendimentos = new List<Senha>(); // Inicializa a lista de atendimentos
        }


        public bool Chamar(Queue<Senha> filaSenhas)
        {
            // Verifica se a fila contém senhas
            if (filaSenhas != null && filaSenhas.Count > 0)
            {
                // Remove a primeira senha da fila
                Senha senhaAtendida = filaSenhas.Dequeue();

                // Adiciona a senha removida à lista de atendimentos deste guichê
                if (senhaAtendida != null)
                {
                    this.Atendimentos.Add(senhaAtendida);
                    return true; // Indica que uma senha foi atendida
                }
            }
            return false; // Retorna false se não há senhas na fila
        }


        // Método para retornar os atendimentos
        public IEnumerable<Senha> ObterAtendimentos()
        {
            return Atendimentos;
        }
    }
}
