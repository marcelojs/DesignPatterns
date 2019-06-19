using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.StructuralPatterns_Estrutural
{
    //Interface que será usado pela classe cliente 
    //para obter as funcionalidades da interface
    public interface ITarget
    {
        void MethodA();
    }

    //Classe com as implementações da Interface e herança de classe Adaptee, essa classe
    //é responsável por mediar a comunicação entre cliente e adaptee.
    public class Adapter2 : Adaptee, ITarget
    {
        public void MethodA()
        {
            MethodB();
        }
    }

    //Classe que tem funcionalidades requerida pelo cliente porém a interface não é
    //compativel com a classe cliente
    public class Adaptee
    {
        public void MethodB()
        {
            Console.WriteLine("MethodB() is called");
        }
    }

    //Classe cliente que interage com um tipo que implementa a inteface,
    //porém a comunicação da classe chamada adaptee não é compativel com a classe cliente
    public class Client
    {
        private ITarget _target;

        public Client(ITarget target)
        {
            this._target = target;
        }

        public void MakeRequest()
        {
            _target.MethodA();
        }
    }
}
