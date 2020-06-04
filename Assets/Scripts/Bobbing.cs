using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobbing : MonoBehaviour
{
    public int bobTime = 15;
    private int timer = 0;
    private float yDisplace;
    private float displaceValue;

    Vector2 floatY;
    float originalY;
    void Start()
    {
        yDisplace = 0f;
        originalY = this.transform.position.y;
        displaceValue = 0.0625f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (timer >= bobTime)
        {
            if (yDisplace == 0f)
            {
                yDisplace += displaceValue;
            }
            else
            {
                yDisplace -= displaceValue;
            }
            timer = 0;
            floatY = transform.position;
            floatY.y = originalY + yDisplace;
            transform.position = floatY;
        } 
        else
        {
            timer++;
        }
    }
}
