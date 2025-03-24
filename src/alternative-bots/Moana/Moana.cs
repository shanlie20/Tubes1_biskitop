using System;
using System.Drawing;
using Robocode.TankRoyale.BotApi;
using Robocode.TankRoyale.BotApi.Events;
using static System.Math;

public class Moana : Bot
{
    private double wavePhase = 0;

    public static void Main(string[] args)
    {
        new Moana().Start();
    }
    
    public Moana() : base(BotInfo.FromFile("Moana.json")) { }

    public override void Run()
    {
        BodyColor = Color.FromArgb(0, 150, 136); // Teal
        TurretColor = Color.FromArgb(255, 87, 34); // Deep Orange
        RadarColor = Color.FromArgb(255, 202, 40); // Amber
        BulletColor = Color.FromArgb(244, 67, 54); // Red
        ScanColor = Color.FromArgb(0, 188, 212); // Cyan

        while (IsRunning)
        {
            MoveInSineWave();
            TurnRadarRight(360);
        }
    }

    private void MoveInSineWave()
    {
        Forward(20);
        TurnRight(10 * Math.Sin(wavePhase));
        wavePhase += 0.5;
    }

    public override void OnHitByBullet(HitByBulletEvent e)
    {
        TurnRight(90);
        Forward(150);
    }

    public override void OnHitWall(HitWallEvent e)
    {
        Back(50);
        TurnRight(90);
    }

    public override void OnScannedBot(ScannedBotEvent e)
    {
        double distance = DistanceTo(e.X, e.Y);
        double angleDifference = Direction + BearingTo(e.X, e.Y);
        double turningPoint = NormalizeRelativeAngle(angleDifference - RadarDirection);
        double tolerance = Min(Atan(36.0 / distance), 45);
        turningPoint += (turningPoint < 0 ? -tolerance : tolerance);
        SetTurnRadarLeft(turningPoint);
        TurnToFaceTarget(e.X, e.Y);

        if (distance < 300)
            SetFire(3);
        else if (distance < 600)
            SetFire(2);
        else
            SetFire(1);

        if (distance < 200)
            Back(100);
        else if (distance > 600)
            Forward(100);
    }

    private void TurnToFaceTarget(double x, double y)
    {
        double bearing = BearingTo(x, y);
        SetTurnLeft(bearing);
    }
}
