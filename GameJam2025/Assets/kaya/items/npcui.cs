using System.Collections;
using UnityEngine;
using TMPro;

public class npcui : MonoBehaviour
{
    private AudioSource audioSource;
    private npc npcScript;

    [Header("Audio Clips")]
    public AudioClip one;
    public AudioClip lockedaudio;
    public AudioClip[] choiceAudio;
    public AudioClip[] responseAudio;

    [Header("Dialogue Text")]
    public string text;
    public string textlocked;
    public string[] choiceTexts;
    public string[] responseTexts;

    [Header("UI Elements")]
    public TextMeshProUGUI displayText;
    public TextMeshProUGUI[] choiceButtons;

    private bool isChoosing = false;
    private int currentChoiceSet = 0;
    public bool speak = false; // Controlled by npc.cs

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        npcScript = GetComponent<npc>();
    }

    private void Update()
    {
        if (speak)
        {
            if (!isChoosing && Input.GetKeyDown(KeyCode.Space))
            {
                StartDialogue();
            }

            if (isChoosing)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1)) SelectChoice(0);
                if (Input.GetKeyDown(KeyCode.Alpha2)) SelectChoice(1);
                if (Input.GetKeyDown(KeyCode.Alpha3)) SelectChoice(2);
            }
        }
    }

    private void StartDialogue()
    {
        displayText.text = text;
        StartCoroutine(PlayAudioAndProceed(one, ShowChoices));
    }

    private void ShowChoices()
    {
        isChoosing = true;
        for (int i = 0; i < 3; i++)
        {
            int choiceIndex = currentChoiceSet * 3 + i;
            choiceButtons[i].text = choiceTexts[choiceIndex];
        }
    }

    private void SelectChoice(int choiceIndex)
    {
        isChoosing = false;
        int globalChoiceIndex = currentChoiceSet * 3 + choiceIndex;
        displayText.text = choiceTexts[globalChoiceIndex];
        StartCoroutine(PlayAudioAndProceed(choiceAudio[globalChoiceIndex], () => ShowResponse(globalChoiceIndex)));
    }

    private void ShowResponse(int globalChoiceIndex)
    {
        if (currentChoiceSet < 3)
        {
            displayText.text = responseTexts[globalChoiceIndex];
            StartCoroutine(PlayAudioAndProceed(responseAudio[globalChoiceIndex], () =>
            {
                currentChoiceSet++;
                ShowChoices();
            }));
        }
        else
        {
            EndDialogue(); // End dialogue without NPC response
        }
    }

    private void EndDialogue()
    {
        displayText.text = " ";
        // You can add any additional cleanup or logic here
    }

    private IEnumerator PlayAudioAndProceed(AudioClip clip, System.Action nextStep)
    {
        if (clip != null)
        {
            audioSource.Stop();
            audioSource.clip = clip;
            audioSource.Play();
            yield return new WaitForSeconds(clip.length);
        }
        nextStep?.Invoke();
    }
}
