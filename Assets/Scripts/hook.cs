using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hook : MonoBehaviour
{

    public float hookSpeed; //钩子速度
    Rigidbody rb; //刚体

    public float rtDirection; // 钩子摆动方向
    public float hookRtZ; //钩子摆动角度
    public float rtSpeed; //摆动速度
    public float hookState = 0; // 0为闲置状态，1为发射状态，2为回收状态
    // Start is called before the first frame update
    void Start()
    {
        rtSpeed = 100;
        rtDirection = 1;
        hookSpeed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        HookRotation();
        OutHook();
        ReturnHook();
    }

    void HookRotation() //钩子摆动
    {
        if (hookState == 0) 
        {
            if (hookRtZ >= 75) //最大摆动角度为-75到75度
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
    

    void OutHook() //出钩
    {
        if (Input.GetMouseButtonDown(0) && hookState == 0)
        {
            hookState = 1;
        }
        if (hookState == 1)
        {
            transform.position = new Vector3(Time.deltaTime * hookSpeed * Mathf.Sin(hookRtZ * Mathf.PI / 180) + transform.position.x,
                Time.deltaTime * -hookSpeed * Mathf.Cos(hookRtZ * Mathf.PI / 180) + transform.position.y, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //碰撞检测
    {
        if (collision.CompareTag("boundary")) //遇到边界
        {
            hookState = 2;
        }
        if (collision.CompareTag("minerals")) //抓住矿物
        {
            hookState = 2;
            collision.transform.parent = transform;
        }
    }
    
    void ReturnHook() //钩子收回
    {
        if (hookState == 2)
        {
            transform.position = new Vector3(-Time.deltaTime * hookSpeed * Mathf.Sin(hookRtZ * Mathf.PI / 180) + transform.position.x,
    Time.deltaTime * hookSpeed * Mathf.Cos(hookRtZ * Mathf.PI / 180) + transform.position.y, 0);
        }

        if (transform.position.y >= 2.95) //如果钩子回到原位
        {
            transform.position = new Vector3(0.16f, 2.95f, 0); //精确复位
            hookState = 0; //钩子回到闲置状态
        }
    }
}

