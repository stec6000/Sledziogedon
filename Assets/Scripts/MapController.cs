using UnityEngine;
using System.Collections;

public class MapController : MonoBehaviour {
    public int mapPartsAmount = 3;

    private Transform cameraTransform;
    private Vector2 cameraHalfWidthHeight;

    private float lastXToLoadNewPart = 0;
    private float nextXToLoadNewPart = 0;
    private float nextYToLoadNewPart = 0;
    private float lastYofXLoading = 0;

    private float maxY = 0;
    // Use this for initialization
    void Start () {
        cameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
        cameraHalfWidthHeight = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        cameraHalfWidthHeight -= new Vector2(cameraTransform.position.x, cameraTransform.position.y);

        nextXToLoadNewPart = cameraTransform.position.x + cameraHalfWidthHeight.x;
        nextYToLoadNewPart = cameraTransform.position.y + cameraHalfWidthHeight.y;

        maxY = PlayerPrefs.GetFloat("High") + 2;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        /*if (cameraTransform.position.x - cameraHalfWidthHeight.x > nextXToLoadNewPart)
        {
            nextYToLoadNewPart = cameraTransform.position.y + cameraHalfWidthHeight.y;
        }*/

        if (cameraTransform.position.x + cameraHalfWidthHeight.x + 20>= nextXToLoadNewPart)
        {
            float yDoPrzekroczenia = maxY;//cameraTransform.position.y + cameraHalfWidthHeight.y + 40;
            float yAktualny = -2;
            //if (cameraTransform.position.y - 30 - cameraHalfWidthHeight.y > yAktualny)
            //    yAktualny = cameraTransform.position.y - 30 - cameraHalfWidthHeight.y;
            float najdalszyX = 0;

            int a = 0;
            while (yAktualny < yDoPrzekroczenia || a > 30)
            {
                string map = "MapsParts/MapPart" + Random.Range(1, mapPartsAmount + 1);
                GameObject mapPartPrefab = Resources.Load(map) as GameObject;
                float mapPartWidth = (Utils.FindObjectInChildWithTag(mapPartPrefab, "rightSide").transform.position.x
                    - Utils.FindObjectInChildWithTag(mapPartPrefab, "leftSide").transform.position.x);
                float mapPartHeight = (Utils.FindObjectInChildWithTag(mapPartPrefab, "topSide").transform.position.y
                    - Utils.FindObjectInChildWithTag(mapPartPrefab, "botSide").transform.position.y);

                if (isFitByCoordinate(mapPartHeight, yAktualny, yDoPrzekroczenia))
                {
                    float x;
                    if (nextXToLoadNewPart + mapPartWidth >= najdalszyX)
                    {
                        najdalszyX = nextXToLoadNewPart + mapPartWidth;
                        x = nextXToLoadNewPart + (mapPartWidth / 2);
                    }else
                    {
                        float roznica = najdalszyX - nextXToLoadNewPart;
                        roznica = roznica - mapPartWidth;
                        x = Random.Range(nextXToLoadNewPart + (roznica/2), najdalszyX - (roznica/2));
                    }
                    GameObject mapPart = Instantiate(mapPartPrefab,
                                    new Vector3(x, yAktualny + (mapPartHeight / 2), mapPartPrefab.transform.position.z),
                                    Quaternion.identity) as GameObject;
                    yAktualny = yAktualny + mapPartHeight;
                    lastYofXLoading = yAktualny;
                }else
                {
                    break;
                }
            }
            lastXToLoadNewPart = nextXToLoadNewPart;
            nextXToLoadNewPart = najdalszyX;
        }
        //KAMERA WYJDZIE PONAD Y
        //
        /*if (cameraTransform.position.y + cameraHalfWidthHeight.y >= lastYofXLoading
            && cameraTransform.position.x + cameraHalfWidthHeight.x - 1 > lastXToLoadNewPart)
        {
            //X1 = KRANIEC KAMERY LUB lastXToLoadNewPart trzeba sprawdzic co jest dalej
            //Y1 = WYSOKOSC KAMERY LUB OSTATNIO ZAPISYWANY
            //X2 = nextXToLoadNewPart
            //Y2 = Y1 + WYSOKOSC EKRANU

            //WARUNEK OD KRANCA KAMERY
            Debug.Log(Time.time + "     IF");
            float yDoPrzekroczenia = nextYToLoadNewPart;

            float yAktualny = lastYofXLoading;

            float najwyzszyY = 0;
            
            int a = 0;
            while (yAktualny < yDoPrzekroczenia || a > 30)
            {
                string map = "MapsParts/MapPart" + Random.Range(1, mapPartsAmount + 1);
                GameObject mapPartPrefab = Resources.Load(map) as GameObject;
                float mapPartWidth = (Utils.FindObjectInChildWithTag(mapPartPrefab, "rightSide").transform.position.x
                    - Utils.FindObjectInChildWithTag(mapPartPrefab, "leftSide").transform.position.x);
                float mapPartHeight = (Utils.FindObjectInChildWithTag(mapPartPrefab, "topSide").transform.position.y
                    - Utils.FindObjectInChildWithTag(mapPartPrefab, "botSide").transform.position.y);

                if (isFitByCoordinate(mapPartHeight, yAktualny, yDoPrzekroczenia))
                {
                    if (yAktualny + mapPartWidth > najwyzszyY)
                        najwyzszyY = nextYToLoadNewPart + mapPartHeight;
                    GameObject mapPart = Instantiate(mapPartPrefab,
                                            new Vector3(lastXToLoadNewPart + (mapPartWidth/2),
                                                        yAktualny + (mapPartHeight/2),
                                                        mapPartPrefab.transform.position.z),
                                            Quaternion.identity) as GameObject;
                    yAktualny = yAktualny + mapPartHeight;
                }
                else
                {
                    break;
                }
                lastYofXLoading = najwyzszyY;
            }
        }*/
        /*if (cameraTransform.position.y + cameraHalfWidthHeight.y >= nextYToLoadNewPart)
        {
            //X1 = KRANIEC KAMERY LUB lastXToLoadNewPart trzeba sprawdzic co jest dalej
            //Y1 = WYSOKOSC KAMERY LUB OSTATNIO ZAPISYWANY
            //X2 = nextXToLoadNewPart
            //Y2 = Y1 + WYSOKOSC EKRANU

            //WARUNEK OD KRANCA KAMERY
            Debug.Log(Time.time + "      ELSE");
            float xDoPrzekroczenia = nextXToLoadNewPart;
            float xAktualny = cameraTransform.position.x - cameraHalfWidthHeight.x;

            float najwyzszyY = 0;

            int a = 0;
            while (xAktualny < xDoPrzekroczenia || a > 30)
            {
                string map = "MapsParts/MapPart" + Random.Range(1, mapPartsAmount + 1);
                GameObject mapPartPrefab = Resources.Load(map) as GameObject;
                float mapPartWidth = (Utils.FindObjectInChildWithTag(mapPartPrefab, "rightSide").transform.position.x
                    - Utils.FindObjectInChildWithTag(mapPartPrefab, "leftSide").transform.position.x);
                float mapPartHeight = (Utils.FindObjectInChildWithTag(mapPartPrefab, "topSide").transform.position.y
                    - Utils.FindObjectInChildWithTag(mapPartPrefab, "botSide").transform.position.y);

                if (isFitByCoordinate(mapPartWidth, xAktualny, xDoPrzekroczenia))
                {
                    if (nextYToLoadNewPart + mapPartWidth > najwyzszyY)
                        najwyzszyY = nextYToLoadNewPart + mapPartHeight;
                    GameObject mapPart = Instantiate(mapPartPrefab,
                                            new Vector3(xAktualny + mapPartWidth,
                                                        nextYToLoadNewPart + mapPartHeight,
                                                        mapPartPrefab.transform.position.z),
                                            Quaternion.identity) as GameObject;
                    xAktualny = xAktualny + mapPartWidth;
                }
                else
                {
                    break;
                }
                nextYToLoadNewPart = najwyzszyY;
            }
        }*/
    }

    bool isFitByCoordinate(float height,float yBegin, float yMax)
    {
        if (yBegin + height > yMax)
            return false;
        return true;
    }
}
