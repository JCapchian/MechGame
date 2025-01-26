using UnityEngine;

[CreateAssetMenu(fileName = "new Ability Data", menuName = "MechAbility", order = 0)]
public class ScriptableAbility : ScriptableObject
{
    public string abilityName;
    public BaseAbility ability;
}