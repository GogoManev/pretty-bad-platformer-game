using UnityEngine;

public class InventoryManagment : MonoBehaviour
{
    public GameObject player;
    public GameObject inv;
    public GameObject itemdrop;
    public int slot;

    public GameObject[] items = new GameObject[3];

    void DropItem()
    {
        int index = slot - 1;
        if (index >= 0 && index < items.Length && items[index] != null)
        {
            items[index].transform.parent = itemdrop.transform;
            items[index] = null;
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

    if (nearestItem != null)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                items[i] = nearestItem.gameObject;
                items[i].transform.parent = this.transform;
                items[i].SetActive(i == slot - 1);
                return;
            }
        }

        DropItem();
        PickUpItem(); 
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
                slot = i + 1;
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