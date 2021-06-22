using UnityEngine;
// Photon 用の名前空間を参照する
using Photon.Pun;

/// <summary>
/// ホッケーゲームのパックを制御するコンポーネント
/// </summary>
public class PackController : MonoBehaviour
{
    /// <summary>初速</summary>
    [SerializeField] float m_speed = 5f;
    /// <summary>サーブしたら true になる</summary>
    bool m_isStarted = false;
    PhotonView m_view = null;
    Rigidbody2D m_rb = null;
    /// <summary>最高速度</summary>
    [SerializeField] float m_maxSpeed = 100f;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_view = GetComponent<PhotonView>();
    }

    void Update()
    {
        // 自分が生成したオブジェクトで、まだサーブしていない状態でスペースキーを押したら
        if (m_view && m_view.IsMine && !m_isStarted && Input.GetButtonUp("Jump"))
        {
            // フラグをたててパックをサーブする
            m_isStarted = true;
            m_rb.velocity = this.transform.right * m_speed;
        }
        if (m_rb.velocity.magnitude != 0)
        {
            Debug.Log(m_rb.velocity.magnitude);
            if (m_rb.velocity.magnitude > m_maxSpeed)
            {
                m_rb.velocity = m_rb.velocity.normalized * m_maxSpeed;
            }
        }
    }
}
