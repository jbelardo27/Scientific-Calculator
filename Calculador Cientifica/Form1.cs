using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calculador_Cientifica;

namespace Calculador_Cientifica
{
    public partial class Form1 : Form
    {
        calculator_camada calculadora;

        public Form1()
        {
            InitializeComponent();
            calculadora = new calculator_camada();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            calculadora.adicionar_num(8);
            textBox1.Text = calculadora.stream.textBox;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            calculadora.adicionar_num(0);
            textBox1.Text = calculadora.stream.textBox;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            calculadora.apagar_ultima_operacao();
            textBox1.Text = calculadora.stream.textBox;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            calculadora.adicionar_num(1);
            textBox1.Text = calculadora.stream.textBox;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            calculadora.adicionar_num(2);
            textBox1.Text = calculadora.stream.textBox;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            calculadora.adicionar_num(3);
            textBox1.Text = calculadora.stream.textBox;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            calculadora.adicionar_num(4);
            textBox1.Text = calculadora.stream.textBox;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            calculadora.adicionar_num(5);
            textBox1.Text = calculadora.stream.textBox;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            calculadora.adicionar_num(6);
            textBox1.Text = calculadora.stream.textBox;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            calculadora.adicionar_num(7);
            textBox1.Text = calculadora.stream.textBox;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            calculadora.adicionar_num(9);
            textBox1.Text = calculadora.stream.textBox;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            calculadora.soma();
            textBox1.Text = calculadora.stream.textBox;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            calculadora.subtracao();
            textBox1.Text = calculadora.stream.textBox;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            calculadora.multiplicacao();
            textBox1.Text = calculadora.stream.textBox;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            calculadora.divisao();
            textBox1.Text = calculadora.stream.textBox;
        }

        private void button30_Click(object sender, EventArgs e)
        {
            calculadora.exibir_resultado();
            textBox1.Text = calculadora.stream.textBox;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            calculadora.apagar_toda_operacao();
            textBox1.Text = calculadora.stream.textBox;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            calculadora.inverter_sinal();
            textBox1.Text = calculadora.stream.textBox;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            calculadora.apagar_unidade(); 
            textBox1.Text = calculadora.stream.textBox;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            calculadora.adicionar_virgula();
            textBox1.Text = calculadora.stream.textBox;
        }

        private void button21_Click_1(object sender, EventArgs e)
        {
            calculadora.expoente();
            textBox1.Text = calculadora.stream.textBox;
        }

        private void button28_Click(object sender, EventArgs e)
        {
            calculadora.resto_divisao();
            textBox1.Text = calculadora.stream.textBox;
        }

        private void button43_Click(object sender, EventArgs e)
        {
            calculadora.calcular_porcentagem();
            textBox1.Text = calculadora.stream.textBox;
        }

        private void button25_Click(object sender, EventArgs e)
        {
            calculadora.divisao_um_por_x();
            textBox1.Text = calculadora.stream.textBox;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            calculadora.subtrair_memoria();
            memIndicator.Text = calculadora.stream.hasMemory;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            calculadora.somar_memoria();
            memIndicator.Text = calculadora.stream.hasMemory;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            calculadora.salvar_memoria();
            memIndicator.Text = calculadora.stream.hasMemory;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            calculadora.ler_memoria();
            textBox1.Text = calculadora.stream.textBox;
            memIndicator.Text = calculadora.stream.hasMemory;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            calculadora.limpar_memoria();
            memIndicator.Text = calculadora.stream.hasMemory;
        }

        private void button26_Click(object sender, EventArgs e)
        {
            String str = "Radians";
            if (Radians.Checked)
                str = "Radians";
            else if (Grads.Checked)
                str = "Grads";
            else if (Degrees.Checked)
                str = "Degrees";

            calculadora.calcular_seno(str);
            textBox1.Text = calculadora.stream.textBox;
        }

        private void button27_Click(object sender, EventArgs e)
        {
            String str = "Radians";
            if (Radians.Checked)
                str = "Radians";
            else if (Grads.Checked)
                str = "Grads";
            else if (Degrees.Checked)
                str = "Degrees";

            calculadora.calcular_coseno(str);
            textBox1.Text = calculadora.stream.textBox;
        }

        private void button31_Click(object sender, EventArgs e)
        {
            String str = "Radians";
            if (Radians.Checked)
                str = "Radians";
            else if (Grads.Checked)
                str = "Grads";
            else if (Degrees.Checked)
                str = "Degrees";

            calculadora.calcular_tangente(str);
            textBox1.Text = calculadora.stream.textBox;
        }

        private void button36_Click(object sender, EventArgs e)
        {
            String str = "Radians";
            if (Radians.Checked)
                str = "Radians";
            else if (Grads.Checked)
                str = "Grads";
            else if (Degrees.Checked)
                str = "Degrees";

            calculadora.calcular_senoh(str);
            textBox1.Text = calculadora.stream.textBox;
        }

        private void button37_Click(object sender, EventArgs e)
        {
            String str = "Radians";
            if (Radians.Checked)
                str = "Radians";
            else if (Grads.Checked)
                str = "Grads";
            else if (Degrees.Checked)
                str = "Degrees";

            calculadora.calcular_cosenoh(str);
            textBox1.Text = calculadora.stream.textBox;
        }

        private void button38_Click(object sender, EventArgs e)
        {
            String str = "Radians";
            if (Radians.Checked)
                str = "Radians";
            else if (Grads.Checked)
                str = "Grads";
            else if (Degrees.Checked)
                str = "Degrees";

            calculadora.calcular_tangenteh(str);
            textBox1.Text = calculadora.stream.textBox;
        }

        private void button29_Click(object sender, EventArgs e)
        {
            calculadora.calcular_raiz_quadrada();
            textBox1.Text = calculadora.stream.textBox;
        }

        private void button34_Click(object sender, EventArgs e)
        {
            calculadora.obter_PI();
            textBox1.Text = calculadora.stream.textBox;
        }

        private void button35_Click(object sender, EventArgs e)
        {
            calculadora.calcular_INT();
            textBox1.Text = calculadora.stream.textBox;
        }

        private void button33_Click(object sender, EventArgs e)
        {
            calculadora.calcular_logaritmo();
            textBox1.Text = calculadora.stream.textBox;
        }

        private void button42_Click(object sender, EventArgs e)
        {
            calculadora.calcular_fatorial();
            textBox1.Text = calculadora.stream.textBox;
        }


    }
}
