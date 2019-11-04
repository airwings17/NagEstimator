import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { EstimateRoutingModule } from './estimate-routing.module';
import { PhasedComponent } from './phased/phased.component';
import { FeaturedComponent } from './featured/featured.component';
import { FeaturedPreviewComponent } from './featured/featured-preview.component';
import { PhasedPreviewComponent } from './phased/phased-preview.component';
import {MatTableModule} from '@angular/material/table';
import {MatButtonModule} from '@angular/material/button';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatDividerModule} from '@angular/material/divider';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatRadioModule} from '@angular/material/radio';
import {MatInputModule} from '@angular/material';
import { MatPaginatorModule } from '@angular/material';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import {MatExpansionModule} from '@angular/material/expansion';

@NgModule({
  declarations: [PhasedComponent, FeaturedComponent, FeaturedPreviewComponent, PhasedPreviewComponent],
  imports: [
    CommonModule,
    EstimateRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    MatTableModule,
    MatButtonModule,
    MatFormFieldModule,
    MatDividerModule,
    MatCheckboxModule,
    MatRadioModule,
    MatInputModule,
    MatPaginatorModule,
    MatProgressSpinnerModule,
    MatExpansionModule
    
  ]
})
export class EstimateModule { }
