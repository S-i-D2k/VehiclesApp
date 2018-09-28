namespace Vehicle.Data
{
    public class Boat : IVehicle
    {
        public double Speed { get; set; }

        public string GetSpeed()
        {
            return string.Format($"{Speed:0} knots");
        }

        public void SetSpeed(double Speed)
        {
            this.Speed = Speed;
        }
    }
}
