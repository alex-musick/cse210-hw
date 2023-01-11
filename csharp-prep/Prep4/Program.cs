using System;

class Program
{
    static void Main(string[] args)
    {
        string userNumber;
        List<int> userList = new List<int>();
        do {
            Console.Write("Enter a list of numbers one at a time, or type '0' when finished. ");
            userNumber = Console.ReadLine();
            int userInt = int.Parse(userNumber);
            if (userInt != 0)
            {
                userList.Add(userInt);
            }
        } while (userNumber != "0");

        Console.WriteLine($"The sum is: {userList.Sum()}");
        Console.WriteLine($"The average is: {userList.Sum() / userList.Count}");
        Console.WriteLine($"The highest number is: {userList.Max()}");

        int smallestPositive = userList.Max();
        foreach (int number in userList)
        {
            if (number > 0 && number < smallestPositive)
            {
                smallestPositive = number;
            }
        }
        if (smallestPositive <= 0)
        {
            Console.WriteLine("There are no positive numbers.");
        }
        else
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }

        Console.WriteLine("The sorted list is:");
        userList.Sort();
        foreach (int number in userList)
        {
            Console.WriteLine(number);
        }
    }
}