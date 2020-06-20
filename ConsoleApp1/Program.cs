using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservations
{
    class Program
    {
        static void Main(string[] args)
        {
            //Entering size of the hotel
            int size;
            Console.WriteLine("Insert size of the hotel you want to make reservations in: ");
            size =Convert.ToInt32(Console.ReadLine());
            if (size < 1) { Console.WriteLine("Invalid size"); }

            // Making table(matrix) of Rooms and Dates, free dates are given "0" value, occupied "1"
            int[,] Hotel = new int[size, 365];

            for(int i = 0; i<= size-1; i++)
            {
                for(int j=0; j<=364; j++)
                {
                    Hotel[i, j] = 0;
                }
            }

            Console.WriteLine("Plese enter your booking dates");
            // When we decide to start the reservation process for the new hotel or start from beggining
            // we type "no" in console and end the program execution
            string R1 = "yes";
            while (R1 != "no")
            {
                Console.WriteLine("Plese enter the start date of your reservation");   
                int startDate = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Plese enter the end date of your reservation");
                int endDate = Convert.ToInt32(Console.ReadLine());


            //If we enter invalid dates reservation is automatically declined
                if ((startDate < 0) | (endDate > 364)) { Console.WriteLine("Decline"); }
                else
                {
             //For the requested dates we use array of "1"       
                    int[] Arr1 = new int[endDate - startDate + 1];
                    for (int i = startDate; i <= endDate; i++)
                    {
                        Arr1[i - startDate] = 1;
                    }
             //With the help of "for" loop we go through rooms(variable i), dates(variable j) and compare values      
                    for (int i = 0; i <= size - 1; i++)
                    {
                        bool Booked = false;
                        for(int j=startDate; j <= endDate; j++)
                        {
                            if(Hotel[i, j] == 1) { Booked = true; break; }
                        }
             //If room is not booked we reserve the dates and break the loop in order to start new reservation           
                        if (!Booked)
                        {
                            for (int j = startDate; j <= endDate; j++)
                            {
                                Hotel[i, j] = 1;
                            }
                            Console.WriteLine("Accept");
                            break;
                        }
             //If requested dates are not available for all of the existing rooms, we decline the reservation
                        else if (i == (size - 1)) { Console.WriteLine("Decline"); }
                    }

                }
             //If we type "no" in console we can start the program again, we do this for every "Test Case"
                Console.WriteLine("If you want to stop making reservations type: no");
                R1 = Console.ReadLine();
            }
            
        }

    }
}

