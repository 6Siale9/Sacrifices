using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tuto2 : MonoBehaviour
{
    [SerializeField] private Ant _ant = null;
    private bool _done = false;
    private int _state = 0;
    [SerializeField] private TMP_Text _text = null;
    [SerializeField] private GameObject _gameObject = null;
    private float _cd = 20;
    private bool _caca = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckForSelection();
        CheckForInput();
        Wait();
    }

    private void Wait()
    {
        if (_done && _caca)
        {
            if (_cd > 0)
            {
                _cd -= Time.deltaTime;
            }
            else
            {
                _caca = false;
                _state = 7;
                NextText();
            }
        }
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
        if (Input.GetKeyUp(KeyCode.Space))
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
                _text.text = "Envoie des fourmis sur les points de ressources pour qu'elles commencent a recolter";
                break;
            case 1:
                _text.text = "La nourriture recoltee permet de generer plus de fourmis";
                break;
            case 2:
                _text.text = "Appuie sur Espace pour diviser un groupe en deux et commencer a recolter aux deux points de ressources";
                break;
            case 3:
                _text.text = "";
                break;
            case 4:
                _text.text = "Des ennemis sont apparus ! Envoie des fourmis defendre ton territoire";
                break;
            case 5:
                _text.text = "Si ta fourmiliere tombe, la partie est finie, n'hesite pas a envoyer tes fourmis au casse pipe si c'est pour la proteger";
                break;
            case 6:
                _text.text = "";
                break;
            case 7:
                _text.text = "Bien, te voila pret. Tente de reconstruire les ruines de prochains niveaux en sacrifiant des fourmis pour la tache";
                break;
            case 8:
                _text.text = "Bonne chance et attention aux terriers ennemis !";
                break;
            case 9:
                SceneManager.LoadScene(4);
                break;
            default:
                _text.text = "";
                break;
        }
    }
}
