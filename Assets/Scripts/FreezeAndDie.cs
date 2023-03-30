using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
//If you see this code please mark the number of hours it has taken to try and fix this: 2 hrs

public class FreezeAndDie : MonoBehaviour
{
    private FirstPersonController firstPersonController;

    public TMP_Text newSubtitle;
    public TMP_Text currentSubtitle;
    public TMP_Text nextSubtitle;

    void Start()
    {
        firstPersonController = GetComponent<FirstPersonController>();
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

        currentSubtitle.enabled = false;
        Debug.Log("Previous subtitle removed");

        newSubtitle.enabled = true;
        Debug.Log("UI Text is enabled");

        Debug.Log("Waiting 4 seconds....");
        yield return new WaitForSeconds(4f);

        newSubtitle.enabled = false;
        Debug.Log("UI Text is enabled");

        nextSubtitle.enabled = true;
        Debug.Log("next subtitle is active");

        Debug.Log("Waiting 4 seconds....");
        yield return new WaitForSeconds(4f);

        Application.Quit();
    }
}


