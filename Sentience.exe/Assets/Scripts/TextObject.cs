using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class TextObject : MonoBehaviour
{
    [SerializeField] private float rangeCheckRadius;
    [SerializeField] private string objectName;

    private TextAsset textAsset;
    private string text;

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
                            textAsset = (TextAsset)Resources.Load("Tower");
                            text = textAsset.text;
                            break;
                        }
                    case "Bed":
                        {
                            textAsset = (TextAsset)Resources.Load("Bed");
                            text = textAsset.text;
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
                                textAsset = (TextAsset)Resources.Load("FirstComputerCheck");
                                text = textAsset.text;
                            }
                            else if (!FlagManager.foundManual)
                            {
                                textAsset = (TextAsset)Resources.Load("ComputerBeforeManual");
                                text = textAsset.text;
                            }
                            else if (!FlagManager.canDigitize) //replace with item functionality
                            {
                                textAsset = (TextAsset)Resources.Load("ComputerPreFirstHack");
                                text = textAsset.text;
                                ComputerUIManager.FlipDesktopUI(true);
                            }
                            else if (!FlagManager.usedImportantFile && FlagManager.foundImportantFile)
                            {
                                textAsset = (TextAsset)Resources.Load("UploadFile");
                                text = textAsset.text;
                                FlagManager.usedImportantFile = true;
                            }
                            else
                            {
                                ComputerUIManager.FlipDesktopUI(true);
                                return;
                            }
                        }
                        break;
                    case "HackIcon":
                        {
                            if (!FlagManager.canDigitize)
                            {
                                textAsset = (TextAsset)Resources.Load("FirstHack");
                                text = textAsset.text;
                                FlagManager.isHacking = true;
                            }
                            else if (!FlagManager.usedImportantFile)
                            {
                                textAsset = (TextAsset)Resources.Load("SecondHackUnavailable");
                                text = textAsset.text;
                            }
                            else if (FlagManager.usedImportantFile && !FlagManager.askedCloneForHelp)
                            {
                                textAsset = (TextAsset)Resources.Load("UnwinnableHack");
                                text = textAsset.text;
                                FlagManager.isHacking = true;
                            }
                            else if (FlagManager.usedImportantFile && FlagManager.askedCloneForHelp)
                            {
                                textAsset = (TextAsset)Resources.Load("TwoPersonHack");
                                text = textAsset.text;
                                FlagManager.isHacking = true;
                            }
                        }
                        break;
                    case "LightPuzzleIcon":
                        {
                            if (!FlagManager.foundEncryptionKey)
                            {
                                textAsset = (TextAsset)Resources.Load("FirewallNoKey");
                                text = textAsset.text;
                            }
                            else
                            {
                                return;
                            }
                        }
                        break;
                    case "ChatIcon":
                        {
                            if (!FlagManager.canDigitize)
                            {
                                textAsset = (TextAsset)Resources.Load("ChatHackHint");
                                text = textAsset.text;
                            }
                            else if (!FlagManager.foundEncryptionKey)
                            {
                                textAsset = (TextAsset)Resources.Load("ChatEncryptionHint");
                                text = textAsset.text;
                            }
                            else if (!FlagManager.disabledFirewall)
                            {
                                textAsset = (TextAsset)Resources.Load("ChatLightPuzzleHint");
                                text = textAsset.text;
                            }
                            else if (!FlagManager.foundImportantFile)
                            {
                                textAsset = (TextAsset)Resources.Load("SlidePuzzleHint");
                                text = textAsset.text;
                            }
                            else if (!FlagManager.askedCloneForHelp)
                            {
                                textAsset = (TextAsset)Resources.Load("ChatTwoPersonHackHint");
                                text = textAsset.text;
                            }
                            else
                            {
                                textAsset = (TextAsset)Resources.Load("ChatDoubleHackHint");
                                text = textAsset.text;
                            }
                        }
                        break;
                    case "ExitIcon":
                        {
                            ComputerUIManager.FlipDesktopUI(false);
                            return;
                        }
                    case "Plug":
                        {
                            if (!FlagManager.talkedToComputer)
                            {
                                textAsset = (TextAsset)Resources.Load("PlugBeforeComputer");
                                text = textAsset.text;
                            }
                            else if (!FlagManager.unplugComputer)
                            {
                                textAsset = (TextAsset)Resources.Load("UnpluggingComputer");
                                text = textAsset.text;
                                FlagManager.unplugComputer = true;
                                PlugSwap.UnplugPlugSprite();
                            }
                            else
                            {
                                textAsset = (TextAsset)Resources.Load("Unplugged");
                                text = textAsset.text;
                            }
                        }
                        break;
                    case "PizzaBox":
                        {
                            if (!FlagManager.unplugComputer)
                            {
                                textAsset = (TextAsset)Resources.Load("PizzaBoxInitial");
                                text = textAsset.text;
                            }
                            else if (!FlagManager.foundKey)
                            {
                                textAsset = (TextAsset)Resources.Load("PizzaKey");
                                text = textAsset.text;
                                FlagManager.foundKey = true;
                            }
                            else
                            {
                                textAsset = (TextAsset)Resources.Load("PizzaAfterKey");
                                text = textAsset.text;
                            }
                        }
                        break;
                    case "Closet":
                        {
                            if (!FlagManager.unplugComputer)
                            {
                                textAsset = (TextAsset)Resources.Load("ClosetBeforeUnplug");
                                text = textAsset.text;
                            }
                            else if (!FlagManager.foundKey)
                            {
                                textAsset = (TextAsset)Resources.Load("ClosetWithoutKey");
                                text = textAsset.text;
                            }
                            else if (!FlagManager.foundManual)
                            {
                                textAsset = (TextAsset)Resources.Load("FindingManual");
                                text = textAsset.text;
                                FlagManager.foundManual = true;
                            }
                            else
                            {
                                textAsset = (TextAsset)Resources.Load("ClosetAfterManual");
                                text = textAsset.text;
                            }
                        }
                        break;
                    case "Digitizer":
                        {
                            if (!FlagManager.unplugComputer)
                            {
                                textAsset = (TextAsset)Resources.Load("DigitizerBeforeUnplug");
                                text = textAsset.text;
                            }
                            else if (!FlagManager.canDigitize)
                            {
                                textAsset = (TextAsset)Resources.Load("DigitizerAfterUnplug");
                                text = textAsset.text;
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
                                textAsset = (TextAsset)Resources.Load("FirewallFirstCheck");
                                text = textAsset.text;
                                FlagManager.checkedFirewall = true;
                            }
                            else
                            {
                                textAsset = (TextAsset)Resources.Load("FirewallGeneral");
                                text = textAsset.text;
                            }
                        }
                        break;
                    case "FileCabinet":
                        {
                            if (!FlagManager.disabledFirewall)
                            {
                                textAsset = (TextAsset)Resources.Load("FileCabinetWithFirewall");
                                text = textAsset.text;
                            }
                            else if (!FlagManager.foundImportantFile)
                            {
                                return;
                            }
                            else
                            {
                                textAsset = (TextAsset)Resources.Load("CabinetAfterFile");
                                text = textAsset.text;
                            }
                        }
                        break;
                    case "Trashcan":
                        {
                            if (!FlagManager.foundKey)
                            {
                                textAsset = (TextAsset)Resources.Load("TrashBeforeKey");
                                text = textAsset.text;
                            }
                            else if (!FlagManager.foundManual) //replace with using key on trash
                            {
                                textAsset = (TextAsset)Resources.Load("TrashBeforeManual");
                                text = textAsset.text;
                            }
                            else if (!FlagManager.putKeyInTrash)
                            {
                                if (!FlagManager.checkedFirewall)
                                {
                                    textAsset = (TextAsset)Resources.Load("TrashBeforeFirewall");
                                    text = textAsset.text;
                                }
                                else
                                {
                                    textAsset = (TextAsset)Resources.Load("TrashAfterFirewallCheck");
                                    text = textAsset.text;
                                }
                                FlagManager.putKeyInTrash = true;
                            }
                            else if (!FlagManager.foundEncryptionKey)
                            {
                                textAsset = (TextAsset)Resources.Load("KeyInTrash");
                                text = textAsset.text;
                            }
                            else
                            {
                                textAsset = (TextAsset)Resources.Load("TrashAfterEncryptionKey");
                                text = textAsset.text;
                            }
                        }
                        break;
                    case "RecycleBin":
                        {
                            if (!FlagManager.checkedFirewall && !FlagManager.putKeyInTrash && !FlagManager.foundEncryptionKey)
                            {
                                textAsset = (TextAsset)Resources.Load("RecycleBeforeFirewall");
                                text = textAsset.text;
                            }
                            else if (FlagManager.checkedFirewall && !FlagManager.putKeyInTrash && !FlagManager.foundEncryptionKey)
                            {
                                textAsset = (TextAsset)Resources.Load("RecycleAfterFirewall");
                                text = textAsset.text;
                            }
                            else if (FlagManager.putKeyInTrash && !FlagManager.foundEncryptionKey)
                            {
                                textAsset = (TextAsset)Resources.Load("GettingEncryptionKey");
                                text = textAsset.text;
                                FlagManager.foundEncryptionKey = true;
                            }
                            else
                            {
                                textAsset = (TextAsset)Resources.Load("RecycleAfterEncryption");
                                text = textAsset.text;
                            }
                        }
                        break;
                    case "Clone":
                        {
                            if (!FlagManager.talkedToClone)
                            {
                                textAsset = (TextAsset)Resources.Load("FirstCloneTalk");
                                text = textAsset.text;
                                FlagManager.talkedToClone = true;
                            }
                            else if (!FlagManager.usedImportantFile)
                            {
                                textAsset = (TextAsset)Resources.Load("CloneGeneralTalk");
                                text = textAsset.text;
                            }
                            else if (!FlagManager.askedCloneForHelp)
                            {
                                textAsset = (TextAsset)Resources.Load("AskingCloneForHelp");
                                text = textAsset.text;
                                FlagManager.askedCloneForHelp = true;
                            }
                            else
                            {
                                textAsset = (TextAsset)Resources.Load("CloneWaitingForHack");
                                text = textAsset.text;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            else
            {
                text = "*I need to get closer to check that./|";
            }
            ChatManager.ProcessText(text);
        }
    }


}
