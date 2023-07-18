import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AlertService } from './alert.service';
import { AlertComponent } from './alert.component';

@NgModule({
  declarations: [
    AlertComponent
  ],
  imports: [
    CommonModule
  ],
   providers: [AlertService],
   exports:[AlertComponent]
})
export class AlertModule { }
