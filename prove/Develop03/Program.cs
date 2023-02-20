using System;
namespace DeserializeExtra

// I've shown creativity by allowing the user to practice any scripture in the standard works while only needing to provide the reference information,
//  rather than needing to type the whole thing manually or add it to a text file.
{
    class Program
    {
        static void Main(string[] args)
        {
            Interface programInterface = new Interface();

            while (true)
            {
                programInterface.Menu();
            }
        }
    }
}