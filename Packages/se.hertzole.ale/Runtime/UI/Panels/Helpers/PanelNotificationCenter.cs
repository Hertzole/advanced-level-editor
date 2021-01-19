using System.Collections.Generic;

namespace Hertzole.ALE
{
    public static class PanelNotificationCenter
    {
        internal static class Internal
        {
            public static void PanelCreated(Panel panel)
            {
                if (!IsPanelRegistered(panel))
                {
                    panels.Add(panel);

                    panel.Internal.ChangeCloseButtonVisibility(onPanelClosed != null);

                    OnPanelCreated?.Invoke(panel);

                    if (panel.gameObject.activeInHierarchy)
                    {
                        OnPanelBecameActive?.Invoke(panel);
                    }
                    else
                    {
                        OnPanelBecameInactive?.Invoke(panel);
                    }
                }
            }

            public static void PanelDestroyed(Panel panel)
            {
                if (panels.Remove(panel) && OnPanelDestroyed != null)
                {
                    OnPanelDestroyed(panel);
                }
            }

            public static void PanelBecameActive(Panel panel)
            {
                if (IsPanelRegistered(panel))
                {
                    OnPanelBecameActive?.Invoke(panel);
                }
            }

            public static void PanelBecameInactive(Panel panel)
            {
                if (IsPanelRegistered(panel))
                {
                    OnPanelBecameInactive?.Invoke(panel);
                }
            }

            public static void PanelClosed(Panel panel)
            {
                onPanelClosed?.Invoke(panel);
            }

            public static void TabDragStateChanged(PanelTab tab, bool isDragging)
            {
                if (isDragging)
                {
                    OnStartedDraggingTab?.Invoke(tab);
                }
                else
                {
                    OnStoppedDraggingTab?.Invoke(tab);
                }
            }

            public static void ActiveTabChanged(PanelTab tab)
            {
                OnActiveTabChanged?.Invoke(tab);
            }

            public static void TabIDChanged(PanelTab tab, string previousID, string newID)
            {
                if (!idToTab.ContainsValue(tab))
                {
                    tab.Internal.ChangeCloseButtonVisibility(onTabClosed != null);

                    OnTabCreated?.Invoke(tab);
                }

                if (!string.IsNullOrEmpty(previousID))
                {
                    if (idToTab.TryGetValue(previousID, out PanelTab previousTab) && previousTab == tab)
                    {
                        idToTab.Remove(previousID);
                    }
                }

                if (!string.IsNullOrEmpty(newID))
                {
                    idToTab[newID] = tab;
                }
                else
                {
                    OnTabDestroyed?.Invoke(tab);
                }
            }

            public static void TabClosed(PanelTab tab)
            {
                onTabClosed?.Invoke(tab);
            }

            private static bool IsPanelRegistered(Panel panel)
            {
                for (int i = panels.Count - 1; i >= 0; i--)
                {
                    if (panels[i] == panel)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        public delegate void PanelDelegate(Panel panel);
        public delegate void TabDelegate(PanelTab tab);

        public static event PanelDelegate OnPanelCreated, OnPanelDestroyed, OnPanelBecameActive, OnPanelBecameInactive;
        public static event TabDelegate OnTabCreated, OnTabDestroyed, OnActiveTabChanged, OnStartedDraggingTab, OnStoppedDraggingTab;

        private static PanelDelegate onPanelClosed;
        public static event PanelDelegate OnPanelClosed
        {
            add
            {
                if (value != null)
                {
                    if (onPanelClosed == null)
                    {
                        for (int i = panels.Count - 1; i >= 0; i--)
                        {
                            panels[i].Internal.ChangeCloseButtonVisibility(true);
                        }
                    }

                    onPanelClosed += value;
                }
            }
            remove
            {
                if (value != null && onPanelClosed != null)
                {
                    onPanelClosed -= value;

                    if (onPanelClosed == null)
                    {
                        for (int i = panels.Count - 1; i >= 0; i--)
                        {
                            panels[i].Internal.ChangeCloseButtonVisibility(false);
                        }
                    }
                }
            }
        }

        private static TabDelegate onTabClosed;
        public static event TabDelegate OnTabClosed
        {
            add
            {
                if (value != null)
                {
                    if (onTabClosed == null)
                    {
                        foreach (PanelTab tab in idToTab.Values)
                        {
                            tab.Internal.ChangeCloseButtonVisibility(true);
                        }
                    }

                    onTabClosed += value;
                }
            }
            remove
            {
                if (value != null && onTabClosed != null)
                {
                    onTabClosed -= value;

                    if (onTabClosed == null)
                    {
                        foreach (PanelTab tab in idToTab.Values)
                        {
                            tab.Internal.ChangeCloseButtonVisibility(false);
                        }
                    }
                }
            }
        }

        private static readonly List<Panel> panels = new List<Panel>(32);
        public static int NumberOfPanels { get { return panels.Count; } }

        private static readonly Dictionary<string, PanelTab> idToTab = new Dictionary<string, PanelTab>(32);

        public static Panel GetPanel(int panelIndex)
        {
            if (panelIndex >= 0 && panelIndex < panels.Count)
            {
                return panels[panelIndex];
            }

            return null;
        }

        public static bool TryGetTab(string tabID, out PanelTab tab)
        {
            if (string.IsNullOrEmpty(tabID))
            {
                tab = null;
                return false;
            }

            return idToTab.TryGetValue(tabID, out tab);
        }
    }
}
