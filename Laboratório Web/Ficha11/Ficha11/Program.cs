using Ficha11;

Engine engine1 = new Engine(25, 40, 60);

Engine engine2 = new Engine(35, 45, 61);

Car car1 = new Car(5, 5, Vehicle.Travel.LAND, "Preto", 250, "KIA", "Stonic GT Line", engine1);

Motorcycle motorcycle1 = new Motorcycle(Motorcycle.Type.ADVENTURE, 240, Vehicle.Travel.LAND, "Rosa", 80, "Suzuki", "CT", engine1);

Console.WriteLine(car1.ToString());
Console.WriteLine(motorcycle1.ToString());

VehicleTest v1 = new VehicleTest(car1);

v1.Vehi.Start();

car1.engine = engine2;

car1.Drive();

motorcycle1.Drive();