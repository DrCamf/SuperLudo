using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILudo
{
    class GameEngine
    {
        public Dice ludoDice { get; set; }
        public Board ludoBoard { get; set; }
        public LudoBoardField[] ludoBoardFeld { get; set; }
        public PlayPiece[] pieces { get; set; }


        public Player[] player { get; set; }

        public int antalSP { get; set; }
        public string userMessage;

        public GameEngine(Dice ludoDice, Board ludoBoard, LudoBoardField[] ludoBoardFeld, PlayPiece[] pieces)
        {
            this.ludoDice = ludoDice;
            this.ludoBoard = ludoBoard;
            this.ludoBoardFeld = ludoBoardFeld;
            this.pieces = pieces;
            this.player = player;

        }

        //Den funktion der opretter spillere og tildeler dem en farve og hvem der er først
        public string startgame(int antalSP)
        {
            Random rand = new Random();
            Control ctrl = new Control();
            LudoBoardField[] ludoBoard = new LudoBoardField[52];
            PlayPiece[] pieces = new PlayPiece[16];
            player = new Player[antalSP];
            ludoBoard = this.ludoBoard.makeBoard();
            userMessage = "";

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
            for (int i = 0; i <= antalSP - 1; i++)
            {
                tal = rNumber[i];
                player[i] = new Player(false, ludoHelp[tal], true, tal + 1);
            }

            player = ctrl.sortArray(player);

            for (int i = 0; i < player.Length; i++)
            {
                userMessage += "Spiller nr " + player[i].playerNr + " har fået farve " + player[i].colorChoise.ToString() + " \r\n";
            }
            if (antalSP < 3)
            {
                tal = rand.Next(0, 1);
                userMessage += "Det er spiller nr " + (tal + 1) + " der starter med " + player[tal].colorChoise.ToString() + " farve";
            } else
            {
                tal = rand.Next(0, 4);
                userMessage += "Det er spiller nr " + (tal + 1) + " der starter med " + player[tal].colorChoise.ToString() + " farve";
            }
            
            
            //moveControl(player[tal].colorChoise, pieces);
            return userMessage;
        }

        //Funktion der samler move funktioner og udfører dem udfra om man har brikker ude eller ej
        public void moveControl(LudoHelper.color next, PlayPiece[] pieces)
        {

            LudoHelper.color plColor = next;
            int tal = Convert.ToInt32(plColor);

            while (true)
            {

                if (!player[tal].isPieceOut)
                {
                    moveOut(player[tal].colorChoise, pieces);
                }
                else
                {
                    moveNormal(tal, pieces);

                }
                plColor = playerNext(plColor);
                tal = Convert.ToInt32(plColor);

                Console.WriteLine("Så er det spillernr {0:D} tur", player[tal].playerNr);



            }
        }

        //Funktion der udfører slag for at få brikker ud på brættet hvor du har 3 forsøg hvis du ikke har nogen ude
        public void moveOut(LudoHelper.color next, PlayPiece[] pieces)
        {
            Control ctrl = new Control();
            Dice ludoDice = new Dice(6);
            int diceTal = 0;

            LudoHelper.color plColor = next;
            int tal = Convert.ToInt32(plColor);
            userMessage = "";

            
            userMessage = "Spiller nr " + player[tal].playerNr + " der spiller " + player[tal].colorChoise.ToString()  + " har først 3 forsøg på at få en brik ud ";

            for (int i = 1; i <= 3; i++)
            {
                
               
                if (diceTal == 6)
                {
                    userMessage = "Du har fået en ud ";
                    player[tal].isPieceOut = true;
                    changeToMove(pieces, tal);

                    moveNormal(tal, pieces);
                    break;
                }
            }
        }

        // Funktion der ændrer brikkens state fra ude til move
        public void changeToMove(PlayPiece[] pieces, int tal)
        {
            for (int j = 0; j < pieces.Length; j++)
            {
                if (pieces[j].color == player[tal].colorChoise)
                {
                    if (pieces[j].state == LudoHelper.state.ude)
                    {
                        pieces[j].state = LudoHelper.state.move;
                        break;
                    }
                    else
                    {
                        pieces[j + 1].state = LudoHelper.state.move;
                        break;
                    }
                }
            }
        }

        //Funktion der håndtere at du rykker brikker videre
        public void moveNormal(int tal, PlayPiece[] pieces)
        {
            Dice ludoDice = new Dice(6);
            string brikNr = "";
            Control ctrl = new Control();
            string playerInd = "";
            int whereTo = 0;
            int dTal = 0;

            Console.WriteLine("");
            //Console.WriteLine("Så er det spillernr {0:D} tur", player[tal].playerNr);
            Console.WriteLine("Du har nu mindst en ude og kan rulle for at rykke en brik ");


            Console.Write("Rul en terning ved at trykke d: ");
            if (Console.ReadLine().ToLower() == "d")
            {
                dTal = ludoDice.roll_D6Dice();
                if (dTal == 6 && isAnyStillOut(tal, pieces))
                {
                    Console.WriteLine("Du har rullet 6 og både nogle ude og nogle på brættet så hvem skal rykkes udefra så tryk u \r\n eller vælge en af de mulige fra det udskrevne:");
                    possiblePieces(tal, pieces);
                    playerInd = Console.ReadLine().ToLower();
                    if (playerInd == "u")
                    {
                        Console.WriteLine("Du har fået en ud ");
                        changeToMove(pieces, tal);
                        moveNormal(tal, pieces);
                    }
                    else
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
                            if (mayPass(p.locationBoard, pieces, brikNr))
                            {
                                Console.WriteLine("Brik nr {0:D} har rykket til feld nr {1:D}", brikNr, p.locationBoard);
                                break;
                            }
                            else
                            {
                                if (isAnyStillMove(tal, pieces, brikNr))
                                {
                                    Console.WriteLine("Ikke lovligt træk vælg anden brik");
                                    possiblePieces(tal, pieces);

                                }
                                else
                                {
                                    Console.WriteLine("Du har ikke andre ude og må vente til næste tur");
                                }

                            }


                        }
                    }
                }
                else
                {
                    Console.WriteLine("Du må kun rykke egne brikker");
                }
            }
        }

        //Funktion der udskriver de brikker du har på brættet med state = move
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

        //Funktion der sørger for at alle andre end grøn kan fortsætte rundt om brættet efter felt nr 51
        public int moveAround(int where, string brikNr)
        {
            int whereTo = 0;

            if (where > 51 && brikNr.Substring(0, 1) != "g")
            {
                whereTo = where - 52;
            }
            else
            {
                whereTo = where;
            }

            return whereTo;
        }

        // Funktion der kontrollere at du er kommet til stjernen ved din zone og beregner hvor meget du har til overerst 
        public int enterZone(int where, string brikNr, int dice, PlayPiece piece)
        {
            string color = brikNr.Substring(0, 1).ToLower();
            int before = where - dice;
            int howMuch = 0;

            if (color == "b" && before <= 12 && where > 12)
            {
                piece.state = LudoHelper.state.zone;
                howMuch = where - 12;
            }
            else if (color == "y" && before <= 25 && where > 25)
            {
                piece.state = LudoHelper.state.zone;
                howMuch = where - 25;
            }
            else if (color == "r" && before <= 38 && where > 38)
            {
                piece.state = LudoHelper.state.zone;
                howMuch = where - 38;
            }
            else if (color == "g" && before <= 51 && where > 51)
            {
                piece.state = LudoHelper.state.zone;
                howMuch = where - 51;
            }

            return howMuch;

        }

        //Funktion der udfører det at slå en brik hjem 
        public void bootOut(int where, PlayPiece[] pieces, string brik)
        {
            if (mayBootOut(where, pieces, brik))
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

        //Funktion der bestemmer hvem der er næst efter normal stil altså i ur retning
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

        //Funktion der undersøger om spilleren stadig har nogle som ikke er på brættet altså state = move
        public bool isAnyStillOut(int tal, PlayPiece[] pieces)
        {
            bool yes = false;

            foreach (PlayPiece p in pieces)
            {
                if (p.color.ToString().Substring(0, 1) == player[tal].colorChoise.ToString().Substring(0, 1))
                {
                    if (p.state == LudoHelper.state.ude)
                    {
                        yes = true;
                        break;
                    }
                    else
                    {
                        yes = false;
                    }
                }
            }

            return yes;
        }

        //Funktion der kontrollere om spilleren har andre på brættet med state = move
        public bool isAnyStillMove(int tal, PlayPiece[] pieces, string brikNr)
        {
            bool yes = false;

            foreach (PlayPiece p in pieces)
            {
                if (p.color.ToString().Substring(0, 1) == player[tal].colorChoise.ToString().Substring(0, 1) && p.brikNr != brikNr)
                {
                    if (p.state == LudoHelper.state.move)
                    {
                        yes = true;
                        break;
                    }
                    else
                    {
                        yes = false;
                    }
                }
            }

            return yes;
        }


        //Funktion der laver en Commodore 64 like start screen
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

