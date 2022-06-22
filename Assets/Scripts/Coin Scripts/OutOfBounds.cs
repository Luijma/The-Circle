using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestrotOutOfBounds : MonoBehaviour
{
    //Limits
    private float spawnLimitX = 13f;
    private float spawnLimitY = 5.2f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Destroy GameObjects
        if (transform.position.x > spawnLimitX || transform.position.x < -spawnLimitX
            || transform.position.y > spawnLimitY || transform.position.y < -spawnLimitY)
        {
            Destroy(gameObject);
        }
    }
}