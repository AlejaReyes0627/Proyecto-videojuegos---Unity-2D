using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NivelCompletado : MonoBehaviour
{
    private bool isPlayerRange;
    public float tiempo_start; //Los segundos por los quales comienza i la variable que utilizaremos para que vaya contando segundos.
    public float tiempo_end = 5; //Segundos que queremos que pasen para que cambie de escena
    [SerializeField] private GameObject dialog;


    void Update()
    {
        if (isPlayerRange)
        {
            tiempo_start += Time.deltaTime;//Función para que la variable tiempo_start vaya contando segundos.
            if (tiempo_start >= tiempo_end) //Si pasan los segundos que hemos puesto antes...
            {
                Application.LoadLevel("MenuInicial");
            }

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
            dialog.SetActive(false);

        }
    }
}
