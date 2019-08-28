using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILudo
{
    class Control
    {
        public int testBrugerTal(string ind)
        {
            int sum = 0;
            if (int.TryParse(ind, out sum)) { }
            else
            {
                //Console.WriteLine("Du skal skrive det i et tal");
                sum = testBrugerTal(Console.ReadLine());
            }

            return sum;
        }

        public string testBrugerBrikInd(string ind)
        {
            string brikFarve = ind.Substring(0, 1).ToLower();
            int brikNr = testBrugerTal(ind.Substring(1, 1));

            if (brikFarve != "g" && brikFarve != "b" && brikFarve != "y" && brikFarve != "r")
            {
                //Console.Write("Du har ikke taste det rigtige bogstav til din brik tryk det ind igen: ");
                brikFarve = testBrugerBrikInd(ind);
            }
            else if (brikNr < 1 && brikNr > 4)
            {
                //Console.WriteLine("Det skal være et tal mellem 1 og 4");
                brikNr = testBrugerTal(ind);
                ind = brikFarve + brikNr;
                ind = testBrugerBrikInd(ind);
            }
            else
            {
                ind = brikFarve + brikNr;
            }

            return ind;
        }


        public Player[] sortArray(Player[] array)
        {
            Player temp;

            //Gå fra 0 to array length 
            for (int i = 0; i < array.Length - 1; i++)
            {
                //Gå fra i+1 to array length 
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i].playerNr > array[j].playerNr)
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
            return array;


        }
        public LudoHelper.color[] unsortArray(LudoHelper.color[] uArray)
        {
            Random rand = new Random();

            // Shuffle the array
            for (int i = 0; i < uArray.Length; ++i)
            {
                int index = rand.Next(uArray.Length);
                LudoHelper.color temp = uArray[index];
                uArray[index] = uArray[i];
                uArray[i] = temp;
            }
            return uArray;
        }
    }
}
