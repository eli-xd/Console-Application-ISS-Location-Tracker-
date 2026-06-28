using IssLocationTracker;

Console.WriteLine("ISS Location Tracker");
Console.WriteLine("--------------------");

Console.Write("Enter update interval in seconds (minimum 0.5): ");

double interval;

while (!double.TryParse(Console.ReadLine(), out interval) || interval < 0.5)
{
    Console.Write("Invalid input. Enter a value of at least 0.5: ");
}

var service = new IssLocationService();

while (true)
{
    IssLocation? location = await service.GetCurrentLocationAsync();

    Console.Clear();
    Console.WriteLine("ISS Location Tracker");
    Console.WriteLine("--------------------");

    if (location != null)
    {
        Console.WriteLine($"Time: {DateTime.Now:T}");
        Console.WriteLine($"Satellite: {location.Name}");
        Console.WriteLine($"Latitude: {location.Latitude}");
        Console.WriteLine($"Longitude: {location.Longitude}");
        Console.WriteLine($"Altitude: {location.Altitude} kilometers");
        Console.WriteLine($"Velocity: {location.Velocity} km/h");
        Console.WriteLine($"Visibility: {location.Visibility}");
    }
    else
    {
        Console.WriteLine("Could not fetch ISS location.");
    }

    Console.WriteLine();
    Console.WriteLine($"Updating again in {interval} second(s)...");

    await Task.Delay(TimeSpan.FromSeconds(interval));
}