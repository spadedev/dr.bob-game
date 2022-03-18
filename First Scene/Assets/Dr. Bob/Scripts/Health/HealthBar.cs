using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image total;
    [SerializeField] private Image current;

    private void Start()
    {
        total.fillAmount = playerHealth.current / 10;
    }

   
    private void Update()
    {
        current.fillAmount = playerHealth.current / 10;
    }
}
