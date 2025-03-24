using System;
using System.Drawing;
using Robocode.TankRoyale.BotApi;
using Robocode.TankRoyale.BotApi.Events;

public class Elsa : Bot
{
    private bool peek;
    private double moveAmount;

    public static void Main(string[] args)
    {
        new Elsa().Start();
    }
    public Elsa() : base(BotInfo.FromFile("Elsa.json")) { }

    public override void Run()
    {
        BodyColor = Color.Blue;
        TurretColor = Color.White;
        RadarColor = Color.LightBlue;
        BulletColor = Color.Cyan;
        ScanColor = Color.LightBlue;

        moveAmount = Math.Max(ArenaWidth, ArenaHeight) - 50;
        peek = false;

        TurnRight(Direction % 90);
        Forward(moveAmount - 50);
        TurnRight(90);
        peek = true;

        while (IsRunning)
        {
            peek = true;
            Forward(moveAmount - 50);
            peek = false;
            TurnRight(90);
        }
    }

    public override void OnScannedBot(ScannedBotEvent e)
    {
        Fire(2);
        if (peek)
        {
            Rescan();
        }
    }

    public override void OnHitBot(HitBotEvent e)
    {
        double bearing = BearingTo(e.X, e.Y);
        if (bearing > -90 && bearing < 90)
        {
            Back(100);
        }
        else
        {
            Forward(100);
        }
    }

    public override void OnHitByBullet(HitByBulletEvent e)
    {
        TurnRight(45);
        Forward(50);
    }

    public override void OnHitWall(HitWallEvent e)
    {
        Back(20);
        TurnRight(90);
    }
}
