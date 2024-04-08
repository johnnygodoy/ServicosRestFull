using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;
using TelaVinho.Models;

namespace TelaVinho
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string URI;
        private void Form1_Load(object sender, EventArgs e)
        {
            this.URI = "https://localhost:7215/api/vinhos";
        }

        private async Task GetAllVinhos()
        {
            using (var Client = new HttpClient())
            {

                using (var response = await Client.GetAsync(this.URI))
                {

                    if (response.IsSuccessStatusCode)
                    {
                        var vinhosJsonString = await response.Content.ReadAsStringAsync();
                        this.dataGridView1.DataSource = JsonConvert.DeserializeObject<Vinhos[]>(vinhosJsonString).ToList();

                    }
                    else
                    {
                        MessageBox.Show("Falha na comunicação: " + response.StatusCode);
                    }
                }
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await this.GetAllVinhos();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            await this.AddVinho();
        }

        private async Task AddVinho()
        {
            Vinhos vinho = new Vinhos();
            vinho.Nome_vinho = this.txtNome.Text;
            vinho.Idade_vinho = Convert.ToInt32(this.txtIdade.Text);
            vinho.Preco_vinho = Convert.ToDecimal(this.txtPreco.Text);

            using (var client = new HttpClient())
            {
                var vinhoJson = JsonConvert.SerializeObject(vinho);
                var content = new StringContent(vinhoJson, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(this.URI, content);
            }

            await this.GetAllVinhos();
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            await Updatevinho();
        }

        private async Task Updatevinho()
        {
            Vinhos vinho = new Vinhos();
            vinho.Cod_vinho = Convert.ToInt32(this.txtCod.Text);
            vinho.Nome_vinho = this.txtNome.Text;
            vinho.Idade_vinho = Convert.ToInt32(this.txtIdade.Text);
            vinho.Preco_vinho = Convert.ToDecimal(this.txtPreco.Text);

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.PutAsJsonAsync(this.URI + "/" + vinho.Cod_vinho, vinho);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("vinho atualizado!");
                    await GetAllVinhos();
                }
                else
                {
                    MessageBox.Show("Falha na atualização:" + response.StatusCode);
                }
            }
        }

        private async Task RemoveVinho()
        {
            int cod_vinho = Convert.ToInt32(this.txtCod.Text);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.URI);
                HttpResponseMessage response = await client.DeleteAsync(string.Format("{0}/{1}", client.BaseAddress, cod_vinho));

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("vinho Removido!");
                    await GetAllVinhos();
                }
                else
                {
                    MessageBox.Show("Falha na remoção:" + response.StatusCode);
                }
            }
        }

        private async Task getVinhoById(int id)
        {
            using (var client = new HttpClient())
            {
                BindingSource bsDados = new BindingSource();
                string endereco = this.URI + "/" + id.ToString();
                HttpResponseMessage response = await client.GetAsync(endereco);

                if (response.IsSuccessStatusCode)
                {
                    var vinhojson = await response.Content.ReadAsStringAsync();

                    bsDados.DataSource = JsonConvert.DeserializeObject<Vinhos>(vinhojson);
                    this.dataGridView1.DataSource = bsDados;
                }
                else
                {
                    MessageBox.Show("Falha na atualização:" + response.StatusCode);
                }
            }
        }

        private async void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            txtCod.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtIdade.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtPreco.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }


        private async void button5_Click_1(object sender, EventArgs e)
        {
            await this.RemoveVinho();
        }       

        private async void button2_Click_1(object sender, EventArgs e)
        {
            await this.getVinhoById(int.Parse(this.txtCod.Text));
        }
    }
}
