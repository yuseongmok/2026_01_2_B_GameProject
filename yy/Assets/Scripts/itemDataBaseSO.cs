using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "itemDataBase", menuName = "Inventory/DataBase")]
public class itemDataBaseSO : ScriptableObject
{
    public List<itemSO> items = new List<itemSO>();                  //itemSo를 리스트로 관리

    //캐싱을 위한 Dictrionary
    private Dictionary<int, itemSO> itemByld;                       //ID로 아이템 찾기
    private Dictionary<string, itemSO> itemByName;                  //이름으로 아이템 찾기

    public void Initialze()
    {
        itemByld = new Dictionary<int, itemSO>();                 //위에 선언만 했기 때문에 Dictionary 할당
        itemByName = new Dictionary<string, itemSO>();

        foreach (var item in items)
        {
            itemByld[item.id] = item;
            itemByName[item.itemName] = item;
        }
    }

    //ID로 아이템 찾ㄴ기

    public itemSO GetItemByld(int id)
    {
        if (itemByld == null)           //캐싱이 되어있는지 확인하고 아니면 초기화 한다
        {
            Initialze();
        }
        if(itemByld.TryGetValue(id, out itemSO item))       //id 값을 찾아서 ItemSo를 리턴한다.
            return item;

        return null;                     //없을경우 NUll
    }

    //이름으로 아이템 찾기

    public itemSO GetItemByName(string name)
    {
        if ((itemByName == null))
        {
            Initialze();
        }

        if(itemByName.TryGetValue(name, out itemSO item))
            return item;

        return null;
    }


    //타입으로 아이템 필터링

    public List<itemSO> GetItemByType(itemType type)
    {
        return items.FindAll(item => item.itemType == type);
    }
}
