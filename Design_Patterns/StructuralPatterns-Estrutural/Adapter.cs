using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.StructuralPatterns_Estrutural
{
    //Adaptee Class (Classe adaptada)
    public class CelsiusPresenter
    {
        public double _temperatureInc;

        public CelsiusPresenter()
        {

        }

        public double GetTemperature()
        {
            return _temperatureInc;
        }

        public void setTemperature(double temperatureInc)
        {
            this._temperatureInc = temperatureInc;
        }
    }

    //Target Interface
    public interface ITemperatureInfo
    {
        double getTemperatureInf();
        void setTemperatureInf(double temperatureInf);
        double getTemperatureInc();
        void setTemperatureInc(double temperatureInc);
    }

    //Class Adapter
    public class TemperatureClassPresenter : CelsiusPresenter, ITemperatureInfo
    {
        public double getTemperatureInc()
        {
            return _temperatureInc;
        }

        public double getTemperatureInf()
        {
            return cToF(_temperatureInc);
        }

        public void setTemperatureInc(double temperatureInc)
        {
            this._temperatureInc = temperatureInc;
        }

        public void setTemperatureInf(double temperatureInf)
        {
            this._temperatureInc = fToC(temperatureInf);
        }

        public double cToF(double c)
        {
            return ((c * 9 / 5) + 32);
        }

        public double fToC(double f)
        {
            return ((f - 32) * 5 / 9);
        }
    }

    //Object Adapter
    public class TemperatureObjectPresenter : ITemperatureInfo
    {
        CelsiusPresenter celsiusPresenter;

        public TemperatureObjectPresenter()
        {
            celsiusPresenter = new CelsiusPresenter();
        }

        public double getTemperatureInc()
        {
            return celsiusPresenter.GetTemperature();
        }

        public double getTemperatureInf()
        {
            return cToF(celsiusPresenter.GetTemperature());
        }

        public void setTemperatureInc(double temperatureInc)
        {
            celsiusPresenter.setTemperature(temperatureInc);
        }

        public void setTemperatureInf(double temperatureInf)
        {
            celsiusPresenter.setTemperature(fToC(temperatureInf));
        }

        public double fToC(double f)
        {
            return ((f - 32) * 5 / 9);
        }

        public double cToF(double c)
        {
            return ((c * 9 / 5) + 32);
        }
    }

    public class Adapter
    {
        public static void Main()
        {
            Console.WriteLine("Class adapter test");
            ITemperatureInfo tempInfo = new TemperatureClassPresenter();
            testeTempInfo(tempInfo);

            //Object Adapter
            Console.Write("Object adapter test");
            tempInfo = new TemperatureObjectPresenter();
            testeTempInfo(tempInfo);
        }

        public static void testeTempInfo(ITemperatureInfo temperatureInfo)
        {
            temperatureInfo.setTemperatureInc(0);
            Console.WriteLine("temp in C:" + temperatureInfo.getTemperatureInc());
            Console.WriteLine("temp in F:" + temperatureInfo.getTemperatureInf());

            temperatureInfo.setTemperatureInf(85);
            Console.WriteLine("temp in C:" + temperatureInfo.getTemperatureInc());
            Console.WriteLine("temp in F:" + temperatureInfo.getTemperatureInf());
        }

    }
}
