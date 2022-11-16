using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BitShower : MonoBehaviour
{
    [SerializeField]
    private AudioClip _audioClip;
    [SerializeField]
    private GameObject _gameObject;
    private AudioSource _audioSource;
    private AudioProcessor processor;


    private void Awake()
    {
       _audioSource = GetComponent<AudioSource>();
       processor = FindObjectOfType<AudioProcessor>();
       processor.onBeat.AddListener(OnOnbeatDetected);
       //processor.onSpectrum.AddListener(onSpectrum);

    }

    private void OnOnbeatDetected()
    {
        Debug.Log("Beat");
        _gameObject.SetActive(true);
        StartCoroutine(Flash());
    }

    private void Update() 
    {

        _audioSource.PlayOneShot(_audioClip);

    }
    private IEnumerator Flash()
    {
        yield return new WaitForSeconds(0.1f);
        _gameObject.SetActive(false);
    }
}
