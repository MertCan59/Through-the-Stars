using System.Collections;
using UnityEngine;

public class PlayerFlash : MonoBehaviour, IPlayerDamageObserver
{
    private Material _originalMaterial;
    private SpriteRenderer _spriteRenderer;
    public Material HitMaterial;
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
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
        FindObjectOfType<PlayerTakeDamage>()?.AddEnemyObserver(this);

    }
    private void OnDisable()
    {
        FindObjectOfType<PlayerTakeDamage>()?.RemoveEnemyObserver(this);
    }
    public void PlayerOnDamage()
    {
        StartCoroutine(FlashRoutine());
    }
}
