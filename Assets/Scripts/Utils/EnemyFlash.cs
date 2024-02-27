using System.Collections;
using UnityEngine;
public class EnemyFlash : MonoBehaviour, IEnemyDamageObserver
{
    private Material _originalMaterial;
    private SpriteRenderer _spriteRenderer;
    public Material HitMaterial;
    private void Awake()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _originalMaterial = _spriteRenderer.material;
        HitMaterial = new Material(HitMaterial);
    }
    private IEnumerator FlashRoutine()
    {
        _spriteRenderer.material = HitMaterial;
        yield return new WaitForSeconds(0.05f);
        _spriteRenderer.material = _originalMaterial;
    }
    private void OnEnable()
    {
        GetComponent<EnemyTakeDamage>().AddEnemyObserver((this));
    }
    private void OnDisable()
    {
        GetComponent<EnemyTakeDamage>().RemoveEnemyObserver((this));
    }
    public void OnDamageTaken()
    {
        StartCoroutine(FlashRoutine());
    }
}
