using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopEraser : MonoBehaviour
{

    [SerializeField]
    public BattleSystem system;
    private Vector2 minPosition = new Vector2(189.6f, 912.5f);
    private Vector2 maxPosition = new Vector2(1004.4f, 1063.85f);
    private List<GameObject> extraList = new List<GameObject>();
    public ItemSpawner itemSpawner;

    public void Erase()
    {
        foreach (GameObject member in system.members)
        {
            if (!(member.transform.position.x < minPosition[0] || member.transform.position.x > maxPosition[1] || member.transform.position.y < minPosition[1] || member.transform.position.y > maxPosition[1]))
            {
                extraList.Add(member);
            }
        }
        foreach (GameObject member in extraList)
        {
            system.members.Remove(member);
            Destroy(member);
        }
        extraList.Clear();

        foreach(GameObject module in system.modules)
        {
            if (!(module.transform.position.x < minPosition[0] || module.transform.position.x > maxPosition[1] || module.transform.position.y < minPosition[1] || module.transform.position.y > maxPosition[1]))
            {
                extraList.Add(module);
            }
        }
        foreach (GameObject module in extraList)
        {
            system.modules.Remove(module);
            Destroy(module);
        }
        extraList.Clear();

        foreach (GameObject mega in system.megas)
        {
            if (!(mega.transform.position.x < minPosition[0] || mega.transform.position.x > maxPosition[1] || mega.transform.position.y < minPosition[1] || mega.transform.position.y > maxPosition[1]))
            {
                extraList.Add(mega);
            }
        }
        foreach (GameObject mega in extraList)
        {
            system.megas.Remove(mega);
            Destroy(mega);
        }
        extraList.Clear();

        foreach (GameObject objeto in itemSpawner.objectList)
        {
            if (!(objeto.transform.position.x < minPosition[0] || objeto.transform.position.x > maxPosition[1] || objeto.transform.position.y < minPosition[1] || objeto.transform.position.y > maxPosition[1]))
            {
                extraList.Add(objeto);
            }
        }
        foreach(GameObject objeto in extraList)
        {
            itemSpawner.objectListId.RemoveAt(itemSpawner.objectList.IndexOf(objeto));
            itemSpawner.objectList.Remove(objeto);
            Destroy(objeto);
        }
        
       
    }
}
