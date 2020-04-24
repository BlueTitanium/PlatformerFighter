using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class SpeedTile : MonoBehaviour
{
    public int currentColorBox = 0;
    public int currentColor;
    public float multiplier;
    public Transform lightColor;
    public Transform player;
    public bool playerEntered;
    static float t = 0.0f;
    // Update is called once per frame
    void FixedUpdate()
    {
//        player.GetComponent<PlayerController>().speed = Mathf.Lerp(player.GetComponent<PlayerController>().speed, player.GetComponent<PlayerController>().originalSpeed, t);
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
                if(player.GetComponent<PlayerController>().speed < player.GetComponent<PlayerController>().originalSpeed * multiplier)
                    player.GetComponent<PlayerController>().speed *= multiplier;
            }
            if(currentColor != currentColorBox){
                player.GetComponent<PlayerController>().speed = player.GetComponent<PlayerController>().originalSpeed;
            }
        }
        if(!playerEntered){
            player.GetComponent<PlayerController>().speed = Mathf.SmoothStep(player.GetComponent<PlayerController>().speed, player.GetComponent<PlayerController>().originalSpeed, Time.deltaTime);
        }
    }
    //void OnTriggerStay2D(Collider2D other) {
    //    currentColorBox = other.gameObject.GetComponent<PlayerController>().currentColor;
    //}
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")playerEntered = true;
        t = 0f;
    }
    void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.name == "Player")playerEntered = false;
        ExecuteAfterTime(1);
    }
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        player.GetComponent<PlayerController>().speed = player.GetComponent<PlayerController>().originalSpeed;
    }
}
