public class ViewAssignmentsCommand : Command
{
    Catalogue _catalogue = new Catalogue();

    public ViewAssignmentsCommand(Catalogue catalogue)
    {
        _catalogue = catalogue;
    }
    public override void Execute()
    {
        _catalogue.RankAllAssignments();
        Console.WriteLine("RANK|POINTS|ASSIGNMENT NAME                    |DUE DATE   |PRIORITY");
        Console.WriteLine("--------------------------------------------------------------------");
        int rank = 0;
        foreach (Assignment assignment in _catalogue.GetAllAssignments())
        {
            rank += 1;
            string finalString = "";
            finalString += CreateFixedLengthString(rank.ToString(), 4) + "|";
            finalString += CreateFixedLengthString(assignment.GetPoints().ToString(), 6) + "|";
            finalString += CreateFixedLengthString(assignment.GetName(), 35) + "|";
            finalString += CreateFixedLengthString(assignment.GetDueDate().Date.ToString("yyyy-MM-dd"), 11) + "|";
            if (assignment.GetIsOverdue() == true)
            {
                finalString += "OVERDUE";
            }
            else
            {
                double assignmentRank = assignment.GetRank();
                assignmentRank = Math.Round(assignmentRank, 2);
                finalString += assignmentRank.ToString();
            }
            Console.WriteLine(finalString);
        }
        return;
    }

    private string CreateFixedLengthString(string input, int length)
    {
        string returnedString = "";
        if (input.Length == length)
        {
            return input;
        }
        else if (input.Length < length)
        {
            returnedString = input;
            while (returnedString.Length < length)
            {
                returnedString += " ";
            }
            return returnedString;
        }
        else if (input.Length > length)
        {
            returnedString = input.Substring(0, length - 3);
            returnedString += "...";
            return returnedString;
        }

        throw new Exception($"ViewAssignmentsCommand.CreateFixedLengthString: Could not parse input string length of {input}");
    }

}