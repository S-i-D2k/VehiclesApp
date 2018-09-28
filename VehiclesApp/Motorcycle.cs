namespace Vehicle.Data
{
    public class Motorcycle : IVehicle
    {
        public double Speed { get; set; }

        public string GetSpeed()
        {
            return string.Format($"{Speed:0} km/h");
        }

        public void SetSpeed(double Speed)
        {
            this.Speed = Speed;
        }
    }
}
