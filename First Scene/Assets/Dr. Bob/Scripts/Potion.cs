using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Potion : MonoBehaviour
{
    private float potion = 0;

    public TextMeshProUGUI textPotions;
   


    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.transform.tag == "Potions")
        {
            potion++;
            textPotions.text = potion.ToString();

            Destroy(other.gameObject);
        }
    }
}
