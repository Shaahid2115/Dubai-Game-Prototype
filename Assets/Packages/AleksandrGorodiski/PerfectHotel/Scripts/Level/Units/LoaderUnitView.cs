using Game.Level.Unit;
using UnityEngine;

public sealed class LoaderUnitView : UnitStaffView
{
    [SerializeField] private ParticleSystem _particles;

    internal void PlayUnitParticles()
    {
        _particles.Play();
    }
}
