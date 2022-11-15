using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BarraDeSalud : MonoBehaviour
{
    [SerializeField] private Salud playerHealth;
    [SerializeField] private Image totalHealth;
    [SerializeField] private Image currentHealthBar;


    void Start()
    {
        totalHealth.fillAmount = playerHealth.currentHealth / 10;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealthBar.fillAmount = playerHealth.currentHealth / 10;
    }
}
