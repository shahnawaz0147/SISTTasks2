using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Windows.Speech;
using System.Linq;
public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public InputField inputField;
    public InputField inputField1;


    KeywordRecognizer keywordRecognizer;
    Dictionary<string, System.Action> KeywordActions;
    public void LeftButtonClick()
    {
        inputField1 = inputField;
        inputField.text = "Left";
        inputField = inputField1;
    }
    public void RightButtonClick()
    {
        inputField1 = inputField;
        inputField.text = "Right";
        inputField = inputField1;
    }
    void Start()
    {
        KeywordActions = new Dictionary<string, System.Action>();
        KeywordActions.Add("Left", () =>
        {
            LeftButtonClick();
        });
        KeywordActions.Add("Right", () =>
        {
            RightButtonClick();
        });
        keywordRecognizer = new KeywordRecognizer(KeywordActions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        keywordRecognizer.Start();
    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;
        // if the keyword recognized is in our dictionary, call that Action.
        if (KeywordActions.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }
    void OnGUI()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            try
            {
                RightButtonClick();
            }
            catch (Exception ex)
            { 
            
            }
        }
       else if (Input.GetKeyDown(KeyCode.L))
        {
            try
            {
                LeftButtonClick();
            }
            catch (Exception ex)
            { 
            
            }
        }
        else if (Input.GetMouseButton(0))
        {
            try
            {
                LeftButtonClick();
            }
            catch (Exception ex)
            {

            }
        }

        else if (Input.GetMouseButton(1))
        {
            try
            {
                RightButtonClick();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
