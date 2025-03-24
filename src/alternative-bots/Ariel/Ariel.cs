using System;
using System.Drawing;
using Robocode.TankRoyale.BotApi;
using Robocode.TankRoyale.BotApi.Events;
using static System.Math;

// Bot yang movementnya zigzag dan mengejar target terdekat
public class Ariel : Bot
{
    int turnDirection = 1;
    int isScanned = 0;
    int isHit = 0;

    static void Main(string[] args)
    {
        new Ariel().Start();
    }

    Ariel() : base(BotInfo.FromFile("Ariel.json")) { }

    public override void Run()
    {
        BodyColor = Color.Pink; 
        TurretColor = Color.Black;
        RadarColor = Color.Green;
        BulletColor = Color.Green;
        ScanColor = Color.Green;

        while (IsRunning)
        {
            ZigzagMovement();
            TurnRadarRight(double.PositiveInfinity);
        }
    }

    private void ZigzagMovement()
    {
        SetTurnRight(30 * turnDirection); 
        WaitFor(new Condition(() => TurnRemaining == 0));
        SetForward(100);
        turnDirection *= -1;
    }

    public override void OnScannedBot(ScannedBotEvent e)
    {   
        isScanned = 1;
        double angleDifference = Direction + BearingTo(e.X, e.Y);
        double turningPoint = NormalizeRelativeAngle(angleDifference - RadarDirection);
        double tolerance = Min(Atan(36.0 / DistanceTo(e.X, e.Y)), 45);
        turningPoint += (turningPoint < 0 ? -tolerance : tolerance);
        SetTurnRadarLeft(turningPoint);

        TurnToFaceTarget(e.X, e.Y);
        SetForward(DistanceTo(e.X, e.Y));
        if (DistanceTo(e.X, e.Y) <= 100) {
            SetFire(3);
        }
    }


    private void TurnToFaceTarget(double x, double y)
    {
        var bearing = BearingTo(x, y);
        SetTurnLeft(bearing); 
        WaitFor(new Condition(() => TurnRemaining == 0)); 
    }
}
