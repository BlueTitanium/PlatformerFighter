using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class JumpTile : MonoBehaviour
{
    public int currentColorBox = 0;
    public int currentColor;
    public int multiplier;
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
                if(player.GetComponent<PlayerController>().jumpForce < player.GetComponent<PlayerController>().originalJumpForce * multiplier)
                    player.GetComponent<PlayerController>().jumpForce *= multiplier;
            }
            if(currentColor != currentColorBox){
                player.GetComponent<PlayerController>().jumpForce = player.GetComponent<PlayerController>().originalJumpForce;
            }
        }
    }
    //void OnTriggerStay2D(Collider2D other) {
    //    currentColorBox = other.gameObject.GetComponent<PlayerController>().currentColor;
    //}
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")playerEntered = true;
    }
    void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.name == "Player")playerEntered = false;
        player.GetComponent<PlayerController>().jumpForce = player.GetComponent<PlayerController>().originalJumpForce;
    }
}
