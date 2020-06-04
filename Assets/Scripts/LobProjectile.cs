using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobProjectile : MonoBehaviour
{
    private float animationTimer;
    private Vector3 start;
    private Transform target;

    void Start()
    {
        start = transform.position;
        RaycastHit2D collisionRay = Physics2D.Raycast(transform.position, Vector2.right, 100, 1 << LayerMask.NameToLayer("Enemy"));
        target = collisionRay.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(animationTimer >= 3f)
        {
            Destroy(gameObject);
            return;
        }
        animationTimer = animationTimer += Time.deltaTime;
        transform.position = MathParabola.Parabola(start, target.position, 3f, animationTimer);
    }
}
