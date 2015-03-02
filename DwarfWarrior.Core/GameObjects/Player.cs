namespace DwarfWarrior.Core.GameObjects
{
    using DwarfWarrior.Core.Helpers;

    public class Player
    {
        private const int InitSore = 0;
        private const int SpaceshipSpeed = 2;

        public Player(Spaceship spaceship)
        {
            this.Spaceship = spaceship;
            this.Score = InitSore;
        }

        public Spaceship Spaceship { get; private set; }

        public int Score { get; private set; }

        public void AddScore(int score)
        {
            this.Score += score;
        }

        public void MoveLeft()
        {
            this.Spaceship.TopLeftPosition -= new Coordinate(0, SpaceshipSpeed);
        }

        public void MoveRigth()
        {
            this.Spaceship.TopLeftPosition += new Coordinate(0, SpaceshipSpeed);
        }

        public void MoveUp()
        {
            this.Spaceship.TopLeftPosition -= new Coordinate(SpaceshipSpeed, 0);
        }

        public void MoveDown()
        {
            this.Spaceship.TopLeftPosition += new Coordinate(SpaceshipSpeed, 0);
        }
    }
}