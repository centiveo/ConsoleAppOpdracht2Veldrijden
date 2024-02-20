using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppOpdracht2Veldrijden
{
    internal class Veldrijder
    {
        private readonly static Random rng = new Random();

        public int Snelheid {get; }
        public int Tactiek {get; }
        public int Explosiviteit { get; }
        public int Emotioneel { get; }
        public int Inzicht { get; }
        public int Recuperatie { get; }
        public int Ervaring { get;  }


        public static int Modifier(int score) => (int)Math.Floor((score - 10) * 0.5);
        private static int RolDobbelsteen() => rng.Next(1, 7);

        public static int Eigenschap() => new[] { RolDobbelsteen(), RolDobbelsteen(), RolDobbelsteen(), RolDobbelsteen() }
            .OrderByDescending(v => v)
            .Take(3)
            .Sum();


        public static Veldrijder Generate()
        {
            return new Veldrijder(
                Eigenschap(),
                Eigenschap(),
                Eigenschap(),
                Eigenschap(),
                Eigenschap(),
                Eigenschap()
            );
        }

        public Veldrijder(int snelheid, int tactiek, int explosiviteit, int emotioneel, int inzicht, int recuperatie)
        {
            Snelheid = snelheid;
            Tactiek = tactiek;
            Explosiviteit = explosiviteit;
            Emotioneel = emotioneel;
            Inzicht = inzicht;
            Recuperatie = recuperatie;
            Ervaring = 10 + Modifier(emotioneel);
        }
    }
}
