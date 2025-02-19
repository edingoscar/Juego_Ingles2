using System;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    private Animator animator;

    public AudioClip AbrirSound;
    public AudioClip CerrarSound;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !animator.GetBool("Open")){
            animator.SetBool("Open", true);
            SoundFXManager.instance.PlaySoundFXClip(AbrirSound, transform, 1f);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && animator.GetBool("Open")){
            animator.SetBool("Open", false);
            SoundFXManager.instance.PlaySoundFXClip(CerrarSound, transform, 1f);
        }
    }
}
