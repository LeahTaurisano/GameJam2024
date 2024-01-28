using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlagManager : MonoBehaviour
{
    //General
    public static bool isHacking = false;
    public static bool slidePuzzleOpen = false;
    public static bool devMode = false;

    //Act 1
    public static bool gameStartFlag = true;
    public static bool talkedToComputer = false;
    public static bool unplugComputer = false;
    public static bool foundKey = false;
    public static bool foundManual = false;

    //Act 2
    public static bool canDigitize = false;
    public static bool inDigitalWorld = false;
    public static bool cloneExists = false;
    public static bool checkedFirewall = false;
    public static bool disabledFirewall = false;
    public static bool putKeyInTrash = false;
    public static bool foundEncryptionKey = false;
    public static bool foundImportantFile = false;
    public static bool talkedToClone = false;
    public static bool usedImportantFile = false;
    public static bool askedCloneForHelp = false;
    public static bool completedSecondHack = false;
}