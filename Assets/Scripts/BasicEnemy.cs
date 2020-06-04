using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{


    public float moveSpeed = 1f;
    public float timer = 0f;
    public float attackTime;
    public float attackValue;
    public GameObject attackFx;

    public Rigidbody2D rb;

    Vector2 movement;
    RaycastHit2D collisionRay;

    // Start is called before the first frame update
    void Start()
    {
        movement.x = moveSpeed * -1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        collisionRay = Physics2D.Raycast(transform.position, Vector2.left, 0.5f, 1<< LayerMask.NameToLayer("Ally"));
        if(collisionRay.collider != null)
        {
            if (timer >= attackTime)
            {
                //fire the projectile
                Attack(collisionRay.transform);
                timer = 0;
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
        else
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }

    }

    void Attack(Transform target)
    {
        GameObject bullet = Instantiate(attackFx, new Vector3(target.position.x, target.position.y - 0.2f, target.position.z), target.rotation);
        HpHandler targetHH = (HpHandler)target.gameObject.GetComponent("HpHandler");
        targetHH.TakeDamage(attackValue);
    }
}
