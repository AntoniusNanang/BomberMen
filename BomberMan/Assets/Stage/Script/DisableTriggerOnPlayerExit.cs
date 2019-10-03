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
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Pl.PlayerNumber == 1)
                Pl.canDropBombs[0] = false;
        }
    }
}
