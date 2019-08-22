using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;

namespace testarea
{
    class Dice
    {
        public int sides { get; set; }
        public Random rand = new Random();

        public Dice(int sides)
        {
            this.sides = sides;
        }

        public int rollMultipleSidedDice()
        {

            int number = rand.Next(1, sides);
            return number;
        }

        // Funktion der laver en seks sidet terning
        public int roll_D6Dice()
        {
            
            int number = rand.Next(1, 7);

            return number;
        }

        // Funktion der ændrer en 6 sidet terning til at have stjerne og globus i stedet for 3 og 5
        public string ludo_dice()
        {
            string result = "";
            result = roll_D6Dice().ToString();
            if (result == "3")
            {
                result = "globe";
            }
            else if (result == "5")
            {
                result = "star";
            }

            return result;
        }

        //Funktionen giver dig unikke tal men randomiseret blandt alle de mulige
        public int[] getRandomNR (int low, int high)
        {
            var nums = Enumerable.Range(low, high).ToArray();
            var rnd = new Random();

            // Shuffle arrayet
            for (int i = 0; i < nums.Length; ++i)
            {
                int randomIndex = rnd.Next(nums.Length);
                int temp = nums[randomIndex];
                nums[randomIndex] = nums[i];
                nums[i] = temp;
            }

            return nums;
        }
    }
}
