using Assets.Scripts.Untils;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MineralsController : MonoBehaviour
{
    
    private readonly List<GameObject> positionList = new();

    public int score = 650;

    private void Awake()
    {
        positionList.Clear();
        CreateMinerals();
    }

    private void CreateMinerals()
    {
        int sumScore = 0;
        for (int i = 0; sumScore <= score || i < GlobalConstant.GOLD_MIN_COUNT ; i++)
        {
            int probability = Random.Range(1, 11);
            int goldScore = probability <= 6 ? Random.Range(GlobalConstant.GOLD_MIN_SCORE, GlobalConstant.GOLD_MIN_SCORE << 1)
                                            : Random.Range(GlobalConstant.GOLD_MIN_SCORE << 1, GlobalConstant.GOLD_MAX_SCORE + 1);
            sumScore += goldScore;
            Vector3 vector = CreatePosition();
            GameObject gold = CreateGold(vector.x, vector.y, goldScore);
            positionList.Add(gold);
        }
    }

    private Vector3 CreatePosition()
    {
        float x = 0.0f, y = 0.0f;
        bool flag = true;
        while (flag)
        {
            flag = false;
            x = Random.Range(GlobalConstant.GAME_MIN_X, GlobalConstant.GAME_MAX_X);
            y = Random.Range(GlobalConstant.GAME_MIN_Y, GlobalConstant.GAME_MAX_Y);
            foreach (var item in positionList)
            {
                float temp_x = Mathf.Abs(x - item.transform.position.x);
                float temp_y = Mathf.Abs(y - item.transform.position.y);
                if (Mathf.Pow(temp_x, 2) + Mathf.Pow(temp_y, 2) < Mathf.Pow(item.GetComponent<CircleCollider2D>().radius * 2, 2))
                {
                    flag = true;
                    break;
                }
            }
        }
        Vector3 vector = new Vector3(x, y, 0);
        return vector;
    }

    private GameObject CreateGold(float x, float y, int score)
    {
        GameObject gold = new GameObject("gold");

        gold.transform.parent = transform;
        gold.transform.position = new Vector3(x, y, 0);
        float scale = 1.5f * (1.5f - 0.3f) / (GlobalConstant.GOLD_MAX_SCORE - GlobalConstant.GOLD_MIN_SCORE) * score;
        gold.transform.localScale = new Vector3(scale, scale, scale);
        gold.AddComponent<SpriteRenderer>();
        gold.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("gold");
        gold.GetComponent<SpriteRenderer>().sortingLayerName = "Player";
        //创建圆形碰撞体
        gold.AddComponent<CircleCollider2D>();
        gold.GetComponent<CircleCollider2D>().tag = "minerals";
        gold.GetComponent<CircleCollider2D>().isTrigger = true;
        gold.GetComponent<CircleCollider2D>().radius = 0.5f;

        gold.AddComponent<GoldModel>();
        gold.GetComponent<GoldModel>().score = score;

        return gold;
    }

}
