using UnityEngine;
using VM.TopDown.Damage;

public class DestroyObjectWithLifetime : MonoBehaviour
{
    [SerializeField] float lifeTime = 2f;
    float time = 0;

    private void Start()
    {
        time = 0;
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time > lifeTime)
            DestroyImmediate(gameObject);
    }
}
