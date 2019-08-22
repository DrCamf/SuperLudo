using System;

namespace testarea
{
    class Program
    {
        public static Board luBoard = new Board();
        public static LudoBoardField[] ludoBoard = new LudoBoardField[52];
        public static PlayPiece[] pieces = new PlayPiece[16];
        public static Player[] player = new Player[4];
        public static int antalSp = 0;
        public static Dice ld = new Dice(6);
        public static Control ctrl = new Control();
        public static GameEngine g; 

        static void Main(string[] args)
        {
            int antalSP = 0;
            Console.WriteLine("");
            Console.WriteLine("Velkommen til SUPER LUDO");
            Console.WriteLine("");
            Console.Write("Hvor mange spillere 2-4: ");

            antalSP = ctrl.testBrugerTal(Console.ReadLine());

            g = new GameEngine(ld, luBoard, ludoBoard, pieces, player, antalSP);
            g.startgame(antalSP);

            

           
            Console.ReadKey();
        }

       

    
    }
}
