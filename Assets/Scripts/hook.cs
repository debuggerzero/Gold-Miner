using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    GameObject hook;
    float hookRtZ;
    // Start is called before the first frame update
    void Start()
    {
        //hook = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        hookRtZ += Time.deltaTime * 10;
        transform.rotation = Quaternion.Euler(0, 0, 50);

    }
}
