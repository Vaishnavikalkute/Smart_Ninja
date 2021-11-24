using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_life : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private BoxCollider2D colli;

    //[SerializeField] private AudioSource deathSoundEffect;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        colli = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("trap"))//compare if the collision is with trap
        {
            
            FindObjectOfType<gameManager>().EndGame();
            Die();
        }
    }

    private void Die()
    {
        // deathSoundEffect.Play();
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");


       
    }

    //private void RestartLevel()
    //{
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //}
}