using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Voody.UniLeo;

/// <summary>
/// Entry point for ECS, containing monobehaviour
/// </summary>
public class EcsGameStartup : MonoBehaviour
{
    private EcsWorld _world;
    private EcsSystems _systems;

    private void Start()
    {
        _world = new EcsWorld();
        _systems = new EcsSystems(_world);

        _systems.ConvertScene();

        AddInjections();
        AddOneFrames();
        AddSystems();

        _systems.Init();
    }

    private void AddInjections()
    {

    }

    private void AddSystems()
    {
        _systems.
            Add(new DelaySystem()).
            Add(new PlayerJumpSendEventSystem()).
            Add(new GroundCheckSystem()).
            Add(new PlayerMovementInputSystem()).
            Add(new MovementSystem()).
            Add(new GravitySystem()).
            Add(new PlayerJumpSystem()).
            Add(new DebugSystem());
    }

    private void AddOneFrames()
    {
        _systems.
            OneFrame<JumpEvent>();
    }

    private void Update()
    {
        _systems.Run();
    }

    private void OnDestroy()
    {
        if (_systems == null)
            return;

        _systems.Destroy();
        _systems = null;

        _world.Destroy();
        _world = null;
    }
}
