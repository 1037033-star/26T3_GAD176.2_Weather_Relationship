using System;
using UnityEngine;

[Serializable] //save the state of an object and recreate it as needed (stores objects and data)
public class DialogueChoice
{
    public string buttonText;
    public int relationshipChange;
    public string response;
}
