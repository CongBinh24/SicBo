using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceManager : MonoBehaviour
{
    public List<Image> dices;// DS SpriteRenderer của xúc xắc
    [SerializeField] private Sprite[] spr; //DS 6 mặt xúc xắc
    private int[] diceValues;
    public GameObject Lid;
    void Start()
    {
        diceValues = new int[dices.Count];
        StartCoroutine(AutoRoll());
    }

    //public int[] GetDiceValues()
    //{
    //    return diceValues;
    //}


    private IEnumerator AutoRoll()
    {
        while (true) // lặp vĩnh viễn
        {
            yield return StartCoroutine(PlayRound()); // Gọi vòng roll
            yield return new WaitForSeconds(7f); // nghỉ 1 giây rồi roll tiếp
        }
    }

    private IEnumerator PlayRound() 
    {
        Lid.SetActive(true);

        yield return new WaitForSeconds(4f);
        Lid.SetActive(false);
        for (int i = 0; i < dices.Count; i++)
        {
            int random = Random.Range(1, spr.Length);
            dices[i].sprite = spr[random];
            diceValues[i] = random;
        }
        Sum();
    }

    private void Sum()
    {
        int total = diceValues[0] + diceValues[1] + diceValues[2];
        Debug.Log("Ket qua = " + total);
    }
}
