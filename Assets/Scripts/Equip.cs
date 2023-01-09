using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Equip : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public string Name;
    public int Price;
    public string Description;
    public Text text;
    private void Start()
    {
        gameObject.name = Name;
        gameObject.GetComponentInChildren<Text>().text= "$" + Price;
    }
    public void Buy()//������Ʒ
    {
        text.text = " ";
    }

    public void OnPointerEnter(PointerEventData eventData)//�������
    {
        text.text = Description;
    }

    public void OnPointerExit(PointerEventData eventData)//����Ƴ�
    {
        text.text = " ";
    }
}
