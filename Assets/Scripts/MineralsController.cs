using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MineralsController : MonoBehaviour
{
    private void Awake()
    {
        CreateGold(0f, 0f);
    }

    private void CreateGold(float x, float y, float z = 0)
    {
        GameObject gold = new GameObject("gold");
        gold.transform.parent = transform;
        gold.transform.position = new Vector3(x, y, z);
        gold.AddComponent<SpriteRenderer>();
        gold.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("gold");
        gold.GetComponent<SpriteRenderer>().sortingLayerName = "Player";
        //创建圆形碰撞体
        gold.AddComponent<CircleCollider2D>();
        gold.GetComponent<CircleCollider2D>().isTrigger = true;
        gold.GetComponent<CircleCollider2D>().radius = 0.4f;
        //return gameObject;
    }

}
