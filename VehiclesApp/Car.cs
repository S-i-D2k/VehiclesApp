namespace Vehicle.Data
{
    public class Car : IVehicle
    {
        public double Speed { get; set; }

        public string GetSpeed()
        {
            return string.Format($"{Speed:0} mph");
        }

        public void SetSpeed(double Speed)
        {
            this.Speed = Speed;
        }
    }
}
