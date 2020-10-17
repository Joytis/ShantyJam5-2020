using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

public class ImageMaterialFloatDriver : MonoBehaviour
{
    [SerializeField] Image _image = null;
    [SerializeField] string _name = null;
    [SerializeField] float _initialValue = 0f;
    [SerializeField] AnimationCurve _curve = null;
    ImageMaterialBinding _binding = null;

    void Awake() 
    {
        _binding = GetComponent<ImageMaterialBinding>();
        if(_binding == null)
        {
            _binding = gameObject.AddComponent<ImageMaterialBinding>();
        }
        _binding.Material.SetFloat(_name, _initialValue);
    }

    public void SetFloat(float target) => _binding.Material.SetFloat(_name, target);

    public IEnumerator SetFloatAsync(float target, float time) 
    {
        yield return _binding.Material.DOFloat(target, _name, time)
            .SetEase(_curve)
            .WaitForCompletion();
    }
}
