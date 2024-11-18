using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using StarterAssets;
using UnityEngine.XR.Interaction.Toolkit.Inputs;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

namespace MyFps
{
    public class VR_Opening : MonoBehaviour
    {
        #region Variables
        public GameObject thePlayer;
        public SceneFader fader;

        //sequence UI
        public TextMeshProUGUI textBox;
        [SerializeField]
        private string sequence01 = "...Where am I?";
        [SerializeField]
        private string sequence02 = "I need get out of here";
        //���� ����
        public AudioSource line01;
        public AudioSource line02;
        #endregion

        void Start()
        {
            StartCoroutine(PlaySequence());
        }

        //������ ������
        IEnumerator PlaySequence()
        {
            //0.�÷��� ĳ���� �� Ȱ��ȭ
            thePlayer.GetComponent<DynamicMoveProvider>().enabled = false;

            //1.���̵��� ����(4�� ����� ���ε��� ȿ��)            
            fader.FromFade(8f); //5�ʵ��� ���̵� ȿ��

            //2.ȭ�� �ϴܿ� �ó����� �ؽ�Ʈ ȭ�� ���(3��), ���� ���
            //(...Where am I?)
            yield return new WaitForSeconds(3f);
            textBox.gameObject.SetActive(true);
            textBox.text = sequence01;
            line01.Play();

            yield return new WaitForSeconds(3f);
            //(I need get out of here)
            textBox.text = sequence02;
            line02.Play();

            //3. 3���Ŀ� �ó����� �ؽ�Ʈ ��������
            yield return new WaitForSeconds(3f);
            textBox.text = "";
            textBox.gameObject.SetActive(false);

            //4.�÷��� ĳ���� Ȱ��ȭ
            thePlayer.GetComponent<DynamicMoveProvider>().enabled = true;
        }
    }
}