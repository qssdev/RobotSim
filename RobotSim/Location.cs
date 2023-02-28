namespace RobotSim
{
    public class Location
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Facing { get; set; }

        public Location(int xParam, int yParam, string faceParam)
        {
            X = xParam;
            Y = yParam;
            Facing = faceParam.ToUpper();
        }
    }
}
