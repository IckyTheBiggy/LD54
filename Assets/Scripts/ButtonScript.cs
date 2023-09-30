using System.Collections;
using System.Collections.Generic;
using BananaUtils.OnScreenDebugger.Scripts;
using UnityEngine;

public class ButtonScript : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject _buttonMesh;
    [SerializeField] private float _lerpTime;
    [SerializeField] private Vector3 _targetButtonPos;
    private bool _buttonPressed;
    
    public void Interact()
    {
        if (_buttonPressed)
            return;
        
        OSDebug.Debug.Log(4f, "InteractedWithButton");
        StartCoroutine(ButtonLerp());
        _buttonPressed = true;
    }
    
    private IEnumerator ButtonLerp()
    {
        float time = 0f;

        while (time < _lerpTime)
        {
            float t = time / _lerpTime;
            
            _buttonMesh.transform.localPosition = Vector3.Lerp(_buttonMesh.transform.localPosition, _targetButtonPos, t);

            time += Time.deltaTime;

            yield return null;
        }

        _buttonMesh.transform.localPosition = _targetButtonPos;
    }
}
