using UnityEngine;
using TMPro;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(Girthodometer))]
public class GirthodometerGUI : Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        
        Girthodometer script = target as Girthodometer;

        EditorGUILayout.LabelField("Min Val:", script.min.ToString());
        EditorGUILayout.LabelField("Max Val:", script.max.ToString());
        EditorGUILayout.MinMaxSlider(ref script.min, ref script.max, 0, 100);
    }
}
#endif

public class Girthodometer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI GirthodometerText;    

    [SerializeField] 
    private GameObject PivotPoint;

    private float GirthAmt;    

    [HideInInspector] [SerializeField]
    public float min = 0, max = 100;    


    private void OnEnable() => Consumable.ThingConsumed += OnThingConsumed;
    private void OnDisable() => Consumable.ThingConsumed -= OnThingConsumed;
    private void OnThingConsumed(Consumable consumable) => AddGirth(consumable.GrithValue);

    public void AddGirth(float amt)
    {
        this.GirthAmt += amt;
        this.GirthodometerText.text = Mathf.RoundToInt(this.GirthAmt).ToString();
        PivotPoint.transform.rotation = Quaternion.Euler(0,0, Mathf.Lerp(90, -90, (this.GirthAmt-min)/max-min));
    }
}