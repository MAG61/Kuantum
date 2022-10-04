using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SGSource : MonoBehaviour
{
    public char type = 'x';
    public Transform plusPos;
    public Transform minusPos;
    public Transform Text;

    LineRenderer lineRendPlus;
    LineRenderer lineRendMinus;

    public LayerMask lm;

    private void Awake()
    {
        lineRendPlus = plusPos.transform.GetComponent<LineRenderer>();
        lineRendMinus = minusPos.transform.GetComponent<LineRenderer>();

        DrawRay(lineRendPlus, plusPos.position, new Vector2(plusPos.position.x + 0.1f, plusPos.position.y));
        DrawRay(lineRendMinus, minusPos.position, new Vector2(minusPos.position.x + 0.1f, minusPos.position.y));
    }

    private void Update()
    {
        if (Text.GetComponent<TextMesh>().text != type.ToString())
        {
            Text.GetComponent<TextMesh>().text = type.ToString();
        }

        Vector3 check = transform.position;

        if (!Physics2D.Raycast(plusPos.position, Vector3.left))
        {
            DrawRay(lineRendPlus, plusPos.position, plusPos.position);
        }
        if (!Physics2D.Raycast(minusPos.position, Vector3.left))
        {
            DrawRay(lineRendMinus, minusPos.position, minusPos.position);
        }

    }
    public void ShootLaser(char laserSituation, short state)
    {
        if (laserSituation == type)
        {
            if (state == 0) // 2 lazer
            {
                RaycastHit2D hitPlus;
                RaycastHit2D hitMinus;

                hitPlus = Physics2D.Raycast(plusPos.position, plusPos.transform.right);
                hitMinus = Physics2D.Raycast(minusPos.position, minusPos.transform.right);
                DrawRay(lineRendPlus, plusPos.position, hitPlus.point);
                DrawRay(lineRendMinus, minusPos.position, hitMinus.point);

                if (hitMinus.transform.tag == hitPlus.transform.tag && hitPlus.transform.tag == "Source" 
                    && hitMinus.transform.gameObject.GetInstanceID().ToString() == hitPlus.transform.gameObject.GetInstanceID().ToString())
                {
                    hitPlus.transform.GetComponent<SGSource>().ShootLaser(type, 0);
                }
                else
                {
                    if (hitMinus.transform.tag == "Source")
                    {
                        hitMinus.transform.GetComponent<SGSource>().ShootLaser(type, 2);
                    }
                    else if (hitMinus.transform.tag == "Receiver")
                    {
                        hitMinus.transform.GetComponent<SGReceiver>().DetectLaser(gameObject.transform, minusPos);
                    }
                    if (hitPlus.transform.tag == "Source")
                    {
                        hitPlus.transform.GetComponent<SGSource>().ShootLaser(type, 1);
                    }
                    else if (hitPlus.transform.tag == "Receiver")
                    {
                        hitPlus.transform.GetComponent<SGReceiver>().DetectLaser(gameObject.transform, plusPos);
                    }
                }

            }

            else if (state == 1) // + lazer
            {
                RaycastHit2D hitPlus;

                hitPlus = Physics2D.Raycast(plusPos.position, plusPos.transform.right);
                DrawRay(lineRendPlus, plusPos.position, hitPlus.point);
                DrawRay(lineRendMinus, minusPos.position, minusPos.position);

                if (hitPlus.transform.tag == "Source")
                {
                    hitPlus.transform.GetComponent<SGSource>().ShootLaser(type, 1);
                }
                else if (hitPlus.transform.tag == "Receiver")
                {
                    hitPlus.transform.GetComponent<SGReceiver>().DetectLaser(gameObject.transform, plusPos);
                }
            }

            else if (state == 2) // - lazer
            {
                RaycastHit2D hitMinus;

                hitMinus = Physics2D.Raycast(minusPos.position, minusPos.transform.right);
                DrawRay(lineRendMinus, minusPos.position, hitMinus.point);
                DrawRay(lineRendPlus, plusPos.position, plusPos.position);

                if (hitMinus.transform.tag == "Source")
                {
                    hitMinus.transform.GetComponent<SGSource>().ShootLaser(type, 2);
                }
                else if (hitMinus.transform.tag == "Receiver")
                {
                    hitMinus.transform.GetComponent<SGReceiver>().DetectLaser(gameObject.transform, minusPos);
                }
            }
        }

        else // 2 lazer
        {
            RaycastHit2D hitPlus;
            RaycastHit2D hitMinus;

            hitPlus = Physics2D.Raycast(plusPos.position, plusPos.transform.right);
            hitMinus = Physics2D.Raycast(minusPos.position, minusPos.transform.right);
            DrawRay(lineRendPlus, plusPos.position, hitPlus.point);
            DrawRay(lineRendMinus, minusPos.position, hitMinus.point);

            if (hitMinus.transform.tag == hitPlus.transform.tag && hitPlus.transform.tag == "Source" 
                && hitMinus.transform.gameObject.GetInstanceID().ToString() == hitPlus.transform.gameObject.GetInstanceID().ToString())
            {
                hitPlus.transform.GetComponent<SGSource>().ShootLaser(type, 0);
            }
            else
            {
                if (hitMinus.transform.tag == "Source")
                {
                    hitMinus.transform.GetComponent<SGSource>().ShootLaser(type, 2);
                }
                else if (hitMinus.transform.tag == "Receiver")
                {
                    hitMinus.transform.GetComponent<SGReceiver>().DetectLaser(gameObject.transform, minusPos);
                }
                if (hitPlus.transform.tag == "Source")
                {
                    hitPlus.transform.GetComponent<SGSource>().ShootLaser(type, 1);
                }
                else if (hitPlus.transform.tag == "Receiver")
                {
                    hitPlus.transform.GetComponent<SGReceiver>().DetectLaser(gameObject.transform, plusPos);
                }
            }

        }
    }

    void DrawRay(LineRenderer lr, Vector2 startPos, Vector2 endPos)
    {
        lr.SetPosition(0, startPos);
        lr.SetPosition(1, endPos);

       // lr.gameObject.GetComponent<LaserCollider>().setCollider(startPos, endPos);

        StartCoroutine(ClearRay(lr, startPos));
    }

    IEnumerator ClearRay(LineRenderer lr, Vector2 startPos)
    {
        yield return new WaitForEndOfFrame();

        lr.SetPosition(0, startPos);
        lr.SetPosition(1, startPos);

       // lr.gameObject.GetComponent<LaserCollider>().setCollider(startPos, startPos);
    }

    public void setType(char type)
    {
        this.type = type;
    }

    public char getType() { return this.type; }

}
