using UnityEngine;

namespace Player
{
    public class StandaloneShootController : IShootController
    {
        private readonly float _fireRate;

        private float _nextFireTime;

        public StandaloneShootController(float fireRate)
        {
            _fireRate = fireRate;
        }

        public bool IsTryToShoot()
        {
            return Input.GetButtonDown("Fire1");
        }

        public void Shoot(float nextFireTime)
        {
            if (Time.time >= nextFireTime)
            {
                //GameObject fireBall = Instantiate(projectile, firePoint.position, Quaternion.identity);
                //fireBall.GetComponent<Rigidbody2D>().AddForce(firePoint.right * 500f);
                _nextFireTime = Time.time + 1f / _fireRate; // Set the next allowed fire time
            }
        }
    }
}