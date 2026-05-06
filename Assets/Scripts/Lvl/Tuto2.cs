using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Tuto2 : MonoBehaviour
{
    [SerializeField] private Ant _ant = null;
    private bool _done = false;
    private int _state = 0;
    [SerializeField] private TMP_Text _text = null;
    [SerializeField] private GameObject _gameObject = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckForSelection();
        CheckForInput();
    }

    private void Bravo()
    {
        if (_state < 3)
        {
            _state = 3;
            NextText();
        }
    }

    private void CheckForInput()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (_state != 3 && _state != 6)
            {
                _state += 1;
                NextText();
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (_state != 3 && _state != 6)
            {
                _state += 1;
                NextText();
            }
        }
    }

    private void CheckForSelection()
    {
        if (RessourceManager.Instance.Food != 0 && !_done)
        {
            _done = true;
            _state = 4;
            NextText();
            Vector3 a = new Vector3(-6.15f, 0.5f, -8.11f);
            Quaternion b = Quaternion.identity;
            GameObject enemy = Instantiate(_gameObject, a, b);
            Enemy enemyScript = enemy.GetComponent<Enemy>();
            enemyScript.AttackBase = true;
            enemyScript.Size = 2;
        }
    }

    private void NextText()
    {
        switch (_state)
        {
            case 0:
                _text.text = "Envoie des fourmis sur des points de ressources pour qu'elles commencent à récolter";
                break;
            case 1:
                _text.text = "La nourriture récoltée permet de générer plus de fourmis";
                break;
            case 2:
                _text.text = "Appuie sur Espace pour diviser un groupe en deux et commencer à récolter aux deux points de ressources";
                break;
            case 3:
                _text.text = "";
                break;
            case 4:
                _text.text = "Des ennemis sont apparus ! Envoie des fourmis défendre ton territoire";
                break;
            case 5:
                _text.text = "Si ta fourmilière tombe, la partie est finie, n'hésite pas à envoyer tes fourmis au casse pipe si c'est pour la protéger";
                break;
            case 6:
                _text.text = "";
                break;

            default:
                _text.text = "";
                break;
        }
    }
}
