using UnityEngine;

[CreateAssetMenu(fileName = "StratagemSO", menuName = "Scriptable Objects/StratagemSO")]
public class StratagemSO : ScriptableObject
{
    public Sprite gemIcon;
    public string gemName;
    public string castCode;

    public void Cast() {}
}
