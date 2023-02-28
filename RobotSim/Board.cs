using System;
using System.Collections.Generic;

namespace RobotSim
{
    public class Board
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public List<Robot> Robots { get; set; }

        public Board(int widthParam, int heightParam)
        {
            Width = widthParam;
            Height = heightParam;
            Robots = new List<Robot>();
        }

        public Robot Place(Location location) {
            var robot = new Robot();

            if (robot.X + location.X > this.Width - 1 || robot.Y + location.Y > this.Height - 1)
            {
                return null;
            }

            robot.X = location.X;
            robot.Y = location.Y;
            robot.Facing = location.Facing.ToUpper();
            robot.IsOnTheBoard = true;
            robot.BoardWidth = this.Width -1;
            robot.BoardHeight = this.Height - 1;

            Robots.Add(robot);
            Console.WriteLine($"PLACE {robot.X}, {robot.Y}, {robot.Facing}");
            return robot;
        }

    }
}
