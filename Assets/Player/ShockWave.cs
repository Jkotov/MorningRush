using UnityEngine;

public class ShockWave : MonoBehaviour
{
    [SerializeField] private float maxWaveForce;
    [SerializeField] private float timeToMaxForce;
    [SerializeField] private float startWaveForce;
    private float _curForceStack;
    private float _deltaForce;
    private Collider2D _collider2D;
    private int _defaultMaxContacts = 64;
    private AudioSource _audio;
    Collider2D[] _contacts;
    void Start()
    {
        _contacts = new Collider2D[_defaultMaxContacts];
        _deltaForce = (maxWaveForce - startWaveForce) / timeToMaxForce;
        _curForceStack = startWaveForce;
        _collider2D = GetComponent<Collider2D>();
        _audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            _curForceStack += _deltaForce * Time.deltaTime;
            if (_curForceStack > maxWaveForce)
                _curForceStack = maxWaveForce;
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            StartForceWave();
            _curForceStack = startWaveForce;
        }
    }

    private void StartForceWave()
    {
        _audio.Play();
        int contactsCount = _collider2D.GetContacts(_contacts);
        if (contactsCount == 0)
            return;
        if (contactsCount > _contacts.Length)
        {
            _contacts = new Collider2D[contactsCount * 2];
            contactsCount = _collider2D.GetContacts(_contacts);
        }

        for (int i = 0; i < contactsCount; i++)
        {
            
            if (_contacts[i].gameObject.CompareTag("Item"))
            {
                Debug.Log((Vector2)(_contacts[i].bounds.center - _collider2D.bounds.center).normalized * _curForceStack);
                _contacts[i].gameObject.GetComponent<Rigidbody2D>().AddForce((Vector2)(_contacts[i].bounds.center - _collider2D.bounds.center).normalized * _curForceStack);
            }
        }
        
    }
}
