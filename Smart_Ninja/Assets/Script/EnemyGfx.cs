using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGfx : MonoBehaviour
{
    public AIPath aipath;
    private SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        if (aipath.desiredVelocity.x>=0.01f)
        {
            sprite.flipX = false;
        }
        else if(aipath.desiredVelocity.x<=-0.01f)
        {
            sprite.flipX = true;
        }
    }
}
