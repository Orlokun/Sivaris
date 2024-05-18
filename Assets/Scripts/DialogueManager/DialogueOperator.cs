using System;
using System.Collections;
using System.Collections.Generic;
using ShopManagement;
using TMPro;
using UI;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DialogueManager
{
    public interface IDialogueOperator
    {
        public void ToggleUI(bool isActive);

        event DialogueOperator.FinishedDialogueReading OnDialogueCompleted;
        void StartNewDialogue(IDialogue newDialogue);
    }

    public class DialogueOperator : MonoBehaviour, IDialogueOperator
    {
        private UIDialogueState _currentState;
        private IDialogue _currentDialogue;

        public delegate void FinishedDialogueReading();

        public void ToggleUI(bool isActive)
        {
            gameObject.SetActive(isActive);
        }

        public event FinishedDialogueReading OnDialogueCompleted;

        [SerializeField] private GameObject nextLineButton;
        [SerializeField] private TMP_Text mDialogueTextObject;
        private const float MaxWritingSpeed = 0.03f;
        private const float MinWritingSpeed = 0.05f;
        
        private Coroutine _typingMachineCoroutine;
        private int _mCurrentDialogueLine;
        
        public void StartNewDialogue(IDialogue newDialogue)
        {
            _currentState = UIDialogueState.TypingText;
            Debug.Log("Starting new Dialogue");
            SetIncomingDialogue(newDialogue);

            UIManager.Instance.ToggleDialogueUI(true);
            _mCurrentDialogueLine = 0;
            WriteNextDialogueNode(_currentDialogue, _mCurrentDialogueLine);
        }

        public void WriteNextDialogueNode(IDialogue dObject, int newDialogueIndex)
        {
            if (dObject != _currentDialogue)
            {
                return;
            }
            var dialogueNode = dObject.DialogueNodes[newDialogueIndex];
            StartCoroutine(WriteDialogueNode(dialogueNode));
            return;
        }
        private IEnumerator WriteDialogueNode(IDialogueNode dialogueNode)
        {

            //Make Sure no other line is being written at the moment
            if (_typingMachineCoroutine != null)
            {
                StopCoroutine(_typingMachineCoroutine);
            }

            //Start Typewriter effect of the current line    
            mDialogueTextObject.text = "";
            _typingMachineCoroutine = StartCoroutine(WriteDialogueLine(dialogueNode));
            
            //Wait for the conditions to be met in order to continue the loop
            yield return new WaitUntil(NextLineWritingConditions);

            //The following line of code makes the coroutine wait for a frame so as the next WaitUntil is not skipped
            yield return null;
            if (_currentDialogue.DialogueNodes.Count == _mCurrentDialogueLine +1)
            {
                CleanDialoguesAndClose();
            }
            else
            {
                _mCurrentDialogueLine++;
                WriteNextDialogueNode(_currentDialogue,_mCurrentDialogueLine);
            }
        }

        private void CleanDialoguesAndClose()
        {
            Debug.Log("[DialogueOperator.WriteDialogueNode] Finished going through dialogue");
            _currentState = UIDialogueState.NotDisplayed;
            _mCurrentDialogueLine = 0;
            _currentDialogue = null;
            UIManager.Instance.DialogueManager.ToggleUI(false);
            OnDialogueCompleted?.Invoke();
        }
        
        

        private bool NextLineWritingConditions()
        {
            return Input.GetKeyDown(KeyCode.Space) && _currentState == UIDialogueState.FinishedLine;
        }
        private IEnumerator WriteDialogueLine(IDialogueNode dialogueNode)
        {
            _currentState = UIDialogueState.TypingText;
            var isAddingHtmlTag = false; //Used to manage tags inside text so they don't appear in the UI.

            //_soundMachine.StartPlayingSound(); //TODO: Get sound foreach character

            nextLineButton.SetActive(false);

            foreach (var letter in dialogueNode.DialogueLineText)
            {
                //Check if player is hurrying Dialogue and we have more than 3 characters.
                if (Input.GetKey(KeyCode.Space) && mDialogueTextObject.text.Length > 3)
                {
                    mDialogueTextObject.text = dialogueNode.DialogueLineText;
                    break;
                }

                //Manage the use of html tags in text
                if (letter == '<' || isAddingHtmlTag)
                {
                    isAddingHtmlTag = true;
                    mDialogueTextObject.text += letter;
                    if (letter == '>')
                    {
                        isAddingHtmlTag = false;
                    }
                }
                //If is not a tag add characters with Typing effect.
                else
                {
                    //Add characters one by one with a little random component
                    mDialogueTextObject.text += letter;
                    Random.InitState(DateTime.Now.Millisecond);
                    var typingSpeed = Random.Range(MinWritingSpeed, MaxWritingSpeed);
                    yield return new WaitForSeconds(typingSpeed);
                }
            }
            nextLineButton.SetActive(true);
            //_soundMachine.PausePlayingSound();
            _currentState = UIDialogueState.FinishedLine;
        }

        private void SetIncomingDialogue(IDialogue newDialogue)
        {
            if (newDialogue == null)
            {
                return;
            }

            _currentDialogue = newDialogue;
            if (_currentDialogue == null)
            {
                Debug.LogError("Current Dialogue must not be null after loading");
                return;
            }
        }
    }

    public interface IDialogueNode
    {
        int DialogueLineIndex { get; }
        string DialogueLineText { get; }
    }

    public enum FindEventId
    {
        Tomb1 = 0,
        Tomb2,
        Tomb3,
        Tomb4,
        Chest1
    }
    
    public class DialogueNode : IDialogueNode
    {
        private int _mDialogueLineIndex;
        private string _mDialogueLine;
        private FindEventId _mEventIdId;

        public DialogueNode(int mDialogueLineIndex, string mDialogueLine)
        {
            _mDialogueLineIndex = mDialogueLineIndex;
            _mDialogueLine = mDialogueLine;
        }

        public int DialogueLineIndex =>_mDialogueLineIndex;
        public string DialogueLineText =>_mDialogueLine;
    }
    
    public class Dialogue : IDialogue
    {
        public List<DialogueNode> DialogueNodes => _mDialogueNodes;
        private List<DialogueNode> _mDialogueNodes;

        public Dialogue(List<DialogueNode> mDialogueNodes)
        {
            _mDialogueNodes = mDialogueNodes;
        }
    }

    public interface IDialogue
    {
        public List<DialogueNode> DialogueNodes { get; }
    }
}