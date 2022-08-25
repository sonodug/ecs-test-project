using Leopotam.Ecs;
using UnityEngine;

sealed class MovementSystem : IEcsRunSystem
{
    private readonly EcsWorld _world = null;
    private readonly EcsFilter<ModelComponent, MovableComponent, DirectionComponent> movableFilter = null;

    public void Run()
    {
        _world.SendMessage(new DelayRequest()
        {
            //GUI?
        });

        foreach (var i in movableFilter)
        {
            ref var modelComponent = ref movableFilter.Get1(i);
            ref var movableComponent = ref movableFilter.Get2(i);
            ref var directionComponent = ref movableFilter.Get3(i);

            ref var direction = ref directionComponent.Direction;
            ref var transform = ref modelComponent.ModelTransform;

            ref var characterController = ref movableComponent.CharacterController;
            ref var speed = ref movableComponent.Speed;

            var rawDirection = (transform.right * direction.x) + (transform.forward * direction.z);
            characterController.Move(speed * Time.deltaTime * rawDirection);
        }
    }
}
