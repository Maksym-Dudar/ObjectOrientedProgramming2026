public interface IRentalStrategy
{
    decimal CalculateRent(decimal baseValue, int amount);
}

public class DailyRentalStrategy : IRentalStrategy
{
    public decimal CalculateRent(decimal baseValue, int amount) => baseValue * amount;
}

public class WeeklyRentalStrategy : IRentalStrategy
{
    public decimal CalculateRent(decimal baseValue, int amount) => baseValue * (7 * amount);
}

public class Car
{
    public string Maker { get; set; }
    public Color Color { get; set; }
}

public class CarRental
{
    public decimal Rent(Car car, decimal baseValue, int amount, IRentalStrategy strategy)
    {
        return strategy.CalculateRent(baseValue, amount);
    }
}

class Program
{
    static void Main()
    {
        var car = new Car
        {
            Maker = "BMW",
            Color = "Red"
        };

        var rental = new CarRental();

        decimal baseValue = 100m;

        IRentalStrategy dailyStrategy = new DailyRentalStrategy();
        decimal dailyPrice = rental.Rent(car, baseValue, 3, dailyStrategy);


        IRentalStrategy weeklyStrategy = new WeeklyRentalStrategy();
        decimal weeklyPrice = rental.Rent(car, baseValue, 2, weeklyStrategy);

    }
}