using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PushableButtonAnimation : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    private readonly Dictionary<Graphic, ColorData> _orignalColors = new Dictionary<Graphic, ColorData>();
    [SerializeField] private Transform _content;
    [SerializeField] private Color _disabledColor = new Color(1f, 1f, 1f, 0.75f);
    [SerializeField] private bool _interactable = true;
    private Vector3 _movedPosition;
    [SerializeField] private UnityEvent _onClick;
    private Vector3 _originalPosition;

    private List<Shadow> _shadows;

    private Transform TransformToMove => _content != null ? _content : transform;

    public bool Interactable
    {
        private get { return _interactable; }
        set
        {
            _interactable = value;
            foreach (var kp in _orignalColors) kp.Key.color = !Interactable ? kp.Value.New : kp.Value.Old;
            _shadows?.ForEach(s => s.enabled = _interactable);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!Interactable) return;
        _onClick.Invoke();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Calculate();
        if (!Interactable) return;
        TransformToMove.localPosition = _movedPosition;
        _shadows.ForEach(s => s.enabled = false);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!Interactable) return;
        Reset();
    }

    private void Awake()
    {
        Calculate();
    }

    private void OnEnable()
    {
        Calculate();
    }

    private void Calculate()
    {
        if (_orignalColors.Count == 0)
            GetComponentsInChildren<Graphic>().ToList().ForEach(gr =>
            {
                var color = new Color(gr.color.r, gr.color.g, gr.color.b, gr.color.a);
                _orignalColors[gr] = new ColorData
                {
                    Old = color,
                    New = color * _disabledColor
                };
            });
        _shadows = new List<Shadow>(GetComponentsInChildren<Shadow>());
        _originalPosition = TransformToMove.localPosition;
        _movedPosition = new Vector3(_originalPosition.x, _originalPosition.y + _shadows.Sum(s => s.effectDistance.y), _originalPosition.z);
    }

    private void Reset()
    {
        _shadows.ForEach(s => s.enabled = true);
        TransformToMove.localPosition = _originalPosition;
    }

    private class ColorData
    {
        public Color New;
        public Color Old;
    }
}