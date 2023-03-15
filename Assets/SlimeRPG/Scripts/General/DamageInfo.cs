using DG.Tweening;
using System.Linq;
using TMPro;
using UnityEngine;

namespace Assets.SlimeRPG.Scripts.General
{
    public class DamageInfo : MonoBehaviour
    {     
        [SerializeField] private GameObject _floatingTextPrefab;
        [SerializeField] private TextMeshPro _damageText;
        [SerializeField] private GameObject _parentTransform;
        private HealthController _healthController;

        private Sequence _textSequence;

        private void Awake()
        {
            _healthController = GetComponent<HealthController>();
        }

        private void OnEnable()
        {
            _healthController.OnDamage += TextUpdate;
        }

        private void TextUpdate(float damage)
        {
            _damageText.text = damage.ToString();
            FloatingText();
        } 

        private void FloatingText()
        {
            GameObject newText = Instantiate(_floatingTextPrefab, _damageText.transform.position, Quaternion.identity);
            newText.transform.SetParent(_parentTransform.transform, false);
            newText.GetComponent<TMP_Text>().text = _damageText.text;
            EnableTextSequence(newText);
        }

        private void EnableTextSequence(GameObject text)
        {
            _textSequence = DOTween.Sequence();
            _textSequence.Append(text.transform.DOScale(transform.localScale.magnitude, 0.2f));
            _textSequence.Append(text.transform.DOBlendableMoveBy(Vector3.up * 2f, 1f));
            _textSequence.Insert(0.2f, text.GetComponent<TMP_Text>().DOFade(0, 1f))
                .OnComplete(() => Destroy(text));
        }

        private void OnDisable()
        {
            _healthController.OnDamage -= TextUpdate;
        }

        private void OnDestroy()
        {
            _textSequence?.Kill();
        }
    }
}
