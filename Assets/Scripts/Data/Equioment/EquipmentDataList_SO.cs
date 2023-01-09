using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//字典类型无法序列化

[CreateAssetMenu(fileName = "EquipmentDataList_SO", menuName = "Data/EquipmentDataList_SO")]

public class EquipmentDataList_SO : ScriptableObject
{
    public List<EquipmentDetails> EquipmentDetailsList;

 
}



