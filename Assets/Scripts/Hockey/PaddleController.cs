using UnityEngine;
// Photon 用の名前空間を参照する
using Photon.Pun;

/// <summary>
/// ホッケーゲームのパドルを制御するコンポーネント
/// キー入力により上下に動く
/// </summary>
public class PaddleController : MonoBehaviour
{
    /// <summary>動く速さ</summary>
    [SerializeField] float m_moveSpeed = 10f;
    Rigidbody2D m_rb = null;
    PhotonView m_view = null;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_view = GetComponent<PhotonView>();
    }

    void Update()
    {
        if (!m_view || !m_view.IsMine) return;      // 自分が生成したものだけ処理する

        Move();
    }

    /// <summary>
    /// 左右にキャラクターを動かす
    /// </summary>
    void Move()
    {
        float v = Input.GetAxisRaw("Vertical");

        Vector2 dir = (Vector2.up * v).normalized;
        if (gameObject.transform.position.y < 17.0f && gameObject.transform.position.y > -17.0f)
        {
            m_rb.velocity = dir * m_moveSpeed;
        }
        else
        {
            if (gameObject.transform.position.y > 17.0f)
            {
                gameObject.transform.position = new Vector2(gameObject.transform.position.x, 16.9f);
            }
            else if (gameObject.transform.position.y < -17.0f)
            {
                gameObject.transform.position = new Vector2(gameObject.transform.position.x, -16.9f);
            }
        }
    }
}
