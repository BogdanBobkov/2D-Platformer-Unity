using UnityEngine;

namespace Player
{
    public class ParticleController : IParticleController
    {
        private readonly ParticleSystem _footstepParticleSystem;
        private readonly ParticleSystem _impactParticleSystem;

        private ParticleSystem.EmissionModule _emissionModule;

        public ParticleController(ParticleSystem footstepParticleSystem, ParticleSystem impactParticleSystem)
        {
            _footstepParticleSystem = footstepParticleSystem;
            _impactParticleSystem = impactParticleSystem;

            _emissionModule = _footstepParticleSystem.emission;
        }
        
        public void UpdateImpactEffect()
        {
            _impactParticleSystem.gameObject.SetActive(true);
            _impactParticleSystem.Stop();
            _impactParticleSystem.transform.position = new Vector2(_footstepParticleSystem.transform.position.x, _footstepParticleSystem.transform.position.y - 0.2f);
            _impactParticleSystem.Play();
        }

        public void UpdateFootsteps(float moveX, bool isGroundedBool)
        {
            if (moveX != 0 && isGroundedBool)
            {
                _emissionModule.rateOverTime = 35f;
            }
            else
            {
                _emissionModule.rateOverTime = 0f;
            }
        }
    }
}