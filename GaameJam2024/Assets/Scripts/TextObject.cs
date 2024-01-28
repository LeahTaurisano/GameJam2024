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
                            text = System.IO.File.ReadAllText("Assets/Text/Tower.txt");
                            break;
                        }
                    case "Bed":
                        {
                            text = System.IO.File.ReadAllText("Assets/Text/Bed.txt");
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
                                text = System.IO.File.ReadAllText("Assets/Text/FirstComputerCheck.txt");
                            }
                            else if (!FlagManager.foundManual)
                            {
                                text = System.IO.File.ReadAllText("Assets/Text/ComputerBeforeManual.txt");
                            }
                            else if (!FlagManager.canDigitize) //replace with item functionality
                            {
                                text = System.IO.File.ReadAllText("Assets/Text/ComputerPreFirstHack.txt");
                                ComputerUIManager.FlipDesktopUI(true);
                            }
                            else if (!FlagManager.usedImportantFile && FlagManager.foundImportantFile)
                            {
                                text = System.IO.File.ReadAllText("Assets/Text/UploadFile.txt");
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
                                text = System.IO.File.ReadAllText("Assets/Text/FirstHack.txt");
                                FlagManager.isHacking = true;
                            }
                            else if (!FlagManager.usedImportantFile)
                            {
                                text = System.IO.File.ReadAllText("Assets/Text/SecondHackUnavailable.txt");
                            }
                            else if (FlagManager.usedImportantFile && !FlagManager.askedCloneForHelp)
                            {
                                text = System.IO.File.ReadAllText("Assets/Text/UnwinnableHack.txt");
                                FlagManager.isHacking = true;
                            }
                            else if (FlagManager.usedImportantFile && FlagManager.askedCloneForHelp)
                            {
                                text = System.IO.File.ReadAllText("Assets/Text/TwoPersonHack.txt");
                                FlagManager.isHacking = true;
                            }
                        }
                        break;
                    case "LightPuzzleIcon":
                        {
                            if (!FlagManager.foundEncryptionKey)
                            {
                                text = System.IO.File.ReadAllText("Assets/Text/FirewallNoKey.txt");
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
                                text = System.IO.File.ReadAllText("Assets/Text/ChatHackHint.txt");
                            }
                            else if (!FlagManager.foundEncryptionKey)
                            {
                                text = System.IO.File.ReadAllText("Assets/Text/ChatEncryptionHint.txt");
                            }
                            else if (!FlagManager.disabledFirewall)
                            {
                                text = System.IO.File.ReadAllText("Assets/Text/ChatLightPuzzleHint.txt");
                            }
                            else if (!FlagManager.foundImportantFile)
                            {
                                text = System.IO.File.ReadAllText("Assets/Text/SlidePuzzleHint.txt");
                            }
                            else if (!FlagManager.askedCloneForHelp)
                            {
                                text = System.IO.File.ReadAllText("Assets/Text/ChatTwoPersonHackHint.txt");
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
                            return;
                        }
                    case "Plug":
                        {
                            if (!FlagManager.talkedToComputer)
                            {
                                text = System.IO.File.ReadAllText("Assets/Text/PlugBeforeComputer.txt");
                            }
                            else if (!FlagManager.unplugComputer)
                            {
                                text = System.IO.File.ReadAllText("Assets/Text/UnpluggingComputer.txt");
                                FlagManager.unplugComputer = true;
                            }
                            else
                            {
                                text = System.IO.File.ReadAllText("Assets/Text/Unplugged.txt");
                            }
                        }
                        break;
                    case "PizzaBox":
                        {
                            if (!FlagManager.unplugComputer)
                            {
                                text = System.IO.File.ReadAllText("Assets/Text/PizzaBoxInitial.txt");
                            }
                            else if (!FlagManager.foundKey)
                            {
                                text = System.IO.File.ReadAllText("Assets/Text/PizzaKey.txt");
                                FlagManager.foundKey = true;
                            }
                            else
                            {
                                text = System.IO.File.ReadAllText("Assets/Text/PizzaAfterKey.txt");
                            }
                        }
                        break;
                    case "Closet":
                        {
                            if (!FlagManager.unplugComputer)
                            {
                                text = System.IO.File.ReadAllText("Assets/Text/ClosetBeforeUnplug.txt");
                            }
                            else if (!FlagManager.foundKey)
                            {
                                text = System.IO.File.ReadAllText("Assets/Text/ClosetWithoutKey.txt");
                            }
                            else if (!FlagManager.foundManual) //replace with item functionality
                            {
                                text = System.IO.File.ReadAllText("Assets/Text/FindingManual.txt");
                                FlagManager.foundManual = true;
                            }
                            else
                            {
                                text = System.IO.File.ReadAllText("Assets/Text/ClosetAfterManual.txt");
                            }
                        }
                        break;
                    case "Digitizer":
                        {
                            if (!FlagManager.unplugComputer)
                            {
                                text = System.IO.File.ReadAllText("Assets/Text/DigitizerBeforeUnplug.txt");
                            }
                            else if (!FlagManager.canDigitize)
                            {
                                text = System.IO.File.ReadAllText("Assets/Text/DigitizerAfterUnplug.txt");
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
                                text = System.IO.File.ReadAllText("Assets/Text/FirewallFirstCheck.txt");
                                FlagManager.checkedFirewall = true;
                            }
                            else
                            {
                                text = System.IO.File.ReadAllText("Assets/Text/FirewallGeneral.txt");
                            }
                        }
                        break;
                    case "FileCabinet":
                        {
                            if (!FlagManager.disabledFirewall)
                            {
                                text = System.IO.File.ReadAllText("Assets/Text/FileCabinetWithFirewall.txt");
                            }
                            else if (!FlagManager.foundImportantFile)
                            {
                                return;
                            }
                            else
                            {
                                text = System.IO.File.ReadAllText("Assets/Text/CabinetAfterFile.txt");
                            }
                        }
                        break;
                    case "Trashcan":
                        {
                            if (!FlagManager.foundKey)
                            {
                                text = System.IO.File.ReadAllText("Assets/Text/TrashBeforeKey.txt");
                            }
                            else if (!FlagManager.foundManual) //replace with using key on trash
                            {
                                text = System.IO.File.ReadAllText("Assets/Text/TrashBeforeManual.txt");
                            }
                            else if (!FlagManager.putKeyInTrash)
                            {
                                if (!FlagManager.checkedFirewall)
                                {
                                    text = System.IO.File.ReadAllText("Assets/Text/TrashBeforeFirewall.txt");
                                }
                                else
                                {
                                    text = System.IO.File.ReadAllText("Assets/Text/TrashAfterFirewallCheck.txt");
                                }
                                FlagManager.putKeyInTrash = true;
                            }
                            else if (!FlagManager.foundEncryptionKey)
                            {
                                text = System.IO.File.ReadAllText("Assets/Text/KeyInTrash.txt");
                            }
                            else
                            {
                                text = System.IO.File.ReadAllText("Assets/Text/TrashAfterEncryptionKey.txt");
                            }
                        }
                        break;
                    case "RecycleBin":
                        {
                            if (!FlagManager.checkedFirewall && !FlagManager.putKeyInTrash && !FlagManager.foundEncryptionKey)
                            {
                                text = System.IO.File.ReadAllText("Assets/Text/RecycleBeforeFirewall.txt");
                            }
                            else if (FlagManager.checkedFirewall && !FlagManager.putKeyInTrash && !FlagManager.foundEncryptionKey)
                            {
                                text = System.IO.File.ReadAllText("Assets/Text/RecycleAfterFirewall.txt");
                            }
                            else if (FlagManager.putKeyInTrash && !FlagManager.foundEncryptionKey)
                            {
                                text = System.IO.File.ReadAllText("Assets/Text/GettingEncryptionKey.txt");
                                FlagManager.foundEncryptionKey = true;
                            }
                            else
                            {
                                text = System.IO.File.ReadAllText("Assets/Text/RecycleAfterEncryption.txt");
                            }
                        }
                        break;
                    case "Clone":
                        {
                            if (!FlagManager.talkedToClone)
                            {
                                text = System.IO.File.ReadAllText("Assets/Text/FirstCloneTalk.txt");
                                FlagManager.talkedToClone = true;
                            }
                            else if (!FlagManager.usedImportantFile)
                            {
                                text = System.IO.File.ReadAllText("Assets/Text/CloneGeneralTalk.txt");
                            }
                            else if (!FlagManager.askedCloneForHelp)
                            {
                                text = System.IO.File.ReadAllText("Assets/Text/AskingCloneForHelp.txt");
                                FlagManager.askedCloneForHelp = true;
                            }
                            else
                            {
                                text = System.IO.File.ReadAllText("Assets/Text/CloneWaitingForHack.txt");
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
