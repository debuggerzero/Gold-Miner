using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]//���л�����Ӵ���֮��ſ�����ʾ����
public class EquipmentDetails
{
    public Sprite Sp;//ͼƬ
    public string Name;//����
    public int Price;//�۸�
    public string Description;//����



    public EquipmentDetails(Sprite sprite, string name, int price, string description)
    {
        Sp = sprite;
        Name = name;
        Price = price;
        Description = description;
    }

}