using System.Globalization;
using ConsoleApp1.Exceptions;
using ConsoleApp1.Parser.Interfaces;

namespace ConsoleApp1.Parser.Implementations;

public class CommandParser : ICommandParser
{
    public ICommandResult Parse(string input)
    {
        if (string.IsNullOrEmpty(input))
            throw new NoSuchCommandException("Empty input!\nUsage: <command> <arguments>");

        var parts = input
            .Split(' ')
            .ToList();

        IList<string> args = new List<string>();
        string command;

        switch (parts[0])
        {
            case "userlogin":
                if (parts.Count != 3)
                    throw new WrongCommandUsageException("Usage: login <bank account number> <pin code>");

                command = "login";
                try
                {
                    long acc = long.Parse(parts[1], CultureInfo.InvariantCulture);
                    short pin = short.Parse(parts[2], CultureInfo.InvariantCulture);
                }
                catch (FormatException)
                {
                    throw new WrongCommandUsageException(
                        "Wrong bank account or pin\nUsage: login <bank account number> <pin code>");
                }

                args.Add(parts[1]);
                args.Add(parts[2]);
                break;

            case "adminlogin":
                if (parts.Count != 3)
                    throw new WrongCommandUsageException("Usage: adminlogin <system name> <password>");

                command = "adminlogin";
                try
                {
                    long acc = long.Parse(parts[1], CultureInfo.InvariantCulture);
                    short pin = short.Parse(parts[2], CultureInfo.InvariantCulture);
                }
                catch (FormatException)
                {
                    throw new WrongCommandUsageException(
                        "Wrong bank system name or password\nUsage: adminlogin <system name> <password>");
                }

                args.Add(parts[1]);
                args.Add(parts[2]);
                break;

            case "createuser":
                command = "createuser";
                if (parts.Count != 3)
                    throw new WrongCommandUsageException("Usage: createuser <name> <last name>");

                args.Add(parts[1]);
                args.Add(parts[2]);
                break;

            case "createadmin":
                if (parts.Count != 5)
                    throw new WrongCommandUsageException("Usage: createadmin <system name> <password>");

                command = "createadmin";
                args.Add(parts[1]);
                args.Add(parts[2]);
                args.Add(parts[3]);
                args.Add(parts[4]);
                break;

            // user area
            case "amount":
                command = "createadmin";
                break;

            case "withdraw":
                command = "withdraw";
                break;

            case "refill":
                command = "refill";
                break;

            case "history":
                command = "history";
                break;

            // admin area
            case "wdfrom":
                if (parts.Count != 3)
                    throw new WrongCommandUsageException("Usage: wdfrom <bank account number> <amount>");

                command = "wdfrom";
                try
                {
                    long acc = long.Parse(parts[1], CultureInfo.InvariantCulture);
                    short amount = short.Parse(parts[2], CultureInfo.InvariantCulture);
                }
                catch (FormatException)
                {
                    throw new WrongCommandUsageException(
                        "Wrong bank account or amount\nUsage: wdfrom <bank account number> <amount>");
                }

                args.Add(parts[1]);
                args.Add(parts[2]);
                break;

            case "histof":
                if (parts.Count != 2)
                    throw new WrongCommandUsageException("Usage: histof <bank account number>");

                command = "histof";
                try
                {
                    long acc = long.Parse(parts[1], CultureInfo.InvariantCulture);
                }
                catch (FormatException)
                {
                    throw new WrongCommandUsageException(
                        "Wrong bank account\nUsage: histof <bank account number>");
                }

                args.Add(parts[1]);
                break;

            case "rfto":
                if (parts.Count != 3)
                    throw new WrongCommandUsageException("Usage: rfto <bank account number>");

                command = "rfto";
                try
                {
                    long acc = long.Parse(parts[1], CultureInfo.InvariantCulture);
                }
                catch (FormatException)
                {
                    throw new WrongCommandUsageException(
                        "Wrong bank account\nUsage: rfto <bank account number>");
                }

                args.Add(parts[1]);
                args.Add(parts[2]);
                break;

            case "amtof":
                if (parts.Count != 2)
                    throw new WrongCommandUsageException("Usage: amtof <bank account number>");

                command = "amtof";
                try
                {
                    long acc = long.Parse(parts[1], CultureInfo.InvariantCulture);
                }
                catch (FormatException)
                {
                    throw new WrongCommandUsageException(
                        "Wrong bank account\nUsage: amtof <bank account number>");
                }

                args.Add(parts[1]);
                break;

            default: throw new NoSuchCommandException(
                "Command list:\n\tuserlogin\n\tcreateuser\n" +
                "\tamount\n\twithdraw\n\trefill\n\thistory");
        }

        return new CommandResult(command, args);
    }
}