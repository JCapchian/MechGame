using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

[CreateAssetMenu(fileName = "new Ability Data", menuName = "MechAbility", order = 0)]
public class ScriptableAbility : ScriptableObject
{
    public string abilityName;
    public BaseAbility ability;
    public float duration;
    public float cooldown;
    public Sprite icon;
    public AbilityIcon iconPrefab;
}