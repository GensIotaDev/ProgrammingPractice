namespace Challenges.Kyu5.ConstructingCar01;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/578b4f9b7c77f535fc00002f">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/578b78dbdaa01a94be0000fb/groups/68266361503c3189a2436d6c">here</see>
/// </summary>
public class Car : ICar
{
  public bool EngineIsRunning => engine.IsRunning;
  
  public IFuelTankDisplay fuelTankDisplay;
  
  public IDrivingInformationDisplay drivingInformationDisplay;

  private IEngine engine;

  private IFuelTank fuelTank;
  
  private IDrivingProcessor drivingProcessor;

  private bool isBreaking = false;

  public Car() : this(20.0, 10)
  {
  }
  public Car(double fuelLevel) : this(fuelLevel, 10){}
  public Car(double fuelLevel, int maxAcceleration)
  {
      fuelTank = new FuelTank();
      fuelTank.Refuel(Math.Clamp(fuelLevel, 0, 60));

      engine = new Engine(fuelTank);
      fuelTankDisplay = new FuelTankDisplay(fuelTank);

      drivingProcessor = new DrivingProcessor(Math.Clamp(maxAcceleration, 5, 20));
      drivingInformationDisplay = new DrivingInformationDisplay(drivingProcessor);
  }

  public void BrakeBy(int speed)
  {
      drivingProcessor.ReduceSpeed(speed);
      isBreaking = true;
  }

  public void Accelerate(int speed)
  {
      drivingProcessor.IncreaseSpeedTo(speed);
      isBreaking = speed <= 0;
  }
  
  public void EngineStart() => engine.Start();

  public void EngineStop() => engine.Stop();

  public void FreeWheel() => Accelerate(-1);

  public void Refuel(double liters) => fuelTank.Refuel(liters);

  public void RunningIdle()
  {
      if (EngineIsRunning && !isBreaking)
      {
          double rate = drivingProcessor.ActualSpeed switch
          {
              0 => 0.0,
              <= 60 => 0.0020,
              <= 100 => 0.0014,
              <= 140 => 0.0020,
              <= 200 => 0.0025,
              <= 250 => 0.0030
          };
          engine.Consume(rate);
      }
  }
}

public class Engine : IEngine
{
    public bool IsRunning { get; private set; }
    
    private IFuelTank _fuelTank;

    public Engine(IFuelTank fuelTank)
    {
        this._fuelTank = fuelTank;
    }
    
    public void Consume(double liters)
    {
        _fuelTank.Consume(liters);
        
        if(_fuelTank.FillLevel == 0.0){
          Stop();
          return;
        }
    }

    public void Start()
    {
        if(_fuelTank.FillLevel != 0.0)
        {
          IsRunning = true;
        }        
    }

    public void Stop()
    {
        IsRunning = false;
    }
}

public class FuelTank : IFuelTank
{
    public double FillLevel { get; private set; }
    public bool IsOnReserve => FillLevel < 5.0;
    public bool IsComplete => FillLevel == 60.0;
    
    public void Consume(double liters)
    {
        FillLevel = Math.Clamp(FillLevel - liters, 0, 60);
    }

    public void Refuel(double liters)
    {
        FillLevel = Math.Clamp(FillLevel + liters, 0, 60);
    }
}

public class FuelTankDisplay : IFuelTankDisplay
{
    public double FillLevel => Math.Round(_fuelTank.FillLevel, 2);
    public bool IsOnReserve => _fuelTank.IsOnReserve;
    public bool IsComplete => _fuelTank.IsComplete;

    private IFuelTank _fuelTank;
    
    public FuelTankDisplay(IFuelTank fuelTank)
    {
        this._fuelTank = fuelTank;
    }
}

public class DrivingInformationDisplay : IDrivingInformationDisplay
{
    public int ActualSpeed => _drivingProcessor.ActualSpeed;
    private IDrivingProcessor _drivingProcessor;

    public DrivingInformationDisplay(IDrivingProcessor drivingProcessor)
    {
        this._drivingProcessor = drivingProcessor;
    }
}

public class DrivingProcessor : IDrivingProcessor
{
    private const int MinSpeed = 0, MaxSpeed = 250, BrakeSpeed = 10, FreeWheelSpeed = -1;
    public int ActualSpeed { get; private set; }
    private int maxAcceleration;
    public DrivingProcessor(int maxAcceleration)
    {
        this.maxAcceleration = maxAcceleration;
    }
    
    public void IncreaseSpeedTo(int speed)
    {
        int accel = speed < ActualSpeed? FreeWheelSpeed : Math.Min(speed - ActualSpeed, maxAcceleration);
        
        ActualSpeed = Math.Min(ActualSpeed + accel, MaxSpeed);
    }

    public void ReduceSpeed(int speed)
    {
        int accel = Math.Clamp(speed, 0, BrakeSpeed);
        ActualSpeed = Math.Max(ActualSpeed - accel, MinSpeed);
    }
}