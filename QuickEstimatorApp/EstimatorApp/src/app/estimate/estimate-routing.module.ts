import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PhasedComponent } from './phased/phased.component';
import { FeaturedComponent } from './featured/featured.component';
import { FeaturedPreviewComponent } from './featured/featured-preview.component';
import { PhasedPreviewComponent } from './phased/phased-preview.component';
const routes: Routes = [   
  {path: ':projId/phased/:estId', component:  PhasedComponent},
  {path: ':projId/featured/:estId', component: FeaturedComponent } 
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EstimateRoutingModule { }
