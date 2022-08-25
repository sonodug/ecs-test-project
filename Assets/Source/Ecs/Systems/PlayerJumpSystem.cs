using Leopotam.Ecs;
using UnityEngine;

sealed class PlayerJumpSystem : IEcsRunSystem
{
    private readonly EcsFilter<PlayerTag, GroundCheckSphereComponent, JumpComponent, JumpEvent>.Exclude<DelayRequest> jumpFilter = null;

    public void Run()
    {
        foreach (var i in jumpFilter)
        {
            ref var entity = ref jumpFilter.GetEntity(i);
            ref var groundCheck = ref jumpFilter.Get2(i);
            ref var jumpComponent = ref jumpFilter.Get3(i);
            ref var movable = ref entity.Get<MovableComponent>();
            ref var velocity = ref movable.Velocity;

            if (!groundCheck.IsGrounded) continue;

            velocity.y = Mathf.Sqrt(jumpComponent.Force * -2.0f * movable.Gravity);
            entity.Get<DelayRequest>().Timer = 3f;
            Debug.Log(entity.Get<DelayRequest>().Timer);
        }
    }
}
