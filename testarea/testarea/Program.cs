using System;

namespace testarea
{
    class Program
    {
        public static Board ludoBoard = new Board();
        public static LudoBoardField[] ludoBoardFeld = new LudoBoardField[52];
        public static PlayPiece[] pieces = new PlayPiece[16];
        public static Player[] player = new Player[4];
        public static int antalSp = 0;
        public static Dice ludoDice = new Dice(6);
        public static Control ctrl = new Control();
        public static GameEngine g; 

        static void Main(string[] args)
        {
            int antalSP = 0;
            g = new GameEngine(ludoDice, ludoBoard, ludoBoardFeld, pieces);

            g.c64Menu();

            antalSP = ctrl.testBrugerTal(Console.ReadLine());

            
            g.startgame(antalSP);

            

           
            Console.ReadKey();
        }

       

    
    }
}
