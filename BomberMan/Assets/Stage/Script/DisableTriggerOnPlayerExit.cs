using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableTriggerOnPlayerExit : MonoBehaviour
{
    public Player_2 Pl;
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        { // When the player exits the trigger area
            GetComponent<Collider>().isTrigger = false; // Disable the trigger
        }
        if (other.gameObject.CompareTag("Player_2"))
        { // When the player exits the trigger area
            GetComponent<Collider>().isTrigger = false; // Disable the trigger
        }
        if (other.gameObject.CompareTag("Player_3"))
        { // When the player exits the trigger area
            GetComponent<Collider>().isTrigger = false; // Disable the trigger
        }
        if (other.gameObject.CompareTag("Player_4"))
        { // When the player exits the trigger area
            GetComponent<Collider>().isTrigger = false; // Disable the trigger
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Pl.PlayerNumber == 1)
                Pl.canDropBombs[0] = false;
        }
        if (other.gameObject.CompareTag("Player_2"))
        {
            if (Pl.PlayerNumber == 2)
                Pl.canDropBombs[0] = false;
        }
        if (other.gameObject.CompareTag("Player_3"))
        {
            if (Pl.PlayerNumber == 3)
                Pl.canDropBombs[0] = false;
        }
        if (other.gameObject.CompareTag("Player_4"))
        {
            if (Pl.PlayerNumber == 4)
                Pl.canDropBombs[0] = false;
        }
    }
}
