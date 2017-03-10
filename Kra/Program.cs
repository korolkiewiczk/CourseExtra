using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kra
{
    class Program
    {
        private static int _wysokoscRurki;
        private static int _iloscKrazkow;
        private static int[] _sredniceOtworow;
        private static int[] _sredniceKrazkow;
        private static int[] _szerokoscMin;


        static void Main(string[] args)
        {
            WczytajDane();

            BudujTabliceSzerokosciMinimalnej();

            Console.WriteLine(ObliczWynik());
        }

        private static int ObliczWynik()
        {
            int pozycja = _wysokoscRurki + 1;
            for (int i = 0; i < _iloscKrazkow && pozycja >= 0; i++)
            {
                if (pozycja > 0) --pozycja;
                while (_sredniceKrazkow[i] > _szerokoscMin[pozycja]) pozycja--;
            }

            return pozycja;
        }

        private static void WczytajDane()
        {
            var nm = Console.ReadLine().Split(' ');
            _wysokoscRurki = int.Parse(nm[0]);
            _iloscKrazkow = int.Parse(nm[1]);

            _sredniceOtworow = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            _sredniceKrazkow = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        }

        private static void BudujTabliceSzerokosciMinimalnej()
        {
            _szerokoscMin = new int[_wysokoscRurki + 1];
            _szerokoscMin[0] = int.MaxValue;
            for (int i = 0; i < _wysokoscRurki; i++)
            {
                _szerokoscMin[i + 1] = Math.Min(_szerokoscMin[i], _sredniceOtworow[i]);
            }
        }
    }
}
