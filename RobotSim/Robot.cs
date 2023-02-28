namespace RobotSim
{
    public class Robot : Location
    {
        public bool IsOnTheBoard { get; set; }
        public int BoardWidth { get; set; }
        public int BoardHeight { get; set; }

        public Robot() : base(0, 0, "NORTH")
        {
        }

        public void Left()
        {
            if (IsOnTheBoard)
            {
                switch (Facing)
                {
                    case "NORTH":
                        this.Facing = "WEST";
                        break;
                    case "WEST":
                        this.Facing = "SOUTH";
                        break;
                    case "SOUTH":
                        this.Facing = "EAST";
                        break;
                    case "EAST":
                        this.Facing = "NORTH";
                        break;
                    default:
                        break;
                }
            }
        }

        public void Right()
        {
            if (IsOnTheBoard)
            {
                switch (Facing)
                {
                    case "NORTH":
                        this.Facing = "EAST";
                        break;
                    case "EAST":
                        this.Facing = "SOUTH";
                        break;
                    case "SOUTH":
                        this.Facing = "WEST";
                        break;
                    case "WEST":
                        this.Facing = "NORTH";
                        break;
                    default:
                        break;
                }
            }
        }

        public void Move()
        {
            if (!TryMoveSuccess()) return;

            switch (Facing)
            {
                case "NORTH":
                    Y++;
                    break;
                case "SOUTH":
                    Y--;
                    break;
                case "EAST":
                    X++;
                    break;
                case "WEST":
                    X--;
                    break;
                default:
                    break;
            }
        }

        private bool TryMoveSuccess() 
        {
            if (!IsOnTheBoard) return false;
            
            if ((this.Facing == "WEST" || this.Facing == "SOUTH") && (X == 0 || Y == 0))
            {
                return false;
            }
            if ((this.Facing == "NORTH" || this.Facing == "EAST") && (X >= BoardWidth || Y >= BoardHeight))
            {
                return false;
            }
            return true;
        }

        public string Report()
        {
            if (!IsOnTheBoard)
            {
                return "Invalid command";
            }

            return $"{X},{Y},{Facing}";
        }

    }
}
