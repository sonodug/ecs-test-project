using Leopotam.Ecs;
using UnityEngine;

sealed class GravitySystem : IEcsRunSystem
{
    private readonly EcsWorld world = null;
    private readonly EcsFilter<MovableComponent> gravityFilter = null;

    public void Run()
    {
        foreach (var i in gravityFilter)
        {
            ref var movableComponent = ref gravityFilter.Get1(i);
            ref var velocity = ref movableComponent.Velocity;
            velocity.y += movableComponent.Gravity * Time.deltaTime;

            ref var characterController = ref movableComponent.CharacterController;
            characterController.Move(velocity * Time.deltaTime);
        }
    }
}