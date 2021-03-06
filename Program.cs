using System;

namespace stableFlight
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int testsCount = int.Parse(Console.ReadLine());
                string vC;
                int valuesCount;
                int differenceValue;
                string valuesStr;
                int[] values;
                int longestStableInterval;
                int stableInterval = 0;
                

                for (int i = 0; i < testsCount; i++)
                {
                    //values count and difference constant getting
                    vC = Console.ReadLine();
                    valuesCount = int.Parse(vC.Split(' ')[0]);
                    differenceValue = int.Parse(vC.Split(' ')[1]);

                    //Input validation 
                    if (valuesCount < 5 || valuesCount > 1000000 || differenceValue < 3 || differenceValue > 1000) crash();
        
                    //values read
                    valuesStr = Console.ReadLine();

                    //initialise the length of the array with heigh values
                    values = new int[valuesCount];

                    //making the longest stable interval zero for the next test
                    longestStableInterval = 0;

                    for (int j = 0; j < valuesCount; j++ )
                    {
                        values[j] = int.Parse(valuesStr.Split(' ')[j]);
                        //input validation 1
                        if (values[j] <= 0 || values[j] > 10000) crash();
                    }
                    //finding stable intervals

                    //wallking through the first step
                    for (int k = 0; k < valuesCount - 1; k++)
                    {
                        //finding the next
                        for (int t = 1; t < (valuesCount - k) ; t++){                         
                            if(Math.Abs(values[k] - values[k+t]) <= differenceValue && Math.Abs(values[k+t] - values[k+1]) <= differenceValue) 
                            {
                                stableInterval = 1;
                                //checking the middle values 
                                for (int n = k+1; n <= k+t; n++)
                                {
                                    if (Math.Abs(values[n] - values[k+t]) <= differenceValue) stableInterval++;
                                    else break;
                                }
                            }
                            else break;
                        }
                        //Checking if the last found interval is the longest
                        if (stableInterval > longestStableInterval) longestStableInterval = stableInterval;
                    }
                    Console.WriteLine(longestStableInterval);
                }


            }

            catch
            {
                crash();
            }
        }

        //what to do when wrong input
        public static void crash()
        {
            Console.WriteLine("Sorry, wrong input.");
            Environment.Exit(0);
        }
    }
}
