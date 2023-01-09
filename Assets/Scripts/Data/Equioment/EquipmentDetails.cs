using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]//序列化，添加此行之后才可以显示出来
public class EquipmentDetails
{
    public Sprite Sp;//图片
    public string Name;//名称
    public int Price;//价格
    public string Description;//描述



    public EquipmentDetails(Sprite sprite, string name, int price, string description)
    {
        Sp = sprite;
        Name = name;
        Price = price;
        Description = description;
    }

}