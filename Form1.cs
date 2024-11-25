using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjetoAtendimento
{
    public partial class Form1 : Form
    {
        private Senhas senhas;
        private Guiches guiches;


        public Form1()
        {
            InitializeComponent();
            senhas = new Senhas();
            guiches = new Guiches();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label2.Text = "0"; // Inicializa o label de guichês
        }


        // Botão Gerar Senha = button 1
        private void button1_Click(object sender, EventArgs e)
        {
            senhas.Gerar();
            AtualizarListaSenhas();
        }

        // Botão Listar Senhas = button 2
        private void button2_Click(object sender, EventArgs e)
        {
            AtualizarListaSenhas();
        }

        // Botão Adicionar Guichê = button 3
        private void button3_Click(object sender, EventArgs e)
        {
            // Obtém o próximo ID para o guichê
            int id = guiches.ObterLista().Count + 1;

            // Cria e adiciona um novo guichê à lista
            guiches.Adicionar(new Guiche(id));

            // Atualiza o rótulo de quantidade de guichês
            label2.Text = guiches.ObterLista().Count.ToString();

            MessageBox.Show($"Guichê {id} adicionado com sucesso!");
        }


        // Botão Chamar Senha = button 4
        private void button4_Click(object sender, EventArgs e)
        {
            // Verifica se o texto no textBox2 é um número válido para o ID do guichê
            if (int.TryParse(textBox1.Text, out int idGuiche))
            {
                // Procura o guichê com o ID correspondente
                var guiche = guiches.ObterLista().FirstOrDefault(g => g.Id == idGuiche);

                if (guiche != null)
                {
                    // Chama a senha do guichê
                    if (guiche.Chamar(senhas.ObterFila()))
                    {
                        // Atualiza as ListBox
                        AtualizarListaAtendimentos(guiche);
                        AtualizarListaSenhas();
                    }
                    else
                    {
                        // Caso não haja senhas na fila
                        MessageBox.Show("Nenhuma senha na fila.");
                    }
                }
                else
                {
                    // Caso o guichê com o ID fornecido não exista
                    MessageBox.Show("Guichê não encontrado.");
                }
            }
            else
            {
                // Caso o texto não seja um número válido
                MessageBox.Show("Informe um ID de guichê válido.");
            }
        }


        // Botão Listar Atendimentos = button 5
        private void button5_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int idGuiche)) // Pega o ID do guichê do TextBox
            {
                var guiche = guiches.ObterLista().FirstOrDefault(g => g.Id == idGuiche); // Encontra o guichê
                if (guiche != null)
                {
                    listBox2.Items.Clear(); // Limpa o ListBox antes de atualizar
                    foreach (var senha in guiche.ObterAtendimentos()) // Para cada atendimento no guichê
                    {
                        // Adiciona a senha e o guichê no ListBox
                        listBox2.Items.Add($"Senha: {senha.DadosParciais()} | Guichê: {guiche.Id}");
                    }
                }
                else
                {
                    MessageBox.Show("Guichê não encontrado.");
                }
            }
            else
            {
                MessageBox.Show("Informe um ID de guichê válido.");
            }
        }
        
        // Atualiza ListBox 1 (Lista de Senhas)
        private void AtualizarListaSenhas()
        {
            listBox1.Items.Clear(); // Limpa o ListBox antes de atualizar
            foreach (var senha in senhas.ObterFila())
            {
                listBox1.Items.Add(senha.DadosParciais());
            }
        }

        // Atualiza ListBox 2 (Lista de Atendimentos)
        private void AtualizarListaAtendimentos(Guiche guiche)
        {
            listBox2.Items.Clear(); // Limpa o ListBox antes de atualizar
            foreach (var senha in guiche.ObterAtendimentos())
            {
                listBox2.Items.Add(senha.DadosCompletos());
            }
        }

        // ListBox 1: Lista de Senhas
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        {
            listBox1.Items.Clear(); // Limpa o ListBox antes de atualizar
            foreach (var senha in senhas.ObterFila())
            {
                listBox1.Items.Add(senha.DadosParciais());
            }
        }
        }

        // ListBox 2: Lista de Atendimentos
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                listBox2.Items.Clear(); // Limpa a lista antes de atualizar

                // Verifica se o ID do guichê foi informado
                if (int.TryParse(label1.Text, out int idGuiche))
                {
                    // Busca o guichê pelo ID na lista de guichês
                    var guiche = guiches.ObterLista().FirstOrDefault(g => g.Id == idGuiche);

                    if (guiche != null) // Verifica se o guichê foi encontrado
                    {
                        // Preenche a ListBox2 com os atendimentos do guichê
                        foreach (var senha in guiche.ObterAtendimentos())
                        {
                            listBox2.Items.Add(senha.DadosCompletos());
                        }
                    }
                    else
                    {
                        MessageBox.Show("Guichê não encontrado.");
                    }
                }
                else
                {
                    MessageBox.Show("Informe um ID de guichê válido.");
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

