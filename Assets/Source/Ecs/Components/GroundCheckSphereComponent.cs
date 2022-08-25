using System;
using UnityEngine;

[Serializable]
public struct GroundCheckSphereComponent
{
    public bool IsGrounded;
    public Transform GroundCheckSphere;
    public float GroundDistance;
    public LayerMask GroundMask;
}