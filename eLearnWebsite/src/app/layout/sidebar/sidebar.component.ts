import { Router, NavigationEnd } from '@angular/router';
import { DOCUMENT } from '@angular/common';
import {
  Component,
  Inject,
  ElementRef,
  OnInit,
  Renderer2,
  HostListener,
} from '@angular/core';
import { ROUTES } from './sidebar-items';
import { AuthService } from 'src/app/core/service/auth.service';
import { date } from 'ngx-custom-validators/src/app/date/validator';
@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.sass'],
})
export class SidebarComponent implements OnInit {
  minutes: string;
  currDate: Date;
  dayOfWeek: string;
  public sidebarItems: any[];
  showMenu = 'dashboard';
  showSubMenu = '';
  showSubSubMenu = '';
  public innerHeight: any;
  public bodyTag: any;
  listMaxHeight: string;
  listMaxWidth: string;
  userFullName: string;
  userImg: string;
  userType: string;
  headerHeight = 60;
  currentRoute: string;
  constructor(
    @Inject(DOCUMENT) private document: Document,
    private renderer: Renderer2,
    public elementRef: ElementRef,
    private authService: AuthService,
    private router: Router
  ) {
    this.router.events.subscribe((event) => {
      if (event instanceof NavigationEnd) {
        if (event.url.split('/')[1] === 'multilevel') {
          this.showMenu = event.url.split('/')[1];
        } else {
          this.showMenu = event.url.split('/').slice(-2)[0];
        }
        this.showSubMenu = event.url.split('/').slice(-2)[0];
      }
    });
  }
  @HostListener('window:resize', ['$event'])
  windowResizecall(event) {
    this.setMenuHeight();
    this.checkStatuForResize(false);
  }
  @HostListener('document:mousedown', ['$event'])
  onGlobalClick(event): void {
    if (!this.elementRef.nativeElement.contains(event.target)) {
      this.renderer.removeClass(this.document.body, 'overlay-open');
    }
  }
  callMenuToggle(event: any, element: any) {
    if (element === this.showMenu) {
      this.showMenu = '0';
    } else {
      this.showMenu = element;
    }
    const hasClass = event.target.classList.contains('toggled');
    if (hasClass) {
      this.renderer.removeClass(event.target, 'toggled');
    } else {
      this.renderer.addClass(event.target, 'toggled');
    }
  }
  callSubMenuToggle(event: any, element: any) {
    if (element === this.showSubMenu) {
      this.showSubMenu = '0';
    } else {
      this.showSubMenu = element;
    }
  }
  ngOnInit() {
    this.currDate = new Date();
    var day = this.currDate.getDay();
    this.leadingZero(this.currDate.getMinutes());
    this.getDayOfWeek(day);
    this.sidebarItems = ROUTES.filter((sidebarItem) => sidebarItem);
    this.initLeftSidebar();
    this.bodyTag = this.document.body;
  }
  initLeftSidebar() {
    const _this = this;
    // Set menu height
    _this.setMenuHeight();
    _this.checkStatuForResize(true);
  }
  setMenuHeight() {
    this.innerHeight = window.innerHeight;
    const height = this.innerHeight - this.headerHeight;
    this.listMaxHeight = height + '';
    this.listMaxWidth = '500px';
  }
  isOpen() {
    return this.bodyTag.classList.contains('overlay-open');
  }
  checkStatuForResize(firstTime) {
    if (window.innerWidth < 1170) {
      this.renderer.addClass(this.document.body, 'ls-closed');
    } else {
      this.renderer.removeClass(this.document.body, 'ls-closed');
    }
  }
  mouseHover(e) {
    const body = this.elementRef.nativeElement.closest('body');
    if (body.classList.contains('submenu-closed')) {
      this.renderer.addClass(this.document.body, 'side-closed-hover');
      this.renderer.removeClass(this.document.body, 'submenu-closed');
    }
  }
  mouseOut(e) {
    const body = this.elementRef.nativeElement.closest('body');
    if (body.classList.contains('side-closed-hover')) {
      this.renderer.removeClass(this.document.body, 'side-closed-hover');
      this.renderer.addClass(this.document.body, 'submenu-closed');
    }
  }

   leadingZero(i: number) {
    if (i < 10) {
      this.minutes = "0" + i.toString();
     } 
     else 
     this.minutes = i.toString();
}

  getDayOfWeek(dayOfWeek: number) {
    if(dayOfWeek === 0){
      this.dayOfWeek = "Niedziela"
    }
    else if (dayOfWeek === 1) {
      this.dayOfWeek = "Poniedziałek"
    }
    else if (dayOfWeek === 2) {
     this.dayOfWeek = "Wtorek"
   }
   else if (dayOfWeek === 3) {
     this.dayOfWeek = "Środa"
   }
   else if (dayOfWeek === 4) {
     this.dayOfWeek = "Czwartek"
   }
   else if (dayOfWeek === 5) {
     this.dayOfWeek = "Piątek"
   }
   else if (dayOfWeek === 6) {
     this.dayOfWeek = "Sobota"
   }
  }
}
