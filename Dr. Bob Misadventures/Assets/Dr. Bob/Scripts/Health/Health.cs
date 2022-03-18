using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float starting;
    [SerializeField] private string sceneName;
    public float current { get; private set; }
    private Animator anim;
    private bool dead;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;



    private void Awake()
    {
        current = starting;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();

    }

    public void TakeDamage(float _damage)
    {
        current = Mathf.Clamp(current - _damage, 0, starting);

        if (current > 0)
        {
            StartCoroutine(Invulnerability());
        }
        else
        {
            if(!dead)
            {
                anim.SetTrigger("Die");
                GetComponent<PlayerMovement>().enabled = false;
                dead = true;
                SceneManager.LoadScene(sceneName);
            }
        }
    }

    public void AddHealth(float _value)
    {
        current = Mathf.Clamp(current + _value, 0, starting);
    }

    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(10, 11, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes) * 1);
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes) * 1);
        }
        Physics2D.IgnoreLayerCollision(10, 11, false);
    }
  
}
