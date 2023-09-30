using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenAbleGateScript : MonoBehaviour
{
    [SerializeField] private GameObject _gateMesh;
    [SerializeField] private float _lerpTime;
    [SerializeField] private Vector3 _targetGatePos;
    private bool _gateOpened;
    
    public IEnumerator GateLerp()
    {
        float time = 0f;

        while (time < _lerpTime)
        {
            float t = time / _lerpTime;
            
            _gateMesh.transform.localPosition = Vector3.Lerp(_gateMesh.transform.localPosition, _targetGatePos, t);

            time += Time.deltaTime;

            yield return null;
        }

        _gateMesh.transform.localPosition = _targetGatePos;
    }
}
