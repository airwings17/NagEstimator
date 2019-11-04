import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { HeaderComponent } from './shared/header/header.component';
import { FooterComponent } from './shared/footer/footer.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatInputModule, MatButtonModule, MatSelectModule, MatIconModule } from '@angular/material';
import {MatTabsModule} from '@angular/material/tabs';
@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatInputModule, 
    MatButtonModule,
    MatSelectModule,
    MatIconModule,
    MatTabsModule,    
    RouterModule.forRoot([
      {
        path: '',  pathMatch: 'full', redirectTo: 'dashboard'
      },      
      {
        path: 'dashboard', loadChildren: () => import('./project/project.module').then(m => m.ProjectModule)
      },
      {
        path: 'estimates', loadChildren: () => import('./estimate/estimate.module').then(m => m.EstimateModule)
      }
      
    ], { scrollPositionRestoration: 'enabled' })    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
