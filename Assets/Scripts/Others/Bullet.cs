using UnityEngine;
using VM.TopDown.Damage;

public class Bullet : MonoBehaviour
{
    [SerializeField] DamageType damageType;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    public void SetDamageType(DamageType damageType)
    {
        this.damageType = damageType;
    }
}
