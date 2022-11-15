using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogTercerNivel : MonoBehaviour
{

    private bool isPlayerRange;
    [SerializeField] private GameObject dialog;
    

    void Update()
    {
        if(isPlayerRange)
        {
            
        }
        
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerRange = true;
            dialog.SetActive(true);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerRange = false;
            dialog.SetActive(false);

        }
    }
}
