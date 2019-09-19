﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableTriggerOnPlayerExit : MonoBehaviour
{
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        { // When the player exits the trigger area
            Debug.Log("処理");
            GetComponent<Collider>().isTrigger = false; // Disable the trigger
        }
    }
}
