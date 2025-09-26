using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// must add this using statement to use TMP_Text
using TMPro;



public class DialogManager : MonoBehaviour
{

    public TMP_Text textbox;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    private void OnEnable()
    {
        StartCoroutine(Type());
    }

    IEnumerator Type()
    {
        textbox.text = "";

        foreach (char letter in sentences[index])
        {
            textbox.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
