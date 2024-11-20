using UnityEngine;

namespace MyFps
{
    public class Bullet : MonoBehaviour
    {

        #region Variables
        //���ݷ�
        [SerializeField] private float attackDamage = 5f;
        //����Ʈ
        public GameObject hitImpactPrefab;

        #endregion

        // �浹üũ
        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log($"collision:{collision.gameObject.name}");

           GameObject effetGo =  Instantiate(hitImpactPrefab,transform.position,Quaternion.LookRotation(transform.forward * -1)); //
            Destroy(effetGo,2f);


            IDamageable damageable = collision.transform.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(attackDamage);
            }

            Destroy(gameObject);

        }

    }
}