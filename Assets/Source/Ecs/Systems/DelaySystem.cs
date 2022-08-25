using Leopotam.Ecs;
using UnityEngine;

sealed class DelaySystem : IEcsRunSystem
{
    private readonly EcsFilter<DelayRequest> blockFilter = null;

    public void Run()
    {
        foreach (var i in blockFilter)
        {
            ref var entity = ref blockFilter.GetEntity(i);
            ref var block = ref blockFilter.Get1(i);
            block.Timer -= Time.deltaTime;

            if (block.Timer <= 0)
            {
                entity.Del<DelayRequest>();
            }
        }
    }
}