using System;
using System.Collections.Generic;
using System.Text;

namespace testarea
{
    class GameEngine
    {
        public Dice ld { get; set; }
        public Board luBoard { get; set; }
        public LudoBoardField[] ludoBoard { get; set; }
        public PlayPiece[] pieces { get; set; }

        
        public Player[] player { get; set; }
        
        public int antalSP { get; set; }


        public GameEngine(Dice ld, Board luBoard, LudoBoardField [] ludoBoard, PlayPiece[] pieces, Player[] player, int antalSp)
        {
            this.ld = ld;
            this.luBoard = luBoard;
            this.ludoBoard = ludoBoard;
            this.pieces = pieces;
            this.player = player;
            this.antalSP = antalSP;
        }
        
        public void startgame(int antalSP)
        {
            Random rand = new Random();
            Control ctrl = new Control();
            LudoBoardField[] ludoBoard = new LudoBoardField[52];
            PlayPiece[] pieces = new PlayPiece[16];
            player = new Player[antalSP];
            ludoBoard = luBoard.makeBoard();


            pieces = luBoard.createLudoPieces();
            LudoHelper.color[] luHelp = new LudoHelper.color[4];
            luHelp[0] = LudoHelper.color.red;
            luHelp[1] = LudoHelper.color.yellow;
            luHelp[2] = LudoHelper.color.blue;
            luHelp[3] = LudoHelper.color.green;
            Dice ld = new Dice(6);
            int[] rNumber = ld.getRandomNR(0, antalSP);

            luHelp = ctrl.unsortArray(luHelp);

            int tal = 0;
            for (int i = 0; i <= antalSP-1; i++)
            {
                tal = rNumber[i];
                player[i] = new Player(false, luHelp[tal], true, tal+1);
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
            Dice lb = new Dice(6);
            int dTal = 0;
            int ct = 0;
            string brikNr = "";
            LudoHelper.color plColor = next;
            int tal =Convert.ToInt32(plColor);
            while (true)
            {
                if (!player[tal].isPieceOut)
                {

                    if (ct == 0)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Spiller nr {0:D} der spiller {1:D} har først 3 forsøg på at få en brik ud ", player[tal].playerNr, player[tal].colorChoise.ToString());
                        
                        ct++;
                    } else
                    {
                        
                        Console.WriteLine("");
                        Console.WriteLine("Spiller nr {0:D} der spiller {1:D} har først 3 forsøg på at få en brik ud ", player[tal].playerNr, player[tal].colorChoise.ToString());
                    }
                    
                    for (int i = 1; i <= 3; i++)
                    {
                        Console.Write("Rul en terning ved at trykke d: ");
                        if (Console.ReadLine().ToLower() == "d") Console.WriteLine("Du har rullet {0:D}", dTal = lb.roll_D6Dice());
                        else Console.WriteLine("Du har rullet 1", dTal = 1);
                        if (dTal == 6)
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
                            Console.WriteLine("Så er det spillernr {0:D} tur", player[tal].playerNr);
                            moveN(tal, dTal, pieces);
                            break;
                        }

                    }
                } else 
                {
                    Console.WriteLine("Så er det spillernr {0:D} tur", player[tal].playerNr);
                    moveN(tal, dTal, pieces);



                   




                }
                
                plColor = playerNext(plColor);
                tal = Convert.ToInt32(plColor);
                Console.WriteLine("Så er det spillernr {0:D} tur", player[tal].playerNr);
            }
            

        }
        //Funktion der håndtere at du rykker brikker videre
        public void moveN(int tal, int dTal, PlayPiece[] pieces)
        {
            Dice ld = new Dice(6);
            string brikNr = "";
            Control ctrl = new Control();

            Console.WriteLine("");
            Console.WriteLine("Så er det spillernr {0:D} tur", player[tal].playerNr);
            Console.WriteLine("Du har nu mindst en ude og kan rulle for at rykke en brik ");


            Console.Write("Rul en terning ved at trykke d: ");
            if (Console.ReadLine().ToLower() == "d")
            {
                Console.WriteLine("Du har rullet {0:D}", dTal = ld.roll_D6Dice());
                Console.WriteLine("Og kan rykket følgende brik ");
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

                Console.Write("Vælg brik: ");
                brikNr = ctrl.testBrugerBrikInd(Console.ReadLine());
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
        }

        public bool mayBootOut(int where, PlayPiece[] pieces, string brik)
        {
            string firstPart = brik.Substring(0, 1);

            foreach (PlayPiece p in pieces)
            {
                if (firstPart != p.brikNr.Substring(0, 1))
                {
                    if (where == p.locationBoard)
                    {
                        return true;
                        break;
                    } else
                    {
                        false;
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





    }
}

