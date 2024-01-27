using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class TextObject : MonoBehaviour
{
    [SerializeField] private float rangeCheckRadius;
    [SerializeField] private string objectName;

    private string text;
    public bool isVirtual;

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && !Chatbox.IsActive() && !FlagManager.isHacking)
        {
            if (ChatManager.CheckInRange(rangeCheckRadius))
            {
                switch (objectName) //Make sure all of these are replaced with jsons or something
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
                            else if (!FlagManager.canDigitize) //replace with item functionality
                            {
                                text = "Placeholder text: Second Computer check. This is the first hack./|";
                                ComputerUIManager.FlipDesktopUI(true);
                            }
                            else if (!FlagManager.usedImportantFile && FlagManager.foundImportantFile)
                            {
                                text = "Placeholder text: Used important file/|";
                                FlagManager.usedImportantFile = true;
                            }
                            else
                            {
                                ComputerUIManager.FlipDesktopUI(true);
                            }
                        }
                        break;
                    case "HackIcon":
                        {
                            if (!FlagManager.canDigitize)
                            {
                                text = "Placeholder text: Initiate first hack/|";
                                FlagManager.isHacking = true;
                            }
                            else if (FlagManager.usedImportantFile && !FlagManager.askedCloneForHelp)
                            {
                                text = "Placeholer text: Unwinnable hack/|";
                            }
                            else if (FlagManager.usedImportantFile && FlagManager.askedCloneForHelp)
                            {
                                text = "Placeholder text: Two person hack/|";
                                FlagManager.completedSecondHack = true;
                            }
                        }
                        break;
                    case "LightPuzzleIcon":
                        {
                            if (!FlagManager.foundEncryptionKey)
                            {
                                text = "Placeholder text: Find encryption key/|";
                            }
                            else if (!FlagManager.disabledFirewall)
                            {
                                text = "Placeholder text: Solve light puzzle/|";
                                FlagManager.disabledFirewall = true;
                            }
                            else
                            {
                                text = "Placeholder text: Already solved puzzle/|";
                            }
                        }
                        break;
                    case "ChatIcon":
                        {
                            if (!FlagManager.canDigitize)
                            {
                                text = "Placeholder Text: Hint to hack/|";
                            }
                            if (!FlagManager.foundEncryptionKey)
                            {
                                text = "Placeholder Text: Hint to find encryption key/|";
                            }
                            else if (!FlagManager.disabledFirewall)
                            {
                                text = "Placeholder Text: Tells you to solve light puzzle/|";
                            }
                            else if (!FlagManager.foundImportantFile)
                            {
                                text = "Placeholder Text: Hint to get file from sliding puzzle/|";
                            }
                            else if (!FlagManager.usedImportantFile)
                            {
                                text = "Placeholder Text: Hint to use important file/|";
                            }
                            else if (!FlagManager.askedCloneForHelp)
                            {
                                text = "Placeholder Text: Hint to ask clone for help/|";
                            }
                            else
                            {
                                text = "This text probably shouldn't pop up, something is wrong/|";
                            }
                        }
                        break;
                    case "ExitIcon":
                        {
                            ComputerUIManager.FlipDesktopUI(false);
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
                    case "Closet":
                        {
                            if (!FlagManager.unplugComputer || !FlagManager.foundKey)
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
                    case "Digitizer":
                        {
                            if (!FlagManager.unplugComputer)
                            {
                                text = "Placeholder text: Digitizer before unplugging computer/|";
                            }
                            else if (!FlagManager.canDigitize)
                            {
                                text = "Placeholder text: Digitizer before first hack/|";
                            }
                            else
                            {
                                return;
                            }
                        }
                        break;
                    case "Firewall":
                        {
                            if (!FlagManager.checkedFirewall)
                            {
                                text = "Placeholder text: Checking firewall/|";
                                FlagManager.checkedFirewall = true;
                            }
                            else
                            {
                                text = "Placeholder text: Firewall before disabling/|";
                            }
                        }
                        break;
                    case "FileCabinet":
                        {
                            if (!FlagManager.disabledFirewall)
                            {
                                text = "Placeholder text: File Cabinet before disabling firewall/|";
                            }
                            else if (!FlagManager.foundImportantFile)
                            {
                                text = "Placeholder text: Finding important file/|";
                                FlagManager.foundImportantFile = true;
                            }
                            else
                            {
                                text = "Placeholder text: Filing Cabinet after finding file/|";
                            }
                        }
                        break;
                    case "Trashcan":
                        {
                            if (!FlagManager.foundKey)
                            {
                                text = "Placeholder text: Trashcan without key/|";
                            }
                            else if (!FlagManager.foundManual) //replace with using key on trash
                            {
                                text = "Placeholder text: Trashcan with key but without manual/|";
                            }
                            else if (!FlagManager.putKeyInTrash)
                            {
                                if (!FlagManager.checkedFirewall)
                                {
                                    text = "Placeholder text: Putting key in trash before checking~firewall/|";
                                }
                                else
                                {
                                    text = "Placeholder text: Putting key in trash after checking~firewall/|";
                                }
                                FlagManager.putKeyInTrash = true;
                            }
                            else if (!FlagManager.foundEncryptionKey)
                            {
                                text = "Placeholder text: Key is in trashcan/|";
                            }
                            else
                            {
                                text = "Placeholder text: After finding encryption key/|";
                            }
                        }
                        break;
                    case "RecycleBin":
                        {
                            if (!FlagManager.checkedFirewall && !FlagManager.putKeyInTrash && !FlagManager.foundEncryptionKey)
                            {
                                text = "Placeholder text: Recycling bin before checking firewall~before putting key in trash/|";
                            }
                            else if (FlagManager.checkedFirewall && !FlagManager.putKeyInTrash && !FlagManager.foundEncryptionKey)
                            {
                                text = "Placeholder text: Recycling bin after checking firewall~before putting key in trash/|";
                            }
                            else if (FlagManager.putKeyInTrash && !FlagManager.foundEncryptionKey)
                            {
                                text = "Placeholder text: Getting encryption key/|";
                                FlagManager.foundEncryptionKey = true;
                            }
                            else
                            {
                                text = "Placeholder text: After finding encryption key/|";
                            }
                        }
                        break;
                    case "Clone":
                        {
                            if (!FlagManager.talkedToClone)
                            {
                                text = "Placeholder text: First conversation with clone/|";
                                FlagManager.talkedToClone = true;
                            }
                            else if (!FlagManager.usedImportantFile)
                            {
                                text = "Placeholder text: General clone dialogue/|";
                            }
                            else if (!FlagManager.askedCloneForHelp)
                            {
                                text = "Placeholder text: Asking clone for help hacking/|";
                                FlagManager.askedCloneForHelp = true;
                            }
                            else
                            {
                                text = "Placeholder text: Waiting for two person hack/|";
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            else
            {
                text = "I need to get closer to check that./|";
            }
            ChatManager.ProcessText(text);
        }
    }


}
