using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class npcui : MonoBehaviour
{

    public bool played = false;

    AudioSource audio;
    public AudioClip one;
    public AudioClip lockedaudio;
    public AudioClip keuze1audio;
    public AudioClip keuze2audio;
    public AudioClip keuze3audio;

    public AudioClip response1audio;
    public AudioClip response2audio;
    public AudioClip response3audio;




    unlock unlock;
    public string text;
    public string textlocked;
    public string textkeuze1;
    public string textkeuze2;
    public string textkeuze3;

    public TextMeshProUGUI keuze1;
    public TextMeshProUGUI keuze2;
    public TextMeshProUGUI keuze3;


    public string textresponse1;
    public string textresponse2;
    public string textresponse3;


    public TextMeshProUGUI displaytext;
    

    public bool makechoise;
    public bool chosen;
    public bool speak;
    enum choise
    {
        one,
        two,
        three
    }
    public enum stage
    {
        text,
        textkeuze,
        textresponse
    }
    public stage Stage = new stage();
    choise Choise = new choise();

    // Start is called before the first frame update
    void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
        unlock = GetComponentInChildren<unlock>();
    }
    IEnumerator wait(float time)
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(time);


        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
    IEnumerator Startaudio(AudioClip otherClip)
    {
        if (audio == null)
        {
            Debug.LogError("AudioSource is missing on this GameObject!");
            yield break;
        }

        if (otherClip == null)
        {
            Debug.LogError("No AudioClip assigned!");
            yield break;
        }
        Debug.Log(Startaudio(otherClip));
        audio.clip = otherClip;
        audio.Play();
        yield return new WaitForSeconds(otherClip.length);
    }
    IEnumerator PlayAudioAndWait(AudioClip clip, float waitTime)
    {
        
        yield return StartCoroutine(Startaudio(clip)); // Wacht tot de audio klaar is
        if (Stage == stage.text)
        {
            Stage = stage.textkeuze;
        }
        if (Stage == stage.textkeuze)
        {
            Stage = stage.textresponse;
        }
       
        yield return new WaitForSeconds(waitTime); // Extra wachttijd
        if (Stage == stage.textresponse)
        {
            displaytext.text = "";
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (speak)
        {
            if (Stage == stage.text)
            {
                if (!unlock.unlocked)
                {
                    if (Input.GetKeyDown(KeyCode.Space) && !makechoise)
                    {
                        displaytext.text = textlocked;
                        StartCoroutine(Startaudio(lockedaudio));
                        string newtext = "";
                        StartCoroutine(wait(lockedaudio.length));

                    }
                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.Space) && !makechoise)
                    {
                        displaytext.text = text;
                        StartCoroutine(Startaudio(one));
                        if (!chosen)
                        {
                            makechoise = true;
                            keuze1.text = textkeuze1;
                            keuze2.text = textkeuze2;
                            keuze3.text = textkeuze3;
                            Stage = stage.textkeuze;
                        }

                    }
                }
               
            }
            else if (Stage == stage.textkeuze)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    Choise = choise.one;
                    displaytext.text = textkeuze1;
                    StartCoroutine(PlayAudioAndWait(keuze1audio, keuze1audio.length));
                    
                    

                    
                }
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    Choise = choise.two;
                    displaytext.text = textkeuze2;
                    StartCoroutine(PlayAudioAndWait(keuze2audio, keuze2audio.length));


                }
                if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    Choise = choise.three;
                    displaytext.text = textkeuze3;
                    StartCoroutine(PlayAudioAndWait(keuze3audio, keuze3audio.length));

                }

            }
            else if (Stage == stage.textresponse && !played)
            {
                if (Choise == choise.one)
                {
                    displaytext.text = textresponse1;
                    StartCoroutine(PlayAudioAndWait(response1audio,response1audio.length));
                    played = true;
                }
                if (Choise == choise.two)
                {
                    displaytext.text = textresponse2;
                    StartCoroutine(PlayAudioAndWait(response2audio, response2audio.length));
                    played = true;

                }
                if (Choise == choise.three)
                {
                    displaytext.text = textresponse3;
                    StartCoroutine(PlayAudioAndWait(response3audio, response3audio.length));
                    played = true;

                }

            }
        }        
    }
}
