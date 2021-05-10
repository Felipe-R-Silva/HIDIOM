using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lighting : MonoBehaviour
{
    [SerializeField] public AudioClip[] ThunderSounds;
    [SerializeField] float timeLeft;

    Animator m_Animator;
    AudioSource my_as;
    private void Start()
    {
        m_Animator = this.gameObject.GetComponent<Animator>();
        my_as = this.GetComponent<AudioSource>();
        StartCoroutine(lightningSequences());
    }
    IEnumerator lightningSequences()
    {
        while (true)
        {
            if(RandomBool())
            {
                float waitTime = Random.Range(5, 100);
                Debug.Log("no blink for "+ waitTime + " seconds");
                yield return new WaitForSeconds(waitTime);
            }
            int nextNound = Random.Range(0, ThunderSounds.Length);
            Debug.Log("preparing to blink");
            StartCoroutine(blink(nextNound));
            GetComponent<AudioSource>().clip = ThunderSounds[nextNound];
            GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(ThunderSounds[nextNound].length);
        }
    }
    IEnumerator blink(float time)
    {
        Debug.Log("blink time");

        if (RandomBool()) 
        {
            m_Animator.SetBool("b1", true);
        }
        yield return new WaitForSeconds(time/4);
        if (RandomBool())
        {
            m_Animator.SetBool("b2", true);
        }
        yield return new WaitForSeconds(time / 4);
        if (RandomBool())
        {
            m_Animator.SetBool("b1", true);
        }
        if (RandomBool())
        {
            m_Animator.SetBool("b2", true);
        }
        if (RandomBool())
        {
            m_Animator.SetBool("b1", false);
        }
        if (RandomBool())
        {
            m_Animator.SetBool("b2", false);
        }
        yield return new WaitForSeconds(time / 4);
        m_Animator.SetBool("b1", false);
        yield return new WaitForSeconds(time / 4);
        m_Animator.SetBool("b2", false);
    }

    public bool RandomBool() 
    {
        int a = Random.Range(0, 2);
        return (a==0);
    }
}

