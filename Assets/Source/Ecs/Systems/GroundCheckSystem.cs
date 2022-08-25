using Leopotam.Ecs;
using UnityEngine;

sealed class GroundCheckSystem : IEcsRunSystem
{
    private readonly EcsWorld world = null;
    private readonly EcsFilter<PlayerTag, GroundCheckSphereComponent> groundFilter = null;

    public void Run()
    {
        foreach (var i in groundFilter)
        {
            ref var groundCheck = ref groundFilter.Get2(i);

            groundCheck.IsGrounded = Physics.CheckSphere(groundCheck.GroundCheckSphere.position, groundCheck.GroundDistance, groundCheck.GroundMask);
        }
    }
}