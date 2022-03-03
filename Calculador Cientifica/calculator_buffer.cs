using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
//using System.Math;// Math matematica = new Math();


namespace Calculador_Cientifica
{
    class calculator_buffer
    {
        //obs: fazer operação reversa: somar, multiplicar antes de mostrar no textBox
        //se o textBox for vazio, somar ou multiplicar por 0(zero) ou 1(dependendo da operação) e exibir no textBox
        //sempre que uma soma ou multiplicação for clicada, o last operation vira nulo
        //ir concatenando quaisquer numero digitado ao lastOperation até que alguma operação seja clicada
        //não será possivel apagar o sinal da operação colocado

        public string textBox{ get; set;}//must read outside
        public string lastOperation{ get; set;}
        public string lastOperationSign { get; set; }
        public string hasMemory { get; set; }//must read outside
        public Double memoria { get; set; }

        public calculator_buffer()
        {
            textBox = String.Empty;
            lastOperation = String.Empty;
            lastOperationSign = String.Empty;
        }

        public void apagar_ultima_operacao(){
            /* ... codigo para apagar ultima operacao do textBox ...*/
            if (this.lastOperationSign == String.Empty)
            {
                textBox = String.Empty;
                lastOperation = String.Empty;
            }
            else
            {
                if (textBox != String.Empty && lastOperation != String.Empty)
                {
                    if (textBox.Length != lastOperation.Length)
                    {
                        textBox = textBox.Remove(textBox.Length - (lastOperation.Length));
                    }
                    else
                        textBox = String.Empty;
                    this.lastOperation = String.Empty;
                }
            }
        }

        public void apagar_toda_operacao()
        {
            this.textBox = String.Empty;
            this.lastOperation = String.Empty;
            this.lastOperationSign = String.Empty;
        }

        public void adicionar_num(Double number)
        {//?implementar mais codigos?
         //se o resultado for diferente de zero E não houver sinal operação aritmetica, concatenar esse valor ao número passado por parametro aqui
            this.textBox += number.ToString();
            this.lastOperation += number.ToString();
        }

        public void limpar_buffer_lastOperationSignSP()
        {
            this.lastOperationSign = String.Empty;
            this.lastOperation = String.Empty;
        }

        public void fazer_operacao(String tipo_operacao)
        {
            if (this.textBox != String.Empty)
            {
                this.textBox += tipo_operacao;
                this.lastOperationSign = tipo_operacao;
                this.lastOperation = String.Empty;
            }
        }

        public void exibir_resultado(Double resultado)
        {
            if (resultado == 666)
            {
                MediaPlayer.MediaPlayer winmp = new MediaPlayer.MediaPlayer();
                winmp.FileName = @"123.mid";
                winmp.Open(winmp.FileName);
                winmp.Play();
                
                //SoundPlayer mp = new SoundPlayer(@"C:\Users\srmf32\Documents\Visual Studio 2013\Projects\Calculador Cientifica\Lavender_Town.wav");
                //mp.Play();
            }
            this.textBox = resultado.ToString();
        }

        public void soma_memoria(Double num)
        {
            memoria += num;
            if (memoria != 0)
                this.hasMemory = "M";
            else
                this.hasMemory = String.Empty;
        }

        public void subtrair_memoria(Double num)
        {
            memoria -= num;
            if (memoria != 0)
                this.hasMemory = "M";
            else
                this.hasMemory = String.Empty;
        }

        public void salvar_memoria(Double num)
        {
            memoria = num;
            if (memoria != 0)
                this.hasMemory = "M";
            else
                this.hasMemory = String.Empty;
        }

        public String ler_memoria()
        {
            String str = String.Empty;
            if (memoria != 0)
            {
                str = memoria.ToString();
            }
            return str;
        }

        public void limpar_memoria()
        {
            memoria = 0;
            this.hasMemory = String.Empty;
        }

        
    }
}
