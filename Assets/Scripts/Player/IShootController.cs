namespace Player
{
    public interface IShootController
    {
        bool IsTryToShoot();
        void Shoot(float nextFireTime);
    }
}