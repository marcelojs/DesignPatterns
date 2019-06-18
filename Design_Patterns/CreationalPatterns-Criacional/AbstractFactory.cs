using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.CreationalPatterns_Criacional
{
    //Abstract Factory
    public abstract class GalpaoFactory
    {
        public abstract Bicicleta ObterTipoBicicleta();
        public abstract Scooter ObterTipoScooter();
        public abstract Custom ObterTipoCustom();
    }


    //Abstract Product
    public abstract class Bicicleta
    {
        public abstract string Nome();
    }

    public abstract class Scooter
    {
        public double Peso { get; set; }
        public string TipoMotor { get; set; }

        public abstract string Nome();
    }

    public abstract class Custom
    {
        public double Peso { get; set; }
        public string TipoMotor { get; set; }
        public int QuantidadeMarchas { get; set; }

        public abstract string Nome();
    }


    //Concrete Products
    public class BicicletaEsportiva : Bicicleta
    {
        public override string Nome()
        {
            return "DROPP";
        }
    }

    public class BicicletaNormal : Bicicleta
    {
        public override string Nome()
        {
            return "Caloi";
        }
    }

    public class ScooterPorteGrande : Scooter
    {
        public override string Nome()
        {
            return "Yamaha TMAX";
        }
    }

    public class ScooterPortePequeno : Scooter
    {
        public override string Nome()
        {
            return "Biz";
        }
    }

    public class Chooper : Custom
    {
        public override string Nome()
        {
            return "Chopper Road 150cc";
        }
    }

    public class Bobber : Custom
    {
        public override string Nome()
        {
            return "Indian Scout Bobber";
        }
    }


    //Concrete Factory
    public class Galpao1Factory : GalpaoFactory
    {
        public override Bicicleta ObterTipoBicicleta()
        {
            //Galpão 1 fabrica somente bicicleta esportiva
            return new BicicletaEsportiva();
        }

        public override Custom ObterTipoCustom()
        {
            return new Chooper();
        }

        public override Scooter ObterTipoScooter()
        {
            return new ScooterPortePequeno();
        }
    }

    public class Galpao2Factory : GalpaoFactory
    {
        public override Bicicleta ObterTipoBicicleta()
        {
            return new BicicletaNormal();
        }

        public override Custom ObterTipoCustom()
        {
            return new Bobber();
        }

        public override Scooter ObterTipoScooter()
        {
            return new ScooterPorteGrande();
        }
    }


    //Cliente
    public class GalpaoCliente
    {
        private readonly Bicicleta _bicicleta;
        private readonly Scooter _scooter;
        private readonly Custom _custom;

        public GalpaoCliente(GalpaoFactory galpaoFactory)
        {
           _bicicleta =  galpaoFactory.ObterTipoBicicleta();
            _scooter = galpaoFactory.ObterTipoScooter();
            _custom = galpaoFactory.ObterTipoCustom();
        }

        public string ObterNomeBicicleta()
        {
            return _bicicleta.Nome();
        }

        public string ObterNomeCustom()
        {
            return _custom.Nome();
        }

        public string ObterNomeScooter()
        {
            return _scooter.Nome();
        }
    }


    public class AbstractFactory
    {
        public static void Executar()
        {
            GalpaoFactory galpao1 = new Galpao1Factory();
            var galpaoCliente1 = new GalpaoCliente(galpao1);
            Console.WriteLine("Bicicleta do galpão 1.: "+ galpaoCliente1.ObterNomeBicicleta());
            Console.WriteLine("Moto Custom do galpão 1.: " + galpaoCliente1.ObterNomeCustom());
            Console.WriteLine("Scooter do galpão 1.: " + galpaoCliente1.ObterNomeScooter());

            GalpaoFactory galpao2 = new Galpao2Factory();
            var galpaoCliente2 = new GalpaoCliente(galpao2);
            Console.WriteLine("Bicicleta do galpão 2.: " + galpaoCliente2.ObterNomeBicicleta());
            Console.WriteLine("Moto Custom do galpão 2.: " + galpaoCliente2.ObterNomeCustom());
            Console.WriteLine("Scooter do galpão 2.: " + galpaoCliente2.ObterNomeScooter());
        }


    }
}
