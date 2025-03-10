using UnityEngine;

public enum EnvType
{
    jump,
    fire
}

public enum modifyingType
{
    jump,
    health
}

[System.Serializable]
public class EvDataModifying
{
    public modifyingType type;
    public float value;
}

[CreateAssetMenu(fileName = "Env", menuName = "New Environment")]
public class EnvData : ScriptableObject
{
    [Header("Info")]
    public string displayName;
    public string description;
    public EnvType type;

    [Header("Modifying")]
    public EvDataModifying[] modifying;
}