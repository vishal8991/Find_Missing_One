using System;

namespace Blanknetapp
{
    class Program
    {
        static void Main(string[] args)
        {
            int n=0;
            Console.Write("Enter Size(Must be positive integer greater than 1): ");
            try
            {
                n = Convert.ToInt32(Console.ReadLine());
                if(n <=1)
                {
                    Console.WriteLine("Size must be greater than 1!!");
					Console.WriteLine("\nPress any key to exit...");
					Console.ReadKey();
                    return; 
                }
            }
            catch(Exception ex)
            {
                //Console.WriteLine("Invalid Input or " + ex.Message);
                Console.WriteLine("Size must be an integer value or "+ex.Message+"!!");
				Console.WriteLine("\n\nPress any key to exit...");
				Console.ReadKey();
                return;
            }
            Console.WriteLine("Great!!\nNow enter "+(n-1)+" unique integer numbers & numbers must be b/w 1-"+n+":");
            int[] input = new int[n-1];
            string numberStr = Console.ReadLine();
            string[] str = numberStr.Split(' ', n-1); 
            if(str.Length < n-1)
            {
                Console.WriteLine("Please enter valid input or input must be between 1-"+n+"!!");
				Console.WriteLine("\n\nPress any key to exit...");
				Console.ReadKey();
                return;
            }
            try
            {
                input = Array.ConvertAll(str, int.Parse);
            }
			catch(Exception ex)
            {
                Console.WriteLine("Please check your input, input size or " + ex.Message);
				Console.WriteLine("\n\nPress any key to exit...");
				Console.ReadKey();
                return;
            }
            for (int i = 0; i < n-1; i++)
            {
                if(input[i] > n || input[i] <=0)
                {
                    
                    Console.WriteLine("Please enter valid input or input must be between 1-"+n+"!!");
					Console.WriteLine("\nPress any key to exit...");
					Console.ReadKey();
                    return;
                }
                for (int j = 1; j < n-1; j++)
                {
                    if(i == j)
                    {
                        continue;
                    }
                    if(input[i] == input[j])
                    {
                        Console.WriteLine("Oh no!! input must be unique in between 1-"+n+"!!");
                        Console.WriteLine("You repeated "+input[i]+" multiple times!!");
						Console.WriteLine("\n\nPress any key to exit...");
						Console.ReadKey();
                        return;
                    }
                }
                //Console.WriteLine("input["+i+"] = "+str[i]);    
            }
            int missingNumber = findMissingNum(input);
            Console.WriteLine("Ahhha!! you definitely missed " + missingNumber);  
			Console.WriteLine("\n\n\nPress any key to exit...");
			Console.ReadKey();
        }
        static int findMissingNum(int[] numInput)
        {
            int missingNum = 0;
            bool isNumMiss = false;
            for (int i = 1; i <= numInput.Length+1; i++)
            {
                for (int j = 0; j < numInput.Length; j++)
                {
                     //Console.WriteLine("numInput["+i+"] = "+numInput[i]);
                    if(i == numInput[j])
                    {
                        isNumMiss = false;
                        break;
                        
                    }
                    else
                    {
                        isNumMiss = true;
                    }
                }
                if(isNumMiss)
                {
                    missingNum = i;
                    break;
                }
            }
            return missingNum;
        }
    }
}
