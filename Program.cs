﻿

class Program 
{
    static void Main()
    {
       
    }
    static void DisplayMenu()
    {
        Console.WriteLine("=============================================\r\n" +
                          "Welcome to Changi Airport Terminal 5\r\n" +
                          "=============================================" +
                          "\r\n1. List All Flights" +
                          "\r\n2. List Boarding Gates" +
                          "\r\n3. Assign a Boarding Gate to a Flight" +
                          "\r\n4. Create Flight\r\n5. Display Airline Flights" +
                          "\r\n6. Modify Flight Details\r\n7. Display Flight Schedule" +
                          "\r\n0. Exit" +
                          "\r\nPlease select your option");
        Console.ReadLine();
    }
}