namespace Challenges.Kyu5.ConstructingCar01;

public interface ICar
{
    bool EngineIsRunning { get; }
    
    void BrakeBy(int speed);

    void Accelerate(int speed);

    void EngineStart();

    void EngineStop();
    
    void FreeWheel();
    
    void Refuel(double liters);

    void RunningIdle();
}

public interface IEngine
{
    bool IsRunning { get; }

    void Consume(double liters);

    void Start();

    void Stop();
}

public interface IFuelTank
{
    double FillLevel { get; }

    bool IsOnReserve { get; }

    bool IsComplete { get; }

    void Consume(double liters);

    void Refuel(double liters);        
}

public interface IFuelTankDisplay
{
    double FillLevel { get; }

    bool IsOnReserve { get; }

    bool IsComplete { get; }
}

public interface IDrivingInformationDisplay // car #2
{
    int ActualSpeed { get; }
}

public interface IDrivingProcessor // car #2
{
    int ActualSpeed { get; }

    void IncreaseSpeedTo(int speed);

    void ReduceSpeed(int speed);
}