using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculador_Cientifica;

namespace Calculador_Cientifica
{
    class calculator_camada
    {
        public calculator_buffer stream{ get; set; }
        private Double resultado;

        public calculator_camada()
        {
            stream = new calculator_buffer();
        }

        private void process_last_operation_simbol(Double num, String operation_simbol){
            if(operation_simbol.Equals("+")){
                this.resultado += num;
            }
            else if(operation_simbol.Equals("-")){
                this.resultado -= num;
            }
            else if(operation_simbol.Equals("/")){
                if(num!=0)
                    this.resultado /=num;
            }
            else if(operation_simbol.Equals("*")){
                this.resultado *=num;
            }
            else if(operation_simbol.Equals("%")){
                if(num!=0)
                    this.resultado %= num;
            }
            else if (operation_simbol.Equals("^"))
            {
                this.resultado = Math.Pow(num, this.resultado);
            }
        }

        public void soma(){
            if (stream.lastOperationSign == String.Empty)
            {
                if (stream.lastOperation != String.Empty)
                {
                    //se o sinal de operação aritmetica estiver vazio...
                    //...e houver uma operação númerica em transação...
                    //...somar o valor ao resultado.
                    process_last_operation_simbol(Double.Parse(stream.lastOperation), "+");
                    this.stream.fazer_operacao("+");
                    //o fluxo entra aqui se estiver tudo vazio
                }
                else
                {//o fluxo de execução só entra aqui caso o botão de igual tenha sido pressionado
                    this.stream.fazer_operacao("+");
                }
            }
            else
            { // caso haja um sinal de aritmetica, faça: execute a operação aritmetica, junto ao valor numerico em transação.
                if (stream.lastOperation != String.Empty)
                {
                    process_last_operation_simbol(Double.Parse(stream.lastOperation), stream.lastOperationSign);
                    this.stream.fazer_operacao("+");
                }
            }
        }

        public void subtracao()
        {
            if (stream.lastOperationSign == String.Empty)
            {
                if (stream.lastOperation != String.Empty)
                    process_last_operation_simbol(Double.Parse(stream.lastOperation), "+");
                this.stream.fazer_operacao("-");
            }
            else
            {
                if (stream.lastOperation != String.Empty)
                {
                    process_last_operation_simbol(Double.Parse(stream.lastOperation), stream.lastOperationSign);
                    this.stream.fazer_operacao("-");
                }
            }
        }

        public void multiplicacao()
        {
            if (stream.lastOperationSign == String.Empty)
            {
                if (stream.lastOperation != String.Empty)
                    process_last_operation_simbol(Double.Parse(stream.lastOperation), "+");
                this.stream.fazer_operacao("*");
            }
            else
            {
                if (stream.lastOperation != String.Empty)
                {
                    process_last_operation_simbol(Double.Parse(stream.lastOperation), stream.lastOperationSign);
                    this.stream.fazer_operacao("*");
                }
            }
        }

        public String divisao()//retorna uma string vazia quando não há erro
        {
            String str = String.Empty;
            if(stream.lastOperationSign == String.Empty)
            {
                if(stream.lastOperation != String.Empty)
                    process_last_operation_simbol(Double.Parse(stream.lastOperation), "+");
                this.stream.fazer_operacao("/");
            }
            else
            {
                if (stream.lastOperation != String.Empty)
                {
                    Double num = Double.Parse(stream.lastOperation);
                    if (num == 0)
                    {
                        str = "Impossivel divisão por zero!";
                    }
                    else
                    {
                        process_last_operation_simbol(Double.Parse(stream.lastOperation), stream.lastOperationSign);
                        this.stream.fazer_operacao("/");
                    }
                }
            }
            return str;
        }

        public String resto_divisao()
        {
            String str = String.Empty;
            if (stream.lastOperationSign == String.Empty)
            {
                if(stream.lastOperation != String.Empty)
                    process_last_operation_simbol(Double.Parse(stream.lastOperation), "+");
                this.stream.fazer_operacao("%");
            }
            else
            {
                if (stream.lastOperation != String.Empty)
                {
                    Double num = Double.Parse(stream.lastOperation);
                    if (num == 0)
                    {
                        str = "Impossivel divisão por zero!";
                    }
                    else
                    {
                        process_last_operation_simbol(Double.Parse(stream.lastOperation), stream.lastOperationSign);
                        this.stream.fazer_operacao("%");
                    }
                }
            }
            return str;
        }

        public void expoente()
        {
            if (stream.lastOperationSign == String.Empty)
            {
                if (stream.lastOperation != String.Empty)
                {
                    process_last_operation_simbol(Double.Parse(stream.lastOperation), "+");
                }
                this.stream.fazer_operacao("^");
            }
            else
            {
                if (stream.lastOperation != String.Empty)
                {
                    process_last_operation_simbol(Double.Parse(stream.lastOperation), stream.lastOperationSign);
                    this.stream.fazer_operacao("^");
                }
            }
        }

        public String divisao_um_por_x()
        {
            Double num;
            String str = String.Empty;

            if (stream.lastOperationSign != String.Empty)
            {
                if (stream.lastOperation != String.Empty)
                {
                    num = Double.Parse(stream.lastOperation);
                    if (num == 0)
                    {
                        str = "Impossivel divisão por zero!";
                    }
                    else
                    {
                        num = 1 / num;
                        this.apagar_ultima_operacao();
                        stream.lastOperation = num.ToString();
                        stream.textBox += stream.lastOperation;
                    }
                }
            }
            else
            {
                if (resultado != 0)
                {
                    if (stream.textBox != String.Empty)
                    {
                        num = Double.Parse(stream.textBox);
                        if (num == 0)
                        {
                            str = "Impossivel divisão por zero!";
                        }
                        else
                        {
                            num = 1 / num;
                            this.apagar_ultima_operacao();
                            stream.textBox = num.ToString();
                            resultado = num;
                        }
                    }
                }
            }

            return str;
        }

        public void calcular_porcentagem()
        {
            Double num=0;
            if (stream.lastOperationSign != String.Empty) {
                if (stream.lastOperation != String.Empty)
                {
                    num = this.resultado * (Double.Parse(stream.lastOperation) / 100.0);
                    if (stream.textBox != String.Empty)
                    {
                        this.apagar_ultima_operacao();
                        stream.lastOperation = num.ToString();
                        stream.textBox += stream.lastOperation;
                    }
                    else
                    {
                        stream.lastOperation = num.ToString();
                        stream.textBox = stream.lastOperation;
                    }
                }
            }
            else
            { 
                if (stream.lastOperation == String.Empty)
                {
                    if (stream.textBox != String.Empty)
                    {
                        stream.lastOperation = "0";
                        resultado = 0;
                        stream.textBox = stream.lastOperation;
                    }
                }
            }
        }

        public void calcular_seno(String str)
        {
            Double num=0;
            if (stream.lastOperationSign != String.Empty)
            {
                if (stream.lastOperation != String.Empty)
                {
                    num = Double.Parse(stream.lastOperation);
                    num = Math.Sin(num);
                    if (str == "Grads")
                    {
                        num = num;
                    }
                    else if (str == "Degrees")
                    {
                        num = num;
                    }

                    if (stream.lastOperation != String.Empty)
                        this.apagar_ultima_operacao();
                    stream.lastOperation = num.ToString();
                    stream.textBox += stream.lastOperation;
                }
            }
            else
            {
                if (stream.textBox != String.Empty)
                {
                    num = Double.Parse(stream.textBox);
                    num = Math.Sin(num);
                    if (str == "Grads")
                    {
                        num = num;
                    }
                    else if (str == "Degrees")
                    {
                        num = num;
                    }

                    if (stream.textBox != String.Empty)
                        this.apagar_ultima_operacao();
                    stream.textBox = num.ToString();
                    resultado = num;
                }
            }
        }

        public void calcular_senoh(String str)
        {
            Double num = 0;
            if (stream.lastOperationSign != String.Empty)
            {
                if (stream.lastOperation != String.Empty)
                {
                    num = Double.Parse(stream.lastOperation);
                    num = Math.Sinh(num);
                    if (str == "Grads")
                    {
                        num = num;
                    }
                    else if (str == "Degrees")
                    {
                        num = num;
                    }

                    if (stream.lastOperation != String.Empty)
                        this.apagar_ultima_operacao();
                    stream.lastOperation = num.ToString();
                    stream.textBox += stream.lastOperation;
                }
            }
            else
            {
                if (stream.textBox != String.Empty)
                {
                    num = Double.Parse(stream.textBox);
                    num = Math.Sinh(num);
                    if (str == "Grads")
                    {
                        num = num;
                    }
                    else if (str == "Degrees")
                    {
                        num = num;
                    }

                    if (stream.textBox != String.Empty)
                        this.apagar_ultima_operacao();
                    stream.textBox = num.ToString();
                    resultado = num;
                }
            }
        }

        public void calcular_coseno(String str)
        {
            Double num = 0;
            if (stream.lastOperationSign != String.Empty)
            {
                if (stream.lastOperation != String.Empty)
                {
                    num = Double.Parse(stream.lastOperation);
                    num = Math.Cos(num);
                    if (str == "Grads")
                    {
                        num = num;
                    }
                    else if (str == "Degrees")
                    {
                        num = num;
                    }

                    if (stream.lastOperation != String.Empty)
                        this.apagar_ultima_operacao();
                    stream.lastOperation = num.ToString();
                    stream.textBox += stream.lastOperation;
                }
            }
            else
            {
                if (stream.textBox != String.Empty)
                {
                    num = Double.Parse(stream.textBox);
                    num = Math.Cos(num);
                    if (str == "Grads")
                    {
                        num = num;
                    }
                    else if (str == "Degrees")
                    {
                        num = num;
                    }

                    if (stream.textBox != String.Empty)
                        this.apagar_ultima_operacao();
                    stream.textBox = num.ToString();
                    resultado = num;
                }
            }
        }

        public void calcular_cosenoh(String str)
        {
            Double num = 0;
            if (stream.lastOperationSign != String.Empty)
            {
                if (stream.lastOperation != String.Empty)
                {
                    num = Double.Parse(stream.lastOperation);
                    num = Math.Cosh(num);
                    if (str == "Grads")
                    {
                        num = num;
                    }
                    else if (str == "Degrees")
                    {
                        num = num;
                    }

                    if (stream.lastOperation != String.Empty)
                        this.apagar_ultima_operacao();
                    stream.lastOperation = num.ToString();
                    stream.textBox += stream.lastOperation;
                }
            }
            else
            {
                if (stream.textBox != String.Empty)
                {
                    num = Double.Parse(stream.textBox);
                    num = Math.Cosh(num);
                    if (str == "Grads")
                    {
                        num = num;
                    }
                    else if (str == "Degrees")
                    {
                        num = num;
                    }

                    if (stream.textBox != String.Empty)
                        this.apagar_ultima_operacao();
                    stream.textBox = num.ToString();
                    resultado = num;
                }
            }
        }

        public void calcular_tangente(String str)
        {
            Double num = 0;
            if (stream.lastOperationSign != String.Empty)
            {
                if (stream.lastOperation != String.Empty)
                {
                    num = Double.Parse(stream.lastOperation);
                    num = Math.Tan(num);
                    if (str == "Grads")
                    {
                        num = num;
                    }
                    else if (str == "Degrees")
                    {
                        num = num;
                    }

                    if (stream.lastOperation != String.Empty)
                        this.apagar_ultima_operacao();
                    stream.lastOperation = num.ToString();
                    stream.textBox += stream.lastOperation;
                }
            }
            else
            {
                if (stream.textBox != String.Empty)
                {
                    num = Double.Parse(stream.textBox);
                    num = Math.Tan(num);
                    if (str == "Grads")
                    {
                        num = num;
                    }
                    else if (str == "Degrees")
                    {
                        num = num;
                    }

                    if (stream.textBox != String.Empty)
                        this.apagar_ultima_operacao();
                    stream.textBox = num.ToString();
                    resultado = num;
                }
            }
        }

        public void calcular_tangenteh(String str)
        {
            Double num = 0;
            if (stream.lastOperationSign != String.Empty)
            {
                if (stream.lastOperation != String.Empty)
                {
                    num = Double.Parse(stream.lastOperation);
                    num = Math.Tanh(num);
                    if (str == "Grads")
                    {
                        num = num;
                    }
                    else if (str == "Degrees")
                    {
                        num = num;
                    }

                    if (stream.lastOperation != String.Empty)
                        this.apagar_ultima_operacao();
                    stream.lastOperation = num.ToString();
                    stream.textBox += stream.lastOperation;
                }
            }
            else
            {
                if (stream.textBox != String.Empty)
                {
                    num = Double.Parse(stream.textBox);
                    num = Math.Tanh(num);
                    if (str == "Grads")
                    {
                        num = num;
                    }
                    else if (str == "Degrees")
                    {
                        num = num;
                    }

                    if (stream.textBox != String.Empty)
                        this.apagar_ultima_operacao();
                    stream.textBox = num.ToString();
                    resultado = num;
                }
            }
        }

        public void calcular_raiz_quadrada()
        {
            Double num;
            if (stream.lastOperationSign != String.Empty)
            {
                if (stream.lastOperation != String.Empty)
                {
                    num = Double.Parse(stream.lastOperation);
                    num = Math.Sqrt(num);
                    if (stream.textBox != String.Empty)
                        this.apagar_ultima_operacao();
                    stream.lastOperation = num.ToString();
                    stream.textBox += stream.lastOperation;

                }
            }
            else
            {
                if (stream.textBox != String.Empty)
                {
                    num = Double.Parse(stream.textBox);
                    num = Math.Sqrt(num);
                    stream.textBox = num.ToString();
                    resultado = num;
                }
            }
        }

        public void obter_PI()
        {
            Double num;
            if (stream.lastOperationSign != String.Empty)
            {
                num = Math.PI;
                if (stream.textBox != String.Empty)
                    this.apagar_ultima_operacao();
                stream.lastOperation = num.ToString();
                stream.textBox += stream.lastOperation;
            }
            else
            {
                num = Math.PI;
                stream.textBox = num.ToString();
                resultado = num;
            }
        }

        public void calcular_INT()
        {
            Double num = 0;
            if (stream.lastOperationSign != String.Empty)
            {
                if (stream.lastOperation != String.Empty)
                {
                    num =(int) Double.Parse(stream.lastOperation);
                    if (stream.lastOperation != String.Empty)
                        this.apagar_ultima_operacao();
                    stream.lastOperation = num.ToString();
                    stream.textBox += stream.lastOperation;
                }
            }
            else
            {
                if (stream.textBox != String.Empty)
                {
                    num =(int) Double.Parse(stream.textBox);

                    if (stream.textBox != String.Empty)
                        this.apagar_ultima_operacao();
                    stream.textBox = num.ToString();
                    resultado = num;
                }
            }
        }

        public void calcular_logaritmo()
        {
            Double num = 0;
            if (stream.lastOperationSign != String.Empty)
            {
                if (stream.lastOperation != String.Empty)
                {
                    num = Double.Parse(stream.lastOperation);
                    num = Math.Log(num);
                    if (stream.lastOperation != String.Empty)
                        this.apagar_ultima_operacao();
                    stream.lastOperation = num.ToString();
                    stream.textBox += stream.lastOperation;
                }
            }
            else
            {
                if (stream.textBox != String.Empty)
                {
                    num = Double.Parse(stream.textBox);
                    num = Math.Log(num);
                    if (stream.textBox != String.Empty)
                        this.apagar_ultima_operacao();
                    stream.textBox = num.ToString();
                    resultado = num;
                }
            }
        }

        public int fazerfatorial(int num)
        {
            int fact = 1;
            if (num > 1)
            {
                fact=num;
                for (int count = num - 1; count >= 1; count--)
                {
                    fact *= count;
                }
            }

            return fact;
        }

        public void calcular_fatorial()
        {
            int num = 0;
            if (stream.lastOperationSign != String.Empty)
            {
                if (stream.lastOperation != String.Empty)
                {
                    num = (int)Double.Parse(stream.lastOperation);
                    if (num >= 0)
                    {
                        num = this.fazerfatorial(num);
                        if (stream.lastOperation != String.Empty)
                            this.apagar_ultima_operacao();
                        stream.lastOperation = num.ToString();
                        stream.textBox += stream.lastOperation;
                    }
                }
            }
            else
            {
                if (stream.textBox != String.Empty)
                {
                    num = (int)Double.Parse(stream.textBox);
                    if (num >= 0)
                    {
                        num = this.fazerfatorial(num);
                        if (stream.textBox != String.Empty)
                            this.apagar_ultima_operacao();
                        stream.textBox = num.ToString();
                        resultado = num;
                    }
                }
            }
        }

        public void exibir_resultado(){
            if (stream.lastOperation != String.Empty)
            {
                process_last_operation_simbol(Double.Parse(stream.lastOperation), stream.lastOperationSign);
                stream.exibir_resultado(resultado);
                stream.limpar_buffer_lastOperationSignSP();
            }
        }

        public void apagar_ultima_operacao()
        {
            if (stream.lastOperationSign != String.Empty)
                stream.apagar_ultima_operacao();
            else
            {
                stream.apagar_toda_operacao();
                resultado = 0;
            }
        }

        public void apagar_toda_operacao()
        {
            stream.apagar_toda_operacao();
            resultado = 0;
        }

        public void inverter_sinal()
        {
            Double num;
            if (stream.lastOperation != String.Empty)
            {
                num = Double.Parse(stream.lastOperation);
                num *= -1;

                stream.apagar_ultima_operacao();
                stream.lastOperation = num.ToString();
                stream.textBox += stream.lastOperation;
            }
            else
            {
                if (resultado != 0)//ver se isso aqui esta certo VERIFICAR
                {
                    resultado *= -1;
                    stream.apagar_ultima_operacao();
                    stream.exibir_resultado(resultado);
                }
            }
        }

        public void apagar_unidade()
        {
            if (stream.lastOperation != String.Empty)
            {
                if (stream.lastOperation.Length > 1)
                {
                    stream.lastOperation = stream.lastOperation.Remove(stream.lastOperation.Length - 1);
                    stream.textBox = stream.textBox.Remove(stream.textBox.Length - 1);
                }
                else
                {
                    stream.lastOperation = String.Empty;
                    if (stream.textBox.Length > 1)
                        stream.textBox = stream.textBox.Remove(stream.textBox.Length - 1);
                    else
                        stream.textBox = String.Empty;
                }
            }

            if (stream.lastOperationSign == String.Empty)
            {
                if (stream.textBox!=String.Empty)
                {
                    if (stream.textBox.Length > 1)
                        stream.textBox = stream.textBox.Remove(stream.textBox.Length - 1);
                    else
                        stream.textBox = String.Empty;

                    if (stream.textBox != String.Empty && stream.textBox.Length > 1 )
                    {
                        resultado = Double.Parse(stream.textBox);
                    }
                    else
                        resultado = 0;
                }
            }
        }

        public void adicionar_virgula()
        {
            if (stream.lastOperation != String.Empty)
            {
                if (stream.lastOperation.Contains(",") == false)
                {
                    stream.lastOperation += ",";
                    stream.textBox += ",";
                }
            }

            if (stream.lastOperationSign == String.Empty)
            {
                if (resultado != 0)
                {
                    if (stream.textBox != String.Empty)
                    {
                        if (stream.textBox.Contains(",") == false)
                        {
                            stream.textBox += ",";
                            resultado = Double.Parse(stream.textBox);
                        }
                    }
                }
            }
        }

        public void salvar_memoria()
        {
            if (stream.lastOperation != String.Empty)
            {
                stream.salvar_memoria(Double.Parse(stream.lastOperation));    
            }
            else
            {
                if (stream.textBox != String.Empty)
                {
                    stream.salvar_memoria(Double.Parse(stream.textBox));
                }
            }
        }

        public void apagar_memoria()
        {
            stream.limpar_memoria();
        }

        public void somar_memoria()
        {
            if (stream.lastOperation != String.Empty)
            {
                stream.soma_memoria(Double.Parse(stream.lastOperation));
            }
            else
            {
                if (stream.textBox != String.Empty)
                {
                    stream.soma_memoria(Double.Parse(stream.textBox));
                }
            }
        }

        public void subtrair_memoria()
        {
            if (stream.lastOperation != String.Empty)
            {
                stream.subtrair_memoria(Double.Parse(stream.lastOperation));
            }
            else
            {
                if (stream.textBox != String.Empty)
                {
                    stream.subtrair_memoria(Double.Parse(stream.textBox));
                }
            }
        }

        public void ler_memoria()
        {
            if (stream.hasMemory != String.Empty)
            {
                if (stream.lastOperationSign != String.Empty)
                {
                    if (stream.textBox != String.Empty)
                    {
                        if (stream.lastOperation != String.Empty)
                        {
                            this.apagar_ultima_operacao();
                            stream.lastOperation = stream.ler_memoria();
                            stream.textBox += stream.lastOperation;
                        }
                        else
                        {
                            stream.lastOperation = stream.ler_memoria();
                            stream.textBox += stream.lastOperation;
                        }
                    }
                    else
                    {
                        stream.lastOperation = stream.ler_memoria();
                        stream.textBox = stream.lastOperation;
                    }
                }
                else
                {
                    stream.lastOperation = stream.ler_memoria();
                    stream.textBox = stream.lastOperation;
                    resultado = 0;
                }
            }
        }

        public void limpar_memoria()
        {
            stream.limpar_memoria();
        }

        public void adicionar_num(Double num)
        {
            if (stream.lastOperationSign == String.Empty)
            {
                if (resultado != 0)
                {
                    stream.textBox += num.ToString();
                    resultado = Double.Parse(stream.textBox);
                }
                else
                {
                    stream.adicionar_num(num);
                }
            }
            else
            {
                stream.adicionar_num(num);
            }
        }

    }
}
