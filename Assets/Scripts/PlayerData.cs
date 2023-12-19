using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/PlayerData")]
public class PlayerData : ScriptableObject
{
    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField]
    private float airSpeed = 2f;
    [SerializeField]
    private float jumpPower = 10f;
    [SerializeField]
    private float additionalGravity = 5f;

    [SerializeField]
    private LayerMask groundMask;

    [SerializeField]
    private float groundRayDistance = 0.2f;

    [SerializeField]
    private Vector2 jumpStretchScale = new Vector3(0.9f, 1.3f, 1f),
        jumpSqueezeScale = new Vector3(1.3f, 0.6f, 1f);

    [SerializeField]
    private float jumpStretchDuration = 0.2f,
        jumpSqueezeDuration = 0.1f;

    //public float MoveSpeed => moveSpeed;

    public float AirSpeed => airSpeed;
    public float JumpPower => jumpPower;
    public float AdditionalGravity => additionalGravity;

    public LayerMask GroundMask => groundMask;
    public float GroundRayDistance => groundRayDistance;
    public Vector2 JumpStretchScale => jumpStretchScale;
    public Vector2 JumpSqueezeScale => jumpSqueezeScale;
    public float JumpStretchDuration => jumpStretchDuration;
    public float JumpSqueezeDuration => jumpSqueezeDuration;

    public float MoveSpeed 
    {
        get
        {
            return moveSpeed;
        }
        private set => moveSpeed = value; 
    }
}