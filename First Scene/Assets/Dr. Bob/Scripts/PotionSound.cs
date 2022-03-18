using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionSound : MonoBehaviour
{
    public AudioClip potionSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioSource.PlayClipAtPoint(potionSound, transform.position);
    }
}
