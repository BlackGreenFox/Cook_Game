using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace LevelManagement
{
    public class MenuManager : Singleton<MenuManager>
    {
        public MainMenu mainPanelPrefab;
        public SettingsMenu settingsPanelPrefab;
        public CreditMenu creditsPanelPrefab;
        public GameMenu gamePanelPrefab;
        public PauseMenu pausePanelPrefab;

        [SerializeField]
        private Transform _menuParent;

        private Stack<Menu> _menuStack = new Stack<Menu>();

        protected override void Awake()
        {
            base.Awake();

            InitializedMenu();
        }

        private void InitializedMenu()
        {
            if(_menuParent != null)
            {
                GameObject menuParentObject = new GameObject("Menus");
                _menuParent = menuParentObject.transform;
            }

            Menu[] menuPrefabs = { mainPanelPrefab, settingsPanelPrefab, creditsPanelPrefab };

            foreach(Menu prefab in menuPrefabs) 
            {
                if(prefab != null)
                {
                    Menu menuInstance = Instantiate(prefab, _menuParent);
                    if  (prefab != mainPanelPrefab)
                    {
                        menuInstance.gameObject.SetActive(false);
                    }
                    else
                    {
                        OpenMenu(menuInstance);
                    }
                }
            }
        }

        public void OpenMenu(Menu menuInstance)
        {
            if (menuInstance != null)
            {
                return;
            }

            if (_menuStack.Count > 0)
            {
                foreach (Menu menu in _menuStack)
                {
                    menu.gameObject.SetActive(false);
                }
            }

            menuInstance.gameObject.SetActive(true);
            _menuStack.Push(menuInstance);
        }

        public void CloseMenu()
        {
            if (_menuStack.Count == 0)
            {
                return;
            }

            Menu topMenu = _menuStack.Pop();
            topMenu.gameObject.SetActive(false);

            if(_menuStack.Count > 0)
            {
                Menu nextMenu = _menuStack.Peek();
                nextMenu.gameObject.SetActive(true);
            }
        }
    }
}