using UnityEngine;
using UnityEngine.UI;

public class InventoryManagment : MonoBehaviour
{
    public GameObject player;
    public GameObject inv;
    public GameObject itemdrop;
    public int slot;

    public GameObject emptyobject;

    public GameObject[] items = new GameObject[3];
    public GameObject[] slots = new GameObject[3];

    void DropItem()
    {
        int index = slot - 1;
        if (index >= 0 && index < items.Length && items[index] != null)
        {
            items[index].transform.parent = itemdrop.transform;
            items[index] = null;
            slots[index].transform.GetChild(0).GetComponent<Image>().sprite = emptyobject   .GetComponent<SpriteRenderer>().sprite;
        }
    }
    void PickUpItem()
    {
    Transform nearestItem = null;
    float minDistance = Mathf.Infinity;
    float maxDistance = 3.0f;

    foreach (Transform child in itemdrop.transform)
    {
        float distance = Vector3.Distance(player.transform.position, child.position);
        if (distance < maxDistance)
        {
            minDistance = distance;
            nearestItem = child;
        }
    }
    bool flag = false;
    if (nearestItem != null)
    {
        Debug.Log("Nearest item: " + nearestItem.name);
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                items[i] = nearestItem.gameObject;
                items[i].transform.parent = this.transform;
                items[i].SetActive(i == slot - 1);
                //slots[i].Child.GetComponent<Image>().sourceimage = nearestItem.GetComponent<SpriteRenderer>().sprite;
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = nearestItem.GetComponent<SpriteRenderer>().sprite;
                flag = true;
                return;
            }
        }
        if(!flag)
        {
                DropItem();
                items[slot - 1] = nearestItem.gameObject;
                items[slot - 1].transform.parent = this.transform;
                //items[slot - 1].SetActive(i == slot - 1);
                //slots[i].Child.GetComponent<Image>().sourceimage = nearestItem.GetComponent<SpriteRenderer>().sprite;
                slots[slot - 1].transform.GetChild(0).GetComponent<Image>().sprite = nearestItem.GetComponent<SpriteRenderer>().sprite;

        }

        //DropItem();
        //PickUpItem(); 
    }
}

void Start()
    {
        slot = 1;
        int i = 0;
        foreach (Transform child in transform)
        {
            if (i < items.Length)
            {
                items[i] = child.gameObject;
                items[i].SetActive(i == 0);
                i++;
            }
        }
    }

    void Update()
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (Input.GetKeyDown((i + 1).ToString()))
            {
                slots[slot - 1].GetComponent<Image>().color = new Color32(255,255,255,100);
                slot = i + 1;
                slots[i].GetComponent<Image>().color = new Color32(125, 255, 129, 100);
                for (int j = 0; j < items.Length; j++)
                {
                    if (items[j] != null)
                        items[j].SetActive(j == i);
                }
            }
        }

        if (Input.GetKey("q"))
        {
            DropItem();
        }
        if(Input.GetKeyDown("e"))
        {
            PickUpItem();
        }
    }
}