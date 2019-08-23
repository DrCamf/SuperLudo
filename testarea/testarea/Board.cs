using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace testarea
{
    class Board
    {
        public Dictionary<Point, LudoBoardField> ludoBoard { get; private set; }
        public PlayPiece playPiece { get; set; }
        public LudoBoardField luFeld { get; set; }

        public Board()
        {
           

        }
        

        //Board i et Array
        public LudoBoardField[] makeBoard()
        {
            LudoBoardField[] lb = new LudoBoardField[52];

            for (int i = 0; i <= lb.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        lb[i] = new LudoBoardField(new Point(0, 6), LudoHelper.type.normal);
                        break;
                    case 1:
                        lb[i] = new LudoBoardField(new Point(1, 6), LudoHelper.type.greenstart);
                        break;
                    case 2:
                        lb[i] = new LudoBoardField(new Point(2, 6), LudoHelper.type.normal);
                        break;
                    case 3:
                        new LudoBoardField(new Point(3, 6), LudoHelper.type.normal);
                        break;
                    case 4:
                        new LudoBoardField(new Point(4, 6), LudoHelper.type.normal);
                        break;
                    case 5:
                        new LudoBoardField(new Point(5, 6), LudoHelper.type.normal);
                        break;
                    case 6:
                        new LudoBoardField(new Point(6, 5), LudoHelper.type.star);
                        break;
                    case 7:
                        new LudoBoardField(new Point(6, 4), LudoHelper.type.normal);
                        break;
                    case 8:
                        new LudoBoardField(new Point(6, 3), LudoHelper.type.normal);
                        break;
                    case 9:
                        new LudoBoardField(new Point(6, 2), LudoHelper.type.globe);
                        break;
                    case 10:
                        new LudoBoardField(new Point(6, 1), LudoHelper.type.normal);
                        break;
                    case 11:
                        new LudoBoardField(new Point(6, 0), LudoHelper.type.normal);
                        break;
                    case 12:
                        lb[i] = new LudoBoardField(new Point(7, 0), LudoHelper.type.bluegoal);
                        break;
                    case 13:
                        new LudoBoardField(new Point(8, 0), LudoHelper.type.normal);
                        break;
                    case 14:
                        lb[i] = new LudoBoardField(new Point(8, 1), LudoHelper.type.bluestart);
                        break;
                    case 15:
                        new LudoBoardField(new Point(8, 2), LudoHelper.type.normal);
                        break;
                    case 16:
                        new LudoBoardField(new Point(8, 3), LudoHelper.type.normal);
                        break;
                    case 17:
                        new LudoBoardField(new Point(8, 4), LudoHelper.type.normal);
                        break;
                    case 18:
                        new LudoBoardField(new Point(8, 5), LudoHelper.type.normal);
                        break;
                    case 19:
                        new LudoBoardField(new Point(9, 6), LudoHelper.type.star);
                        break;
                    case 20:
                        new LudoBoardField(new Point(10, 6), LudoHelper.type.normal);
                        break;
                    case 21:
                        new LudoBoardField(new Point(11, 6), LudoHelper.type.normal);
                        break;
                    case 22:
                        new LudoBoardField(new Point(12, 6), LudoHelper.type.globe);
                        break;
                    case 23:
                        new LudoBoardField(new Point(13, 6), LudoHelper.type.normal);
                        break;
                    case 24:
                        new LudoBoardField(new Point(14, 6), LudoHelper.type.normal);
                        break;
                    case 25:
                        lb[i] = new LudoBoardField(new Point(14, 7), LudoHelper.type.yellowgoal);
                        break;
                    case 26:
                        new LudoBoardField(new Point(14, 8), LudoHelper.type.normal);
                        break;
                    case 27:
                        lb[i] = new LudoBoardField(new Point(13, 8), LudoHelper.type.yellowstart);
                        break;
                    case 28:
                        new LudoBoardField(new Point(12, 8), LudoHelper.type.normal);
                        break;
                    case 29:
                        new LudoBoardField(new Point(11, 8), LudoHelper.type.normal);
                        break;
                    case 30:
                        new LudoBoardField(new Point(10, 8), LudoHelper.type.normal);
                        break;
                    case 31:
                        new LudoBoardField(new Point(9, 8), LudoHelper.type.normal);
                        break;
                    case 32:
                        new LudoBoardField(new Point(8, 9), LudoHelper.type.star);
                        break;
                    case 33:
                        new LudoBoardField(new Point(8, 10), LudoHelper.type.normal);
                        break;
                    case 34:
                        new LudoBoardField(new Point(8, 11), LudoHelper.type.normal);
                        break;
                    case 35:
                        new LudoBoardField(new Point(8, 12), LudoHelper.type.globe);
                        break;
                    case 36:
                        new LudoBoardField(new Point(8, 13), LudoHelper.type.normal);
                        break;
                    case 37:
                        new LudoBoardField(new Point(8, 14), LudoHelper.type.normal);
                        break;
                    case 38:
                        lb[i] = new LudoBoardField(new Point(7, 14), LudoHelper.type.redgoal);
                        break;
                    case 39:
                        new LudoBoardField(new Point(7, 8), LudoHelper.type.normal);
                        break;
                    case 40:
                        lb[i] = new LudoBoardField(new Point(6, 13), LudoHelper.type.redstart);
                        break;
                    case 41:
                        new LudoBoardField(new Point(6, 12), LudoHelper.type.normal);
                        break;
                    case 42:
                        new LudoBoardField(new Point(6, 11), LudoHelper.type.normal);
                        break;
                    case 43:
                        new LudoBoardField(new Point(6, 10), LudoHelper.type.normal);
                        break;
                    case 44:
                        new LudoBoardField(new Point(6, 9), LudoHelper.type.normal);
                        break;
                    case 45:
                        new LudoBoardField(new Point(5, 8), LudoHelper.type.star);
                        break;
                    case 46:
                        new LudoBoardField(new Point(4, 8), LudoHelper.type.normal);
                        break;
                    case 47:
                        new LudoBoardField(new Point(3, 8), LudoHelper.type.normal);
                        break;
                    case 48:
                        new LudoBoardField(new Point(2, 8), LudoHelper.type.globe);
                        break;
                    case 49:
                        new LudoBoardField(new Point(1, 8), LudoHelper.type.normal);
                        break;
                    case 50:
                        new LudoBoardField(new Point(0, 8), LudoHelper.type.normal);
                        break;
                    case 51:
                        lb[i] = new LudoBoardField(new Point(0, 7), LudoHelper.type.greengoal);
                        break;
                }
            }

            return lb;


        }

        //Board i et Dictonary
        public Dictionary<Point, LudoBoardField> initializeBoard()
        {
            ludoBoard = new Dictionary<Point, LudoBoardField>();

            ludoBoard.Add(new Point(0, 6),
                new LudoBoardField(new Point(0, 6), LudoHelper.type.normal));
            ludoBoard.Add(new Point(1, 6),
                new LudoBoardField(new Point(1, 6), LudoHelper.type.globe));
            ludoBoard.Add(new Point(2, 6),
                new LudoBoardField(new Point(2, 6), LudoHelper.type.normal));
            ludoBoard.Add(new Point(3, 6),
                new LudoBoardField(new Point(3, 6), LudoHelper.type.normal));
            ludoBoard.Add(new Point(4, 6),
                new LudoBoardField(new Point(4, 6), LudoHelper.type.normal));
            ludoBoard.Add(new Point(5, 6),
                new LudoBoardField(new Point(5, 6), LudoHelper.type.normal));
            ludoBoard.Add(new Point(6, 5),
                new LudoBoardField(new Point(6, 5), LudoHelper.type.star));
            ludoBoard.Add(new Point(6, 4),
                new LudoBoardField(new Point(6, 4), LudoHelper.type.normal));
            ludoBoard.Add(new Point(6, 3),
                new LudoBoardField(new Point(6, 3), LudoHelper.type.normal));
            ludoBoard.Add(new Point(6, 2),
                new LudoBoardField(new Point(6, 2), LudoHelper.type.globe));
            ludoBoard.Add(new Point(6, 1),
               new LudoBoardField(new Point(6, 1), LudoHelper.type.normal));
            ludoBoard.Add(new Point(6, 0),
               new LudoBoardField(new Point(6, 0), LudoHelper.type.normal));
            ludoBoard.Add(new Point(7, 0),
               new LudoBoardField(new Point(7, 0), LudoHelper.type.star));
            //ludoBoardFeld.Add(new Point(7, 1),
            //   new LudoBoardField(new Point(7, 1), "yellowzone"));
            //ludoBoardFeld.Add(new Point(7, 2),
            //   new LudoBoardField(new Point(7, 2), "yellowzone"));
            //ludoBoardFeld.Add(new Point(7, 3),
            //   new LudoBoardField(new Point(7, 3), "yellowzone"));
            //ludoBoardFeld.Add(new Point(7, 4),
            //   new LudoBoardField(new Point(7, 4), "yellowzone"));
            //ludoBoardFeld.Add(new Point(7, 5),
            //   new LudoBoardField(new Point(7, 5), "yellowzone"));
            //ludoBoardFeld.Add(new Point(7, 6),
            //   new LudoBoardField(new Point(7, 6), "yellowgoal"));
            ludoBoard.Add(new Point(8, 0),
               new LudoBoardField(new Point(8, 0), LudoHelper.type.normal));
            ludoBoard.Add(new Point(8, 1),
               new LudoBoardField(new Point(8, 1), LudoHelper.type.globe));
            ludoBoard.Add(new Point(8, 2),
               new LudoBoardField(new Point(8, 2), LudoHelper.type.normal));
            ludoBoard.Add(new Point(8, 3),
               new LudoBoardField(new Point(8, 3), LudoHelper.type.normal));
            ludoBoard.Add(new Point(8, 4),
               new LudoBoardField(new Point(8, 4), LudoHelper.type.normal));
            ludoBoard.Add(new Point(8, 5),
               new LudoBoardField(new Point(8, 5), LudoHelper.type.normal));
            ludoBoard.Add(new Point(9, 6),
               new LudoBoardField(new Point(9, 6), LudoHelper.type.star));
            ludoBoard.Add(new Point(10, 6),
               new LudoBoardField(new Point(10, 6), LudoHelper.type.normal));
            ludoBoard.Add(new Point(11, 6),
               new LudoBoardField(new Point(11, 6), LudoHelper.type.normal));
            ludoBoard.Add(new Point(12, 6),
               new LudoBoardField(new Point(12, 6), LudoHelper.type.globe));
            ludoBoard.Add(new Point(13, 6),
               new LudoBoardField(new Point(13, 6), LudoHelper.type.normal));
            ludoBoard.Add(new Point(14, 6),
               new LudoBoardField(new Point(14, 6), LudoHelper.type.normal));
            ludoBoard.Add(new Point(14, 7),
               new LudoBoardField(new Point(14, 7), LudoHelper.type.star));
            //ludoBoardFeld.Add(new Point(13, 7),
            //   new LudoBoardField(new Point(13, 7), "bluezone"));
            //ludoBoardFeld.Add(new Point(12, 7),
            //   new LudoBoardField(new Point(12, 7), "bluezone"));
            //ludoBoardFeld.Add(new Point(11, 7),
            //   new LudoBoardField(new Point(11, 7), "bluezone"));
            //ludoBoardFeld.Add(new Point(10, 7),
            //   new LudoBoardField(new Point(10, 7), "bluezone"));
            //ludoBoardFeld.Add(new Point(9, 7),
            //   new LudoBoardField(new Point(9, 7), "bluezone"));
            //ludoBoardFeld.Add(new Point(8, 7),
            //   new LudoBoardField(new Point(8, 7), "bluegoal"));
            ludoBoard.Add(new Point(14, 8),
               new LudoBoardField(new Point(14, 8), LudoHelper.type.normal));
            ludoBoard.Add(new Point(13, 8),
               new LudoBoardField(new Point(13, 8), LudoHelper.type.globe));
            ludoBoard.Add(new Point(12, 8),
               new LudoBoardField(new Point(12, 8), LudoHelper.type.normal));
            ludoBoard.Add(new Point(11, 8),
               new LudoBoardField(new Point(11, 8), LudoHelper.type.normal));
            ludoBoard.Add(new Point(10, 8),
               new LudoBoardField(new Point(10, 8), LudoHelper.type.normal));
            ludoBoard.Add(new Point(9, 8),
               new LudoBoardField(new Point(9, 8), LudoHelper.type.normal));
            ludoBoard.Add(new Point(8, 9),
               new LudoBoardField(new Point(8, 9), LudoHelper.type.star));
            ludoBoard.Add(new Point(8, 10),
               new LudoBoardField(new Point(8, 10), LudoHelper.type.normal));
            ludoBoard.Add(new Point(8, 11),
               new LudoBoardField(new Point(8, 11), LudoHelper.type.normal));
            ludoBoard.Add(new Point(8, 12),
               new LudoBoardField(new Point(8, 12), LudoHelper.type.globe));
            ludoBoard.Add(new Point(8, 13),
               new LudoBoardField(new Point(8, 13), LudoHelper.type.normal));
            ludoBoard.Add(new Point(8, 14),
               new LudoBoardField(new Point(8, 14), LudoHelper.type.normal));
            ludoBoard.Add(new Point(7, 14),
               new LudoBoardField(new Point(7, 14), LudoHelper.type.star));
            //ludoBoardFeld.Add(new Point(7, 13),
            //   new LudoBoardField(new Point(7, 13), "redzone"));
            //ludoBoardFeld.Add(new Point(7, 12),
            //   new LudoBoardField(new Point(7, 12), "redzone"));
            //ludoBoardFeld.Add(new Point(7, 11),
            //   new LudoBoardField(new Point(7, 11), "redzone"));
            //ludoBoardFeld.Add(new Point(7, 10),
            //   new LudoBoardField(new Point(7, 10), "redzone"));
            //ludoBoardFeld.Add(new Point(7, 9),
            //   new LudoBoardField(new Point(7, 9), "redzone"));
            //ludoBoardFeld.Add(new Point(7, 8),
            //   new LudoBoardField(new Point(7, 8), "redgoal"));
            ludoBoard.Add(new Point(6, 14),
               new LudoBoardField(new Point(7, 8), LudoHelper.type.normal));
            ludoBoard.Add(new Point(6, 13),
              new LudoBoardField(new Point(6, 13), LudoHelper.type.globe));
            ludoBoard.Add(new Point(6, 12),
              new LudoBoardField(new Point(6, 12), LudoHelper.type.normal));
            ludoBoard.Add(new Point(6, 11),
             new LudoBoardField(new Point(6, 11), LudoHelper.type.normal));
            ludoBoard.Add(new Point(6, 10),
             new LudoBoardField(new Point(6, 10), LudoHelper.type.normal));
            ludoBoard.Add(new Point(6, 9),
             new LudoBoardField(new Point(6, 9), LudoHelper.type.normal));
            ludoBoard.Add(new Point(5, 8),
             new LudoBoardField(new Point(5, 8), LudoHelper.type.star));
            ludoBoard.Add(new Point(4, 8),
             new LudoBoardField(new Point(4, 8), LudoHelper.type.normal));
            ludoBoard.Add(new Point(3, 8),
             new LudoBoardField(new Point(3, 8), LudoHelper.type.normal));
            ludoBoard.Add(new Point(2, 8),
             new LudoBoardField(new Point(2, 8), LudoHelper.type.globe));
            ludoBoard.Add(new Point(1, 8),
             new LudoBoardField(new Point(1, 8), LudoHelper.type.normal));
            ludoBoard.Add(new Point(0, 8),
             new LudoBoardField(new Point(0, 8), LudoHelper.type.normal));
            ludoBoard.Add(new Point(0, 7),
             new LudoBoardField(new Point(0, 7), LudoHelper.type.star));
            //ludoBoardFeld.Add(new Point(1, 7),
            // new LudoBoardField(new Point(1, 7), "greenzone"));
            //ludoBoardFeld.Add(new Point(2, 7),
            // new LudoBoardField(new Point(2, 7), "greenzone"));
            //ludoBoardFeld.Add(new Point(3, 7),
            // new LudoBoardField(new Point(3, 7), "greenzone"));
            //ludoBoardFeld.Add(new Point(4, 7),
            // new LudoBoardField(new Point(4, 7), "greenzone"));
            //ludoBoardFeld.Add(new Point(5, 7),
            // new LudoBoardField(new Point(5, 7), "greenzone"));
            //ludoBoardFeld.Add(new Point(6, 7),
            // new LudoBoardField(new Point(6, 7), "greengoal"));

            return ludoBoard;

        }

        public PlayPiece[] createLudoPieces()
        {
            
            PlayPiece[] pPiece = new PlayPiece[16];

            //Point[] startPoint = { new Point(1, 4), new Point(2, 4), new Point(1, 5), new Point(2, 5), new Point(9, 1), new Point(9, 2), new Point(10, 1), new Point(10, 2), new Point(12, 9), new Point(13, 9), new Point(12, 10), new Point(13, 10), new Point(4, 12), new Point(5, 12), new Point(4, 13), new Point(5, 13) };
            string[] state = new string[3];

            for (int i = 0; i <= pPiece.Length; i++)
            {
                if (i < 4)
                {
                    pPiece[i] = new PlayPiece(LudoHelper.color.green, 1, LudoHelper.state.ude, false, "g" + (i+1));
                }
                else if (i > 3 && i < 8)
                {
                    pPiece[i] = new PlayPiece(LudoHelper.color.blue, 14, LudoHelper.state.ude, false, "b" + (i-3));
                }
                else if (i > 7 && i < 12)
                {
                    pPiece[i] = new PlayPiece(LudoHelper.color.yellow, 27, LudoHelper.state.ude, false, "y" + (i-7));
                }
                else if (i > 11 && i < 16)
                {
                    pPiece[i] = new PlayPiece(LudoHelper.color.red, 40, LudoHelper.state.ude, false, "r" + (i-11));
                }
            }

            return pPiece;
        }

        //public bool mayMoveIntoZone(Point brikP, string color)
        //{
        //    bool mayMoveIntoGoalZone = false;

        //    if (brikP == new Point(7, 0) && color == "g")
        //    {
        //        mayMoveIntoGoalZone = true;
        //    }
        //    else if (brikP == new Point(14, 7) && color == "y")
        //    {
        //        mayMoveIntoGoalZone = true;
        //    }
        //    else if (brikP == new Point(7, 14) && color == "b")
        //    {
        //        mayMoveIntoGoalZone = true;
        //    }
        //    else if (brikP == new Point(0, 7) && color == "r")
        //    {
        //        mayMoveIntoGoalZone = true;
        //    }

        //    return mayMoveIntoGoalZone;
        //}

        public Point moveOut(string color)
        {
            Point brikPoint = new Point(1, 6);

            if (color == "green")
            {
                brikPoint = new Point(1, 6);
            }
            else if (color == "yellow")
            {
                brikPoint = new Point(8, 1);
            }
            else if (color == "blue")
            {
                brikPoint = new Point(13, 8);
            }
            else if (color == "red")
            {
                brikPoint = new Point(6, 13);
            }

            return brikPoint;
        }

        


    }
}
