using System.Collections;
using System.Collections.Generic;
using BananaUtils.OnScreenDebugger.Scripts;
using UnityEngine;

public class SwitchScript : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject _switchMesh;
    [SerializeField] private float _lerpTime;
    [SerializeField] private Vector3 _targetSwitchPos;
    [SerializeField] private OpenAbleGateScript _gateScript;
    private bool _switchPressed;
    
    public void Interact()
    {
        if (_switchPressed)
            return;
        
        OSDebug.Debug.Log(4f, "InteractedWithSwitch");
        StartCoroutine(SwitchLerp());
        _gateScript.StartCoroutine(_gateScript.GateLerp());
        _switchPressed = true;
    }
    
    private IEnumerator SwitchLerp()
    {
        float time = 0f;

        while (time < _lerpTime)
        {
            float t = time / _lerpTime;
            
            _switchMesh.transform.localPosition = Vector3.Lerp(_switchMesh.transform.localPosition, _targetSwitchPos, t);

            time += Time.deltaTime;

            yield return null;
        }

        _switchMesh.transform.localPosition = _targetSwitchPos;
    }
}
