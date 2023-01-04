using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hook : MonoBehaviour
{
    float hookRtZ;
    public float rtSpeed;
    float rtDirection;
    // Start is called before the first frame update
    void Start()
    {
        rtSpeed = 100;
        rtDirection = 1;
    }

    // Update is called once per frame
    void Update()
    {
        HookRotation();
    }

    void HookRotation()
    {
        
        if (hookRtZ >= 75)
        {
            rtDirection = -1;
        }
        else if (hookRtZ <= -75)
        {
            rtDirection = 1;
        }
        hookRtZ += Time.deltaTime * rtSpeed * rtDirection;
        transform.rotation = Quaternion.Euler(0, 0, hookRtZ);
    }
}

