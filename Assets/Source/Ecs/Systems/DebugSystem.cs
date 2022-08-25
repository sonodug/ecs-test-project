using Leopotam.Ecs;
using UnityEngine;

sealed class DebugSystem : IEcsRunSystem
{
    private readonly EcsFilter<DebugMessageRequest> messageFilter = null;

    public void Run()
    {
        foreach (var i in messageFilter)
        {
            ref var entity = ref messageFilter.GetEntity(i);
            ref var message = ref messageFilter.Get1(i);
            ref var text = ref message.Message;

            Debug.Log(message);
            entity.Del<DebugMessageRequest>();
        }
    }
}
