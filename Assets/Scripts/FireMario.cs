using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMario : MonoBehaviour
{
    [SerializeField]
    private Fireball fireballPrefab;

    [SerializeField] private Vector2 spawnOffset;

    [SerializeField] private Vector2 shootDirection = Vector2.right;

    private Player player;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) || Input.GetKeyUp(KeyCode.LeftControl))
        {
            ShootFireaball();
        }
    }

    private void ShootFireaball()
    {
        var spawnPosition = (Vector2) transform.position + new Vector2(spawnOffset.x * player.direction, spawnOffset.y);
        var newFireball = Instantiate(fireballPrefab, spawnPosition, Quaternion.identity);

        newFireball.Shoot(shootDirection * player.direction);
        SoundManager.OnFireBall();
    }
}
