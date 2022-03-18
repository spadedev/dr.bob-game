using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWings : MonoBehaviour
{
    [SerializeField] private float damage;
    public float amp;
    public float freq;
    Vector3 initPos;
    public AudioSource damageSound;

    private void Start()
    {
        initPos = transform.position;
        damageSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        transform.position = new Vector3(initPos.x, Mathf.Sin(Time.time * freq) * amp + initPos.y, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            damageSound.Play();
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
