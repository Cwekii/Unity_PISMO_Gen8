using UnityEngine;

public class MathfTest : MonoBehaviour
{
    [SerializeField, Range(-10f, 10f)] private float controlFloat;


    [SerializeField] private int flooredInt;
    [SerializeField] private int ceiledInt;
    [SerializeField] private float clampedFloat; // Between 3f and 7f

    private void OnValidate()
    {
        flooredInt = Mathf.FloorToInt(controlFloat);
        ceiledInt = Mathf.CeilToInt(controlFloat);
        clampedFloat = Mathf.Clamp(controlFloat, 3f, 7f);
    }
}
