using System;
using System.Collections;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
//If you see this code please mark the number of hours it has taken to try and fix this: 2 hrs

    public class FreezeAndPlayAudio : MonoBehaviour
    {
        private FirstPersonController firstPersonController;
        private AudioSource audioSource;

        void Start()
        {
            firstPersonController = GetComponent<FirstPersonController>();
            audioSource = GetComponent<AudioSource>();
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("FreezeTrigger"))
            {
                Debug.Log("Trigger has been entered");
                StartCoroutine(FreezeAndPlay());
                Debug.Log("FreezeAndPlay has been activated");
            }
        }

        IEnumerator FreezeAndPlay()
        {
            firstPersonController.enabled = false;
            Debug.Log("Rigid body frozen");

            audioSource.Play();
            Debug.Log("Audio has been played");

            Debug.Log("Waiting 10 seconds....");
            yield return new WaitForSeconds(10f);

            firstPersonController.enabled = true;
            Debug.Log("Rigid body is no longer frozen");
        }
    }


