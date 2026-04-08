using UnityEngine;

public class BaseCollectables : MonoBehaviour
{
    [SerializeField] protected BaseStats stats;

    private int value;

    public void SetValue(int value)
    {
        this.value = value;
    }

    public int Value => value;

}