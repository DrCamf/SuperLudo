using System;
using System.Collections.Generic;
using System.Text;

namespace testarea
{
    class GameEngine
    {
        public Dice ludoDice { get; set; }
        public Board ludoBoard { get; set; }
        public LudoBoardField[] ludoBoardFeld { get; set; }
        public PlayPiece[] pieces { get; set; }

        
        public Player[] player { get; set; }
        
        public int antalSP { get; set; }


        public GameEngine(Dice ludoDice, Board ludoBoard, LudoBoardField[] ludoBoardFeld, PlayPiece[] pieces)
        {
            this.ludoDice = ludoDice;
            this.ludoBoard = ludoBoard;
            this.ludoBoardFeld = ludoBoardFeld;
            this.pieces = pieces;
            this.player = player;
            
        }
        
        public void startgame(int antalSP)
        {
            Random rand = new Random();
            Control ctrl = new Control();
            LudoBoardField[] ludoBoard = new LudoBoardField[52];
            PlayPiece[] pieces = new PlayPiece[16];
            player = new Player[antalSP];
            ludoBoard = this.ludoBoard.makeBoard();


            pieces = this.ludoBoard.createLudoPieces();
            LudoHelper.color[] ludoHelp = new LudoHelper.color[4];
            ludoHelp[0] = LudoHelper.color.red;
            ludoHelp[1] = LudoHelper.color.yellow;
            ludoHelp[2] = LudoHelper.color.blue;
            ludoHelp[3] = LudoHelper.color.green;
            Dice ludoDice = new Dice(6);
            int[] rNumber = ludoDice.getRandomNR(0, antalSP);

            ludoHelp = ctrl.unsortArray(ludoHelp);

            int tal = 0;
            for (int i = 0; i <= antalSP-1; i++)
            {
                tal = rNumber[i];
                player[i] = new Player(false, ludoHelp[tal], true, tal+1);
            }

            player = ctrl.sortArray(player);

            for (int i = 0; i < player.Length ; i++)
            {
                Console.WriteLine("Spiller nr {0:D} har fået farve {1:D}", player[i].playerNr, player[i].colorChoise.ToString());
            }
            tal = rand.Next(0, 4);
            //Console.WriteLine("Det er spiller nr {0:D} der starter med {1:D} farve", tal+1, player[tal].colorChoise.ToString());
            
            moveOutNOn(player[tal].colorChoise, pieces);
        } 

        public void moveOutNOn(LudoHelper.color next, PlayPiece[] pieces) 
        {
            Control ctrl = new Control();
            Dice ludoDice = new Dice(6);
            int diceTal = 0;
            int cntr = 0;
            string brikNr = "";
            LudoHelper.color plColor = next;
            int tal =Convert.ToInt32(plColor);

            while (true)
            {
                if (!player[tal].isPieceOut)
                {
                    if (cntr == 0)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Spiller nr {0:D} der spiller {1:D} har først 3 forsøg på at få en brik ud ", player[tal].playerNr, player[tal].colorChoise.ToString());
                        cntr++;
                    } else
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Spiller nr {0:D} der spiller {1:D} har først 3 forsøg på at få en brik ud ", player[tal].playerNr, player[tal].colorChoise.ToString());
                    }
                    
                    for (int i = 1; i <= 3; i++)
                    {
                        Console.Write("Rul en terning ved at trykke d: ");
                        if (Console.ReadLine().ToLower() == "d") Console.WriteLine("Du har rullet {0:D}", diceTal = ludoDice.roll_D6Dice());
                        else Console.WriteLine("Du har rullet 1", diceTal = 1);
                        if (diceTal == 6)
                        {
                            Console.WriteLine("Du har fået en ud ");
                            player[tal].isPieceOut = true;
                            for (int j = 0; j < pieces.Length; j++)
                            {
                                if (pieces[j].color == player[tal].colorChoise)
                                {
                                    if (pieces[j].state == LudoHelper.state.ude)
                                    {
                                        pieces[j].state = LudoHelper.state.move;
                                        
                                        break;
                                    } else
                                    {
                                        pieces[j+1].state = LudoHelper.state.move;
                                        break;
                                    }
                                }
                            }
                            moveNormal(tal, diceTal, pieces);
                            break;
                        }
                    }
                }
                else 
                {
                    Console.WriteLine("Så er det spillernr {0:D} tur", player[tal].playerNr);
                    moveNormal(tal, diceTal, pieces);
                }
                
                plColor = playerNext(plColor);
                tal = Convert.ToInt32(plColor);
                //Console.WriteLine("Så er det spillernr {0:D} tur", player[tal].playerNr);
            }
 
        }

        //Funktion der håndtere at du rykker brikker videre
        public void moveNormal(int tal, int dTal, PlayPiece[] pieces)
        {
            Dice ludoDice = new Dice(6);
            string brikNr = "";
            Control ctrl = new Control();
            string playerInd = "";

            Console.WriteLine("");
            //Console.WriteLine("Så er det spillernr {0:D} tur", player[tal].playerNr);
            Console.WriteLine("Du har nu mindst en ude og kan rulle for at rykke en brik ");


            Console.Write("Rul en terning ved at trykke d: ");
            if (Console.ReadLine().ToLower() == "d")
            {
                dTal = ludoDice.roll_D6Dice();
                if (dTal== 6 && isAnyStillOut(tal, pieces))
                {
                    Console.WriteLine("Du har rullet 6 og både nogle ude og nogle på brættet så hvem skal rykkes udefra så tryk u \r\n eller vælge en af de mulige fra det udskrevne:");
                    possiblePieces(tal, pieces);
                    playerInd = Console.ReadLine().ToLower();
                    if (playerInd == "u")
                    {

                    }
                }
                Console.WriteLine("Du har rullet {0:D}", dTal);
                Console.WriteLine("Og kan rykket følgende brik ");
                possiblePieces(tal, pieces);

                Console.Write("Vælg brik: ");
               
                brikNr = ctrl.testBrugerBrikInd(Console.ReadLine());
                if (brikNr.Substring(0, 1).ToLower() == player[tal].colorChoise.ToString().Substring(0, 1))
                {
                    foreach (PlayPiece p in pieces)
                    {
                        if (p.brikNr == brikNr)
                        {
                            p.locationBoard += dTal;
                            Console.WriteLine("Brik nr {0:D} har rykket til feld nr {1:D}", brikNr, p.locationBoard);
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Du må kun rykke egne brikker");
                }
            }
        }

        public void possiblePieces(int tal, PlayPiece[] pieces)
        {
            for (int i = 0; i <= pieces.Length - 1; i++)
            {
                if (pieces[i].color == player[tal].colorChoise)
                {
                    if (pieces[i].state == LudoHelper.state.move)
                    {
                        Console.WriteLine(" brik nr {0:D} som står på felt {1:D}", pieces[i].brikNr, pieces[i].locationBoard);
                    }
                }
            }
        }

        //Funktion der tester om du må slå brik hjem afhægning af om det er en anden farve
        public bool mayBootOut(int where, PlayPiece[] pieces, string brik)
        {
            string firstPart = brik.Substring(0, 1);
            bool may = false;

            foreach (PlayPiece p in pieces)
            {
                if (firstPart != p.brikNr.Substring(0, 1))
                {
                    if (where == p.locationBoard && p.state != LudoHelper.state.ude)
                    {
                        may = true;
                        break;
                    } 
                }
                else
                {
                    may = false;
                }
            }
            return may;
        }

        //Funktion der tester om den der foran dig er af samme farve og om felt du skal til er fri
        public bool mayPass(int whereTo, PlayPiece[] pieces, string brik)
        {
            string firstPart = brik.Substring(0, 1);
            bool may = false;

            foreach (PlayPiece p in pieces)
            {
                if (firstPart != p.brikNr.Substring(0, 1))
                {
                    if (whereTo != p.locationBoard)
                    {
                        may = true;
                        break;
                    }
                }
                else
                {
                    may = false;
                }
            }
            return may;
        }

        public void bootOut(int where, PlayPiece[] pieces, string brik)
        {
            if(mayBootOut(where, pieces, brik))
            {
                foreach (PlayPiece p in pieces)
                {
                    if (where == p.locationBoard)
                    {
                        p.state = LudoHelper.state.ude;
                        p.locationBoard = moveToMove(p.color);
                        break;
                    }
                   
                }
               
            }
        }

        public LudoHelper.color playerNext(LudoHelper.color color)
        {
            switch (color)
            {
                case LudoHelper.color.green:
                    return LudoHelper.color.blue;
                case LudoHelper.color.blue:
                    return LudoHelper.color.yellow;
                case LudoHelper.color.yellow:
                    return LudoHelper.color.red;
                case LudoHelper.color.red:
                    return LudoHelper.color.green;
                default:
                    return LudoHelper.color.green;
            }
        }
        //Funktion der flytter dem ud til start steder udfra farve
        public int moveToMove(LudoHelper.color color)
        {
            int moveNr = 0;

            switch (color)
            {
                case LudoHelper.color.green:
                    moveNr = 1;
                    break;
                case LudoHelper.color.blue:
                    moveNr = 14;
                    break;
                case LudoHelper.color.yellow:
                    moveNr = 25;
                    break;
                case LudoHelper.color.red:
                    moveNr = 40;
                    break;
            }
            return moveNr;
        }


        public bool isAnyStillOut(int tal, PlayPiece[] pieces)
        {
            bool yes = false;

            foreach(PlayPiece p in pieces)
            {
                if (p.color.ToString().Substring(0,1) == player[tal].colorChoise.ToString().Substring(0,1))
                {
                    if (p.state == LudoHelper.state.ude)
                    {
                        yes = true;
                        break;
                    } else
                    {
                        yes = false;
                    }
                }
            }

            return yes;
        }

       

        public void c64Menu()
        {
            string choise = "";
            string menu = "    **** COMMODORE 64 BASIC V2 **** \r\n \r\n" + " 64K RAM SYSTEM 38911 BASIC BYTES FREE   \r\n \r\n" + "READY. ";
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Clear();

            Console.WriteLine(menu);

            choise = Console.ReadLine().ToLower();

            if (choise == "load ludo")
            {
                Console.Clear();
                ludoMenu();
            }
            else
            {
                Console.Clear();
                ludoMenu();
                }
            }

            // Laver en simpelt menu hvor du kan vælge antal spiller og afslutte spil
            public void ludoMenu()
            {
                antalSP = 0;
                Control ctrl = new Control();
                string lMenu = "########################################################################  \r\n" + "############################## SUPER LUDO ############################## \r\n"
                    + "######################################################################## \r\n" + "######################### Et spil af Th's prog ######################### \r\n"
                    + "######################################################################## \r\n \r\n" + "## Vælg antal spiller (2-4) \r\n \r\n" + "Eller tryke e for at slutte: ";

                Console.Write(lMenu);

                antalSP = ctrl.testBrugerTal(Console.ReadLine());

                startgame(antalSP);
                
            }
        



    }
}

