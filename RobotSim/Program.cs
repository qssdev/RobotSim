using System;
using System.IO;
using System.Linq;

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
                commands = File.ReadAllLines(commandFile).Where(x => x.Length > 0).ToArray();
                if (commands.Count() > 0)
                {
                    foreach (var command in commands)
                    {
                        if (command.ToUpper().StartsWith("PLACE"))
                        {
                            int x,y;
                            string face;

                            var commandData = command.Split();
                            try
                            {
                                var parammeter = commandData[1].Split(new char[] { ',' }, 3);
                                int.TryParse(parammeter[0], out x);
                                int.TryParse(parammeter[1], out y);
                                face = parammeter[2];

                                currentRobot = board.Place(new Location(x, y, face));
                            }
                            catch (Exception ex)
                            {
                                //ignore the error proceed to the next command
                                currentRobot = null;
                            }
                        }
                        else if (command.ToUpper() == "LEFT")
                        {
                            currentRobot?.Left();
                        }
                        else if (command.ToUpper() == "RIGHT")
                        {
                            currentRobot?.Right();
                        }
                        else if (command.ToUpper() == "REPORT")
                        {
                            currentRobot?.Report();
                        }
                        else if (command.ToUpper() == "MOVE")
                        {
                            currentRobot?.Move();
                        }
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
