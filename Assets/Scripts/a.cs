using UnityEngine;

public class a : MonoBehaviour
{
    public GameObject button;
    public GameObject oobject;
    public GameObject player;
    public int offset;
    float far;
    float close;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        far = oobject.transform.position.x + offset;
        close = oobject.transform.position.x - offset;
        button.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x < far && player.transform.position.x > close)
        {
            button.SetActive(true);
        }
        else
        {
            button.SetActive(false);
        }
    }
}
