using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Collectable : MonoBehaviour
{
    public int currentColorBox = 0;
    public int currentColor;
    public Transform lightColor;
    public Transform player;
    public bool playerEntered;

    // Update is called once per frame
    void Update()
    {
        switch (currentColor)
        {
            case 0:
                lightColor.GetComponent<Light2D>().color = Color.white;
                break;
            case 1:
                lightColor.GetComponent<Light2D>().color = Color.red;
                break;
            case 2:
                lightColor.GetComponent<Light2D>().color = Color.green;
                break;
            case 3:
                lightColor.GetComponent<Light2D>().color = Color.blue;
                break;
            default: 
                lightColor.GetComponent<Light2D>().color = Color.white;
                break;
        }
        if(playerEntered){
            currentColorBox = player.GetComponent<PlayerController>().currentColor;
            if(currentColor == currentColorBox){
                player.GetComponent<PlayerController>().points += 1;
                Destroy(gameObject);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")playerEntered = true;
    }
    void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.name == "Player")playerEntered = false;
    }
}
