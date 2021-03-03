using System;

namespace DIO.Bank
{
    public class Conta
    {
        private TipoConta TipoConta{ get; set; }
        private string Nome { get; set; }
        private double Credito { get; set; }
        private double Saldo { get; set; }

        public Conta(TipoConta tipoConta, string nome, double saldo, double credito){//construtor diferenciado
            this.TipoConta = tipoConta;
            this.Nome = nome;
            this.Saldo = saldo;
            this.Credito = credito;
        }

        public bool Sacar(double valorSaque){
            if(this.Saldo - valorSaque < (this.Credito * -1)){//checa se o valor a se sacar eh maior que o saldo e aborta
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }
            this.Saldo -= valorSaque;
            Console.WriteLine("Saldo atual da conta de {0} eh {1}", this.Nome, this.Saldo);
            return true;
        }
        public void Depositar(double valorDeposito){
            this.Saldo += valorDeposito;
            Console.WriteLine("Saldo atual da conta de {0} eh {1}", this.Nome, this.Saldo);
        }
        public void Transferir(double valorTransferencia, Conta contaDestino){
            if(this.Sacar(valorTransferencia)){//se o metodo der certo
                contaDestino.Depositar(valorTransferencia);//afinal, transferir nada mais eh que depositar em outra conta
            }
        }
        public override string ToString()//metodo ToString nativo alterado com override
        {
            string retorno = "";
            retorno += "TipoConta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Credito " + this.Credito;
            return retorno;
        }
    }
}