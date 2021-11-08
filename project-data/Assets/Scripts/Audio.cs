using UnityEngine;
using Unity.Mathematics;

[RequireComponent(typeof(AudioSource))]
public class Audio : MonoBehaviour
{
    public int length = 32;
    public int sens = 2;
    public int sensJ = 2;
    public int sizeSens = 10000;
    public float outerSens = 3;
    public GameObject cube;
    public GameObject cube1;
    public GameObject cube2;
    public GameObject cube3;
    public GameObject cube4;
    public GameObject cube5;
    public GameObject cube6;
    public GameObject cube7;
    public GameObject cube8;
    public GameObject cube9;
    public GameObject cube10;

    public GameObject[] cubeArr;

    private void Start()
    {
        cubeArr = new GameObject[12];
        cubeArr[0] = cube;
        cubeArr[1] = cube1;
        cubeArr[2] = cube2;
        cubeArr[3] = cube3;
        cubeArr[4] = cube4;
        cubeArr[5] = cube5;
        cubeArr[6] = cube6;
        cubeArr[7] = cube7;
        cubeArr[8] = cube8;
        cubeArr[9] = cube9;
        cubeArr[10] = cube10;
    }
    void Update()
    {
        Time.timeScale = 0.25f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        float[] spectrum = new float[1024];

        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);

        for (int i = 1; i < length; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                cubeArr[j].transform.localScale = new Vector3(1, Mathf.Log10(spectrum[sens + j*sensJ]*sizeSens*10000)*outerSens, 0);
            }
         
        }
    }
}