/*using UnityEngine;
using System.Collections;   

public class InventoryManagment : MonoBehaviour
{

    public GameObject player;
    public GameObject inv;
    public GameObject itemdrop;
    public int slot;
    public GameObject Item1;
    public GameObject Item2; 
    public GameObject Item3;
    //public GameObject[] Items;
    

    void DropItem()
    {
        //oprawi mecha!!!!!!!!!!!!!!!!
        if (slot == 1)
        {
            Item1.transform.parent = itemdrop.transform;
        }
        else if (slot == 2)
        {
            Item2.transform.parent = itemdrop.transform;
        }
        else if (slot == 3)
        {
            Item3.transform.parent = itemdrop.transform;
        }
    }

    void PickUpItem()
    {
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        slot = 1;
        int i = 1;
        foreach (Transform child in transform)
        {
            //Items[i] = child;
            if (i == 1)
                Item1 = child.gameObject;
            if (i == 2)
                Item2 = child.gameObject;
            if (i == 3)
                Item3 = child.gameObject;
            i++;
        }
        Item1.SetActive(true);
        Item2.SetActive(false);
        Item3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("1"))
        {
            slot = 1;
            if (Item1)
                Item1.SetActive(true);
            if (Item2)
                Item2.SetActive(false);
            if (Item3)
                Item3.SetActive(false);
        }
        if (Input.GetKeyDown("2"))
        {
            slot = 2;
            if (Item2)
                Item2.SetActive(true);
            if (Item1)
                Item1.SetActive(false);
            if (Item3)
                Item3.SetActive(false);
        }
        if (Input.GetKeyDown("3"))
        {
            slot = 1;
            if (Item3)
                Item3.SetActive(true);
            if (Item1)
                Item1.SetActive(false);
            if (Item2)
                Item2.SetActive(false);
        }
        if(Input.GetKey("q"))
        {
            DropItem();
        }
    }
}*/

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
    {/*
        if (player != null && player.transform.position.x <= 63 && player.transform.position.x >= 54)
        {
            showButton();
        }
        public GameObject player;
    public GameObject button;

    private void Start()
    {
        button.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        button.SetActive(false);
        if (player != null && player.transform.position.x <= 63 && player.transform.position.x >= 54)
        {
            showButton();
        }
    }

    public void showButton()
    {
        button.SetActive(true);
    }*/
        //int i = 0;
        foreach (Transform child in itemdrop.transform)
        {
            if (player != null && player.transform.position.x <= child.transform.position.x - 5.0f && player.transform.position.x >= child.transform.position.x + 5.0f)
            {
                if(Input.GetKeyDown("e"))
                {
                    //put it in argh kod
                    Debug.Log("sigma");
                }
            }
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
                items[i].SetActive(i == 0); // Activate first item, deactivate others
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
        PickUpItem();
    }
}