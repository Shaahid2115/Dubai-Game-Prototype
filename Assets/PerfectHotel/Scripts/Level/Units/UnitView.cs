using UnityEngine;
using UnityEngine.AI;

namespace Game.Level.Unit
{
    public enum AnimationType
    {
        Walk,
        Idle,
        Sleep,
        Clean,
        Toilet,
        Reception,
        Carry,
        Sit
    }

    public class UnitStaffView : UnitView
    {
        [SerializeField] private Transform _inventoryHolder;
        public Transform InventoryHolder => _inventoryHolder;
    }

    public class UnitView : MonoBehaviour
    {
        [SerializeField] private Transform _localTransform;
        [SerializeField] private Animator _animator;
        [SerializeField] private NavMeshAgent _navMeshAgent;

        public Transform LocalTransform => _localTransform;
        public NavMeshAgent NavMeshAgent => _navMeshAgent;

        [HideInInspector] public int Index;

        private AnimationType _currentType;
        private float _timeValue;

        internal void Walk(int inventories)
        {
            SetLayerWeight(inventories);
            PlayWalkAnimation();
        }

        private void PlayWalkAnimation()
        {
            PlayAnimation(AnimationType.Walk, GetRandomTime());
        }

        internal void Idle(int inventories)
        {
            SetLayerWeight(inventories);
            PlayIdleAnimation();
        }

        private void SetLayerWeight(int inventories)
        {
            if (inventories > 0)
                _animator.SetLayerWeight(1, 1f);
            else _animator.SetLayerWeight(1, 0f);
        }

        private void PlayIdleAnimation()
        {
            PlayAnimation(AnimationType.Idle, GetRandomTime());
        }

        internal void Sleep()
        {
            PlayAnimation(AnimationType.Sleep, GetRandomTime());
        }

        internal void Clean()
        {
            PlayAnimation(AnimationType.Idle, GetRandomTime());
        }

        internal void Service(AnimationType animationType)
        {
            PlayAnimation(animationType, GetRandomTime());
        }

        internal void Reception()
        {
            PlayAnimation(AnimationType.Reception, GetRandomTime());
        }

        internal void Throw()
        {
            PlayAnimation(AnimationType.Idle, GetRandomTime());
        }

        float GetRandomTime()
        {
            return Random.Range(0f, 1f);
        }

        internal void Hide()
        {
            gameObject.SetActive(false);
        }

        internal void Unhide()
        {
            gameObject.SetActive(true);
        }

        internal void UpdateCurrentAnimation(int inventories)
        {
            SetLayerWeight(inventories);
            PlayAnimation(_currentType, _timeValue);
        }

        private void PlayAnimation(AnimationType animationType, float timeValue)
        {
            _currentType = animationType;
            _timeValue = timeValue;

            var nameHash = Animator.StringToHash(_currentType.ToString());
            _animator.PlayInFixedTime(nameHash, 0, timeValue);

            _animator.Update(0);
        }

        public Vector3 Position
        {
            get { return transform.position; }
            set { transform.position = value; }
        }
    }
}