using System;

namespace diobank
{
    public class Conta
    {
        private tipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string nome { get; set; }

        public Conta(tipoConta TipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = TipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.nome = nome;
        }

        public bool Sacar(double valorSaque)
        {
            if (this.Saldo - valorSaque < (this.Credito * -1))
            {
                Console.WriteLine("Saldo Insuficiente");
                return false;
            }

            this.Saldo -= valorSaque;

            Console.WriteLine("Saldo atual da conte de {0} é : {1}", this.nome, this.Saldo);
            return true;
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;
            Console.WriteLine("Saldo atual da conte de {0} é : {1}", this.nome, this.Saldo);
        }

        public void Transferir(double valorTransferencia, Conta contadestino)
        {
            if (this.Sacar(valorTransferencia))
            {
                contadestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno = string.Empty;
            retorno += "Tipo de Conta : " + this.TipoConta + " | ";
            retorno += "Nome : " + this.nome + " | ";
            retorno += "Saldo : " + this.Saldo + " | ";
            retorno += "Credito : " + this.Credito + " | ";
            return retorno;
        }
    }
}