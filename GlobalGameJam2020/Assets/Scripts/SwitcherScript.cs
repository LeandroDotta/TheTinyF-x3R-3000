﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitcherScript : MonoBehaviour
{
    public GameObject[] elements = new GameObject[1];
    private SpriteRenderer spriteRenderer;
    public Sprite[] switcherSprites = new Sprite[2];
    private bool isOn = false;
    private bool keyPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
      if(other.tag == "Player") {
        if (Input.GetKeyDown(KeyCode.X) && !keyPressed)
        {
          keyPressed = true;
            foreach (GameObject element in elements)
            {
                element.SendMessage("Switch");
            }
            if(isOn) {
                spriteRenderer.sprite = switcherSprites[0];
                isOn = false;
            } else {
                spriteRenderer.sprite = switcherSprites[1];
                isOn = true;
            }
            Debug.Log("Switched");
            SoundController.Instance.PlaySFX(17);
        }
        if (Input.GetKeyUp(KeyCode.X)) {
          keyPressed = false;
        }
      }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
      keyPressed = false;
    }
}
