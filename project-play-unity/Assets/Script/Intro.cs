using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.SceneManagement;
using static Unity.VisualScripting.Member;

public class TextBox : MonoBehaviour
{
    //reference to textmeshpro component
    public TextMeshProUGUI textComponent;
    //variable for the lines 
    public string[] lines;
    //variable for the writing speed
    public float textSpeed;
    //variable to check were it is at writing out
    private int index;
    //Variables for the audio clips that are played
    public AudioSource source;
    public AudioClip Typing;
    public AudioClip Crash;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        //exectes the function that starts the writing/typing
        StartTextWriting();
        source = GetComponent<AudioSource>();
        source.PlayOneShot(Typing);
        source.PlayOneShot(Crash);
    }

    // Update is called once per frame
    void Update()
    {
        //When the left mouse button is pressed then this will load the mainscene
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    void StartTextWriting()
    {
        //so it starts form 0
        index = 0;
        //starting the typeline function
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        //breaks string down into characters
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            //making the text speed possible
            yield return new WaitForSeconds(textSpeed);
        }
    }

    //this is for writing out more lines this is used for converstations
    //but is not yet used in this project
    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}