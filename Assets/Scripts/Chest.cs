using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private bool isOpened;
    public PlayerMovement player;
    public GameObject lootPanel;
    public Chest otherChest;

    public Sprite openChest;

    private void Start()
    {
        lootPanel.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isOpened == false)
        {
            GetComponent<SpriteRenderer>().sprite = openChest;
            lootPanel.SetActive(true);
            player.enabled = false;
            isOpened = true;
            if (otherChest != null) otherChest.gameObject.SetActive(false);
            StartCoroutine(ExitChest());
        }
    }

    private IEnumerator ExitChest()
    {
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        lootPanel.SetActive(false);
        player.enabled = true;
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
