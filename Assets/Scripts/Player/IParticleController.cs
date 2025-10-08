namespace Player
{
    public interface IParticleController
    {
        void UpdateImpactEffect();
        void UpdateFootsteps(float moveX, bool isGroundedBool);
    }
}