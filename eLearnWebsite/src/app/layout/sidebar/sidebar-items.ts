import { RouteInfo } from './sidebar.metadata';
export const ROUTES: RouteInfo[] = [
  {
    path: '',
    title: '-- Panel Główny',
    moduleName: '',
    iconType: '',
    icon: '',
    class: '',
    groupTitle: true,
    badge: '',
    badgeClass: '',
    submenu: [],
  },
  {
    path: '/dashboard/main',
    title: 'Strona startowa',
    moduleName: 'dashboard',
    iconType: 'material-icons-two-tone',
    icon: 'home',
    class: '',
    groupTitle: false,
    badge: '',
    badgeClass: '',
    submenu: [],
  },
  {
    path: '',
    title: '-- Moduły',
    moduleName: '',
    iconType: '',
    icon: '',
    class: '',
    groupTitle: true,
    badge: '',
    badgeClass: '',
    submenu: [],
  },
  {
    path: 'calendar',
    title: 'Plan lekcji',
    moduleName: 'calendar',
    iconType: 'material-icons-two-tone',
    icon: 'event_note',
    class: '',
    groupTitle: false,
    badge: '',
    badgeClass: 'badge bg-blue sidebar-badge float-right',
    submenu: [],
  },
  {
    path: 'task',
    title: 'Oceny',
    moduleName: 'task',
    iconType: 'material-icons-two-tone',
    icon: 'fact_check',
    class: '',
    groupTitle: false,
    badge: '',
    badgeClass: '',
    submenu: [],
  },
  {
    path: 'contacts',
    title: 'Kontakty',
    moduleName: 'contacts',
    iconType: 'material-icons-two-tone',
    icon: 'contacts',
    class: '',
    groupTitle: false,
    badge: '',
    badgeClass: '',
    submenu: [],
  },
  {
    path: '',
    title: 'Poczta e-mail',
    moduleName: 'email',
    iconType: 'material-icons-two-tone',
    icon: 'email',
    class: 'menu-toggle',
    groupTitle: false,
    badge: '',
    badgeClass: 'badge bg-orange sidebar-badge float-right',
    submenu: [
      {
        path: '/email/inbox',
        title: 'Skrzynka odbiorcza',
        moduleName: 'email',
        iconType: '',
        icon: '',
        class: 'ml-menu',
        groupTitle: false,
        badge: '',
        badgeClass: '',
        submenu: [],
      },
      {
        path: '/email/compose',
        title: 'Elementy wysłane',
        moduleName: 'email',
        iconType: '',
        icon: '',
        class: 'ml-menu',
        groupTitle: false,
        badge: '',
        badgeClass: '',
        submenu: [],
      },
      {
        path: '/email/read-mail',
        title: 'Ważne',
        moduleName: 'email',
        iconType: '',
        icon: '',
        class: 'ml-menu',
        groupTitle: false,
        badge: '',
        badgeClass: '',
        submenu: [],
      },
    ],
  },
  {
    path: 'task',
    title: 'Egzaminy',
    moduleName: 'task',
    iconType: 'material-icons-two-tone',
    icon: 'fact_check',
    class: '',
    groupTitle: false,
    badge: '',
    badgeClass: '',
    submenu: [],
  },
  {
    path: '',
    title: '-- Szkoła',
    moduleName: '',
    iconType: '',
    icon: '',
    class: '',
    groupTitle: true,
    badge: '',
    badgeClass: '',
    submenu: [],
  },
  {
    path: 'contacts',
    title: 'Komunikaty szkolne',
    moduleName: 'contacts',
    iconType: 'material-icons-two-tone',
    icon: 'contacts',
    class: '',
    groupTitle: false,
    badge: '',
    badgeClass: '',
    submenu: [],
  },
  {
    path: 'contacts',
    title: 'Kadra dydaktyczna',
    moduleName: 'contacts',
    iconType: 'material-icons-two-tone',
    icon: 'contacts',
    class: '',
    groupTitle: false,
    badge: '',
    badgeClass: '',
    submenu: [],
  },
    {
    path: 'task',
    title: 'Oceny',
    moduleName: 'task',
    iconType: 'material-icons-two-tone',
    icon: 'fact_check',
    class: '',
    groupTitle: false,
    badge: '',
    badgeClass: '',
    submenu: [],
  },
  {
    path: 'contacts',
    title: 'Kontakty',
    moduleName: 'contacts',
    iconType: 'material-icons-two-tone',
    icon: 'contacts',
    class: '',
    groupTitle: false,
    badge: '',
    badgeClass: '',
    submenu: [],
  },
  {
    path: 'contacts',
    title: 'E-Biblioteka',
    moduleName: 'contacts',
    iconType: 'material-icons-two-tone',
    icon: 'contacts',
    class: '',
    groupTitle: false,
    badge: '',
    badgeClass: '',
    submenu: [],
  }
];
