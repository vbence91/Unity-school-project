using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;

    [SerializeField] private AudioSource deathSoundEffect;

    [SerializeField] private Text dc;
    private static int death;

    private bool dead = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            dc.text = "Death counter: " + death;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap") || collision.gameObject.CompareTag("Enemy"))
        {
            if (!dead)
            {
                dead = true;
                death++;
                dc.text = "";
                dc.text = "Death counter: " + death;
                PlayerPrefs.SetInt("coins", 0);
                PlayerPrefs.SetInt("death", death);
                Die();
            }
            
        }
    }

    private void Die()
    {
        deathSoundEffect.Play();
        anim.SetTrigger("death");
        rb.bodyType = RigidbodyType2D.Static;
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
