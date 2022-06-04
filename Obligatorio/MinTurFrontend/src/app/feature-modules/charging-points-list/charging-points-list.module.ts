import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ChargingPointsListComponent } from './charging-points-list.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
  ],
  declarations: [ChargingPointsListComponent]
})
export class ChargingPointsListModule { }
