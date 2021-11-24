using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int oranges = 0;

    [SerializeField] private Text orangeText;

   // [SerializeField] private AudioSource collectionSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Orange"))
        {
            //collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            oranges++;
            orangeText.text = "Oranges: " + oranges;
        }
    }
}