using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class TextObject : MonoBehaviour
{
    [SerializeField] private float rangeCheckRadius;

    private string text;

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && !Chatbox.IsActive())
        {
            switch (gameObject.tag) //Make sure all of these are replaced with jsons or something
            {
                case "Tower":
                    {
                        text = "My incredible computer tower!/I'm really glad I installed that hole in the basement ceiling~to make it fit!/|";
                        break;
                    }
                case "Bed":
                    {
                        text = "Funny dialogue involving a bed here/|";
                        break;
                    }
                case "Computer":
                    {
                        if (!FlagManager.talkedToComputer)
                        {
                            FlagManager.talkedToComputer = true;
                        }
                        if (!FlagManager.unplugComputer)
                        {
                            text = "Placeholder text: First Computer check/|";
                        }
                        else if (!FlagManager.foundManual)
                        {
                            text = "Placeholder text: Computer after unplugging, before Manual/|";
                        }
                        else if (FlagManager.foundManual) //replace with item functionality
                        {
                            text = "Placeholder text: Second Computer check. This is the first hack./|";
                        }
                    }
                    break;
                case "Plug":
                    {
                        if (!FlagManager.talkedToComputer)
                        {
                            text = "Placeholder text: Wall plug without talking to computer/|";
                        }
                        else if (!FlagManager.unplugComputer)
                        {
                            text = "Placeholder text: Unplugging computer/Computer says rude things about trying to unplug it/|";
                            FlagManager.unplugComputer = true;
                        }
                        else
                        {
                            text = "Placeholder text: Computer is unplugged/|";
                        }
                    }
                    break;
                case "PizzaBox":
                    {
                        if (!FlagManager.unplugComputer)
                        {
                            text = "Placeholder text: Pizza box without unplugging computer/|";
                        }
                        else if (!FlagManager.foundKey)
                        {
                            text = "Placeholder text: Finding key/|";
                            FlagManager.foundKey = true;
                        }
                        else
                        {
                            text = "Placeholder text: Pizza box after finding key/|";
                        }
                    }
                    break;
                case "ManualHolder":
                    {
                        if (!FlagManager.unplugComputer && !FlagManager.foundKey)
                        {
                            text = "Placeholder text: Whatever the manual is locked in~without unplugging computer or finding key/|";
                        }
                        else if (!FlagManager.foundManual) //replace with item functionality
                        {
                            text = "Placeholder text: Finding manual/|";
                            FlagManager.foundManual = true;
                        }
                        else
                        {
                            text = "Placeholder text: This thing after finding manual/|";
                        }
                    }
                    break;
                default:
                    break;
            }
            ChatManager.ProcessText(text, rangeCheckRadius);
        }
    }
}
