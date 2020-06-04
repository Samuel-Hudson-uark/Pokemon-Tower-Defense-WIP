using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{
    public int berryValue = 10;
    public Rigidbody2D rb;
    public bool collected = false;

    float timeStamp;
    public float expireTime = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        timeStamp = Time.time + expireTime;
    }
    void OnMouseDown()
    {
        Collect();
    }

    void OnMouseEnter()
    {
        if(Input.GetMouseButton(0))
        {
            Collect();
        }
    }

    private void FixedUpdate()
    {
        if(!collected && timeStamp <= Time.time)
        {
            Destroy(gameObject);
            timeStamp = Time.time + expireTime;
        }
    }
    void Collect()
    {
        if(!collected)
        {
            collected = true;
            Inventory.instance.GainCurrency(berryValue);
            rb.AddForce(Vector2.up * 15f, ForceMode2D.Impulse);
            rb.gravityScale = 4;
            Destroy(gameObject, 0.5f);
        }
        

    }

}
