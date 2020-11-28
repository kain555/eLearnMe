import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MediaRoutingModule } from './media-routing.module';
import { GalleryComponent } from './gallery/gallery.component';
import { NgImageFullscreenViewModule } from 'ng-image-fullscreen-view';
import { SingleAnnounceComponent } from './single-announce/single-announce.component';
@NgModule({
  declarations: [GalleryComponent, SingleAnnounceComponent],
  imports: [CommonModule, MediaRoutingModule, NgImageFullscreenViewModule],
})
export class MediaModule {}
