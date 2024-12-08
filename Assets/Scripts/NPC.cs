using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public GameObject diabloPanel;
    public Text diabloText;
    public string[] dialogue;
    private int index;

    public GameObject contButton;

    public float wordSpeed;
    public bool playerIsClose;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && playerIsClose)
        {
            if (diabloPanel.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                diabloPanel.SetActive(true);
                StartCoroutine(Tying());
            }
        }
        if (diabloText.text == dialogue[index])
        {
            contButton.SetActive(true);
        }
    }
    public void zeroText()
    {
        diabloText.text = "";
        index = 0;
        diabloPanel.SetActive(false);
    }
    public void NextLine()
    {
        contButton.SetActive(false);
        if (index < dialogue.Length - 1)
        {
            index++;
            diabloText.text = "";
            StartCoroutine(Tying());
        }
        else
        {
            zeroText();
        }

    }

    IEnumerator Tying()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            diabloText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            zeroText();
        }
    }
}
