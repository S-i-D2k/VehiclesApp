namespace Vehicle.Data
{
    public interface IVehicle
    {
        double Speed { get; set; }

        void SetSpeed(double Speed);
        string GetSpeed();
    }
}
