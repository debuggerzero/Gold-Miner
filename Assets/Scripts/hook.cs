using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hook : MonoBehaviour
{
    public float hookSpeed; //�����ٶ�
    Rigidbody rb; //����
    public float rtDirection; // ���Ӱڶ�����
    public float hookRtZ; //���Ӱڶ��Ƕ�
    public float rtSpeed; //�ڶ��ٶ�
    public float hookState = 0; // 0Ϊ����״̬��1Ϊ����״̬��2Ϊ����״̬
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

    void HookRotation() //���Ӱڶ�
    {
        if (hookState == 0) 
        {
            if (hookRtZ >= 75) //���ڶ��Ƕ�Ϊ-75��75��
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

    void OutHook() //����
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

    private void OnTriggerEnter2D(Collider2D collision) //��ײ���
    {
        if (collision.CompareTag("boundary")) //�����߽�
        {
            hookState = 2;
        }
        if (collision.CompareTag("minerals")) //ץס����
        {
            hookState = 2;
            collision.transform.position = transform.GetChild(1).position;
            collision.transform.parent = transform;
        }
    }
    
    void ReturnHook() //�����ջ�
    {
        if (hookState == 2)
        {
            transform.position = new Vector3(-Time.deltaTime * hookSpeed * Mathf.Sin(hookRtZ * Mathf.PI / 180) + transform.position.x,
    Time.deltaTime * hookSpeed * Mathf.Cos(hookRtZ * Mathf.PI / 180) + transform.position.y, 0);
            if (transform.position.y >= 2.95) //������ӻص�ԭλ
            {
                transform.position = new Vector3(0.16f, 2.95f, 0); //��ȷ��λ
                hookState = 0; //���ӻص�����״̬
                if(transform.childCount > 2) Destroy(transform.GetChild(2).gameObject); //���������������3����ɾ��������
            }
        }


    }
}

