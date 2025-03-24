using System.Drawing;
using Robocode.TankRoyale.BotApi;
using Robocode.TankRoyale.BotApi.Events;
using static System.Math;

// Bot ini akan ambil posisi sebagai center guard kemudian counterattack jika ada yang menembaknya
public class Belle : Bot
{
    int turnDirection = 1;
    int isScanned = 0;
    int isHit = 0;

    static void Main()
    {
        new Belle().Start();
    }

    Belle() : base(BotInfo.FromFile("Belle.json")) { }

    public override void Run()
    {
        BodyColor = Color.Yellow; 
        TurretColor = Color.Black;
        RadarColor = Color.Black;
        BulletColor = Color.Yellow;
        ScanColor = Color.Yellow;

        MoveToCenter();
        while (IsRunning)
        {
            isHit = 0;
            isScanned = 0;
            if (isHit == 0){
                MoveToCenter();
                if (isScanned == 0){
                    TurnRadarRight(double.PositiveInfinity);
                }
            }
        }
    }

    private void MoveToCenter()
    {
        double x = ArenaWidth / 2;
        double y = ArenaHeight / 2;
        TurnToFaceTarget(x, y);
        Forward(DistanceTo(x, y));
    }

    private void TurnToFaceTarget(double x, double y)
    {
        var bearing = BearingTo(x, y);
        turnDirection = (bearing >= 0) ? 1 : -1;
        SetTurnLeft(bearing);
    }

    public override void OnScannedBot(ScannedBotEvent e)
    {   
        isScanned = 1;
        double angleDifference = Direction + BearingTo(e.X, e.Y);
        double turningPoint = NormalizeRelativeAngle(angleDifference - RadarDirection);
        double tolerance = Min(Atan(36.0 / DistanceTo(e.X, e.Y)), 45);
        turningPoint += (turningPoint < 0 ? -tolerance : tolerance);
        SetTurnRadarLeft(turningPoint);

        if(isHit == 0){
            TurnToFaceTarget(e.X, e.Y);
            SetFire(3);
        } else {
            TurnToFaceTarget(e.X, e.Y);
            SetForward(DistanceTo(e.X, e.Y));
            if (DistanceTo(e.X, e.Y) <= 100) {
                SetFire(3);
            }
            if (e.Energy < 0){
                isHit = 0;
                return;
            }
        }

    }

    public override void OnHitByBullet(HitByBulletEvent e) {
        isHit = 1;
    }

    public override void OnHitBot(HitBotEvent e) {
        isHit = 1;
    }
}