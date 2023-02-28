using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSim
{

    public class Program
    {
        static readonly string commandFile = "commands.txt";
        static void Main(string[] args)
        {
            string[] commands= new string[0];
            Board board = new Board(5, 5);
            Robot currentRobot = new Robot();

            if (File.Exists(commandFile))
            {
                commands = File.ReadAllLines(commandFile);
                if (commands.Count() > 0)
                {
                    foreach (var command in commands)
                    {
                        if (command.ToUpper().StartsWith("PLACE"))
                        {
                            int x;
                            int y;
                            string face;

                            var commandData = command.Split();
                            var parammeter = commandData[1].Split(new char[] { ',' }, 3);

                            int.TryParse(parammeter[0], out x);
                            int.TryParse(parammeter[1], out y);
                            face = parammeter[2];

                            board.Place(new Location(x, y, face));
                            currentRobot = board.Robots.LastOrDefault();

                        }
                        else if (command.ToUpper() == "LEFT")
                        {
                            currentRobot.Left();
                        }
                        else if (command.ToUpper() == "RIGHT")
                        {
                            currentRobot.Right();
                        }
                        else if (command.ToUpper() == "REPORT")
                        {
                            Console.WriteLine(currentRobot.Report());
                        }
                        else if (command.ToUpper() == "MOVE")
                        {
                            currentRobot.Move();
                        }
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
