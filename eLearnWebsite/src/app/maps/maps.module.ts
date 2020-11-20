import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MapsRoutingModule } from './maps-routing.module';
import { AgmCoreModule } from '@agm/core';
@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    MapsRoutingModule,
    AgmCoreModule.forRoot({
      apiKey: 'YOUR API KEY',
    }),
  ],
})
export class MapsModule {}
