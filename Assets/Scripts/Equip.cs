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
    public void Buy()//购买商品
    {
        text.text = " ";
    }

    public void OnPointerEnter(PointerEventData eventData)//鼠标移入
    {
        text.text = Description;
    }

    public void OnPointerExit(PointerEventData eventData)//鼠标移出
    {
        text.text = " ";
    }
}
