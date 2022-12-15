using System.Collections;
using UnityEngine;

public class FireworksSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _prefabs;

    [SerializeField]
    private Vector3 _position;

    private float _yMax = 150;
    private float _xMax = 225;

    private bool _delayGoing;
    private WaitForSeconds _timeout = new(0.5f);

    private void Update()
    {
        if (Input.touchCount <= 0 || _delayGoing) return;

        Touch touch = Input.GetTouch(0);

        _position.x = GetPosition(Screen.width, touch.position.x, _xMax);
        _position.y = GetPosition(Screen.height, touch.position.y, _yMax);

        int random = Random.Range(0, _prefabs.Length);
        Instantiate(_prefabs[random], _position, Quaternion.identity);
        StartCoroutine(Delay());
    }

    private IEnumerator Delay()
    {
        _delayGoing = true;

        yield return _timeout;

        _delayGoing = false;
    }

    private float GetPosition(float screen, float touch, float max)
    {
        float percent = touch * 100 / screen;
        float position = percent * max / 100;

        return position - max / 2;
    }
}
    