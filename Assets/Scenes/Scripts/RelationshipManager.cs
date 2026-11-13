using System.Collections.Generic;
using UnityEngine;

public class RelationshipManager : MonoBehaviour
{
    public static RelationshipManager Instance;

    private Dictionary <string, int> relationships = new Dictionary <string, int> ();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void ChangeRelationship(string npc, int amount)
    {
        if (relationships.ContainsKey (npc))
            relationships.Add (npc, 0);

        relationships [npc] += amount;

        Debug.Log(npc + "Relationship" + relationships[npc]);
    }

    public int GetRelationship(string npc)
    {
        if (!relationships.ContainsKey (npc)) relationships.Add (npc, 0);
        return relationships [npc];
    }
}
