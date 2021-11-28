using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Day", menuName = "Final Day")]
public class BaseDia : ScriptableObject
{
    public int dia;
    [TextArea] public string descriptionDia;
    public GastoExtra[] gastosExtras;
}
