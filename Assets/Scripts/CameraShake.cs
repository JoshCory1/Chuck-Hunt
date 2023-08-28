using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeDuration = 1f;
    [SerializeField] float shakeMagintude = 1f;
    Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, true);
        Debug.Log(Screen.currentResolution);
        initialPosition = transform.position;
    }

    public void Play()
    {
         StartCoroutine(Shake());
    }
    IEnumerator Shake()
    {
        float elapsedtime = 0;
        while(elapsedtime < shakeDuration)
        {
        transform.position = initialPosition + (Vector3)Random.insideUnitCircle * shakeMagintude;
        elapsedtime += Time.deltaTime;
        yield return new WaitForEndOfFrame();
        }
        transform.position = initialPosition;
             
    } 
}
