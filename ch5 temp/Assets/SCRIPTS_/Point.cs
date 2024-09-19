using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    [SerializeField] private GameObject _explosionParticlePrefab;
    [SerializeField] private GameObject _explosionAudio;
    [SerializeField] private GameObject point;

    void Start(){
        point = GameObject.Find("CORE");
    }
    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "ammo"){
            point.GetComponent<POINT1>().Add(1);

            Destroy(other.gameObject);


            Instantiate(_explosionParticlePrefab, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            

            var audio = Instantiate(_explosionAudio, this.transform.position, Quaternion.identity);
            var audioSource = audio.GetComponent<AudioSource>();
            float time = audioSource.clip.length;
            audioSource.Play();

            StartCoroutine(WaitForAudio(time, audio));
        }
    }
    private IEnumerator WaitForAudio(float time, GameObject audio)
    {
        yield return new WaitForSeconds(time);
        Destroy(audio);
    }
}
