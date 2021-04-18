using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class key : item
{
    public Sprite keySprite;
    public GameObject keyCollectorNotif;
    public Image keyImage;
    public Text notif;
    private bool isTimerStart = false;
    private float timer = 0;
    public GameObject keyOBJ;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Interact")
        {
            keyImage.sprite = keySprite;
            notif.text = "Key Found!";
            print("Key Found!");
            keyOBJ.SetActive(false);
            keyCollectorNotif.SetActive(true);
            PlayerPrefs.SetInt("keyAmt", PlayerPrefs.GetInt("keyAmt") + 1);
            show();
           
        }
    }

    void show()
    {
        Invoke("hide", 2f);
    }

    void hide()
    {
        keyCollectorNotif.SetActive(false);
    }


}
