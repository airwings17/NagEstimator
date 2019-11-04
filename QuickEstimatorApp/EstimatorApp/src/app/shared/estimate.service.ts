import { Injectable } from '@angular/core';
import { Observable, throwError, of } from 'rxjs';
import { Project, Category, PhasedEstimateDto } from '../app.component';
import { HttpClient, HttpParams, HttpErrorResponse, HttpHeaders, HttpResponse } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class EstimateService {

  constructor(private ohttp: HttpClient) { }

AddPhasedEstimates(phasedEstimates: PhasedEstimateDto): Observable<any> {
    return this.ohttp.post<any>("http://localhost:3434/api/estimation/SavePhasedEstimates",JSON.stringify(phasedEstimates), this.getHttpOptions());
}


getCategories():Observable<Category[]>{  
  return this.ohttp.get<Category[]>("http://localhost:3434/api/estimation/categories")
    .pipe(
      tap(data => console.log('getCategory :' + JSON.stringify(data))),
      catchError(
        (err: HttpErrorResponse) => {

          if (err.error instanceof Error) {
            console.log('error', err.toString());
          }
          return throwError(err);
        }
      )
      );   
 }

getProjects(): Observable<Project[]> {     
    return this.ohttp.get<Project[]>("http://localhost:3434/api/project/")
    .pipe(
      tap(data => console.log('getProject :' + JSON.stringify(data))),
      catchError(
        (err: HttpErrorResponse) => {

          if (err.error instanceof Error) {
            console.log('error', err.toString());
          }
          return throwError(err);
        }
      )
      );      
  }

  getProject(id: number): Observable<Project> {
    if(id==0)
    {
      return of(this.initializeProject());
    }    
    return this.ohttp.get<Project>("http://localhost:3434/api/project/"+id)
    .pipe(
      tap(data => console.log('getProject :' + JSON.stringify(data))),
      catchError(
        (err: HttpErrorResponse) => {

          if (err.error instanceof Error) {
            console.log('error', err.toString());
          }
          return throwError(err);
        }
      )
      );      
  }

  AddProject(projects: Project[]): Observable<any> {
    return this.ohttp.post<any>("http://localhost:3434/api/Project",JSON.stringify(projects), this.getHttpOptions());
  }

  initializeProject():Project
  {
    return {
        Id:0,
        ProjectName:'Default',  

        projectUrlName:'',
        CostPerhr:+'35',
        Team:'',      
        TechnicalApproachNeeded: true,
        EnvtSetupAndRampupNeeded:false,
        BrowserTestingNeeded: true,
        DeviceTestingNeeded: true,
        RegressionTestingNeeded:true,
        PerformanceTestingNeeded: true,
        AutomationTestingNeeded: true,
        UATSupportNeeded: true,
        WarrantySupportNeeded: true,
        ReleaseDocumentNeeded: true,
        AdminGuideNeeded: true,
        UserGuideNeeded: true,          
        PMEffortsinPercentage:+ '15%',
        EmailLink:'',
        SketchLink:'',
        JiraLink:'',
        Manager:'',
        Created:new Date(),
        CreatedBy:'',
        Modified:new Date(),
        ModifiedBy:''            
    };
  }

  private getHttpOptions(): any {
    let httpOptions: any = null;
    try {      
      httpOptions = {        
          
       // headers: new Headers({ 'Content-Type': 'application/json' })     
        headers: new HttpHeaders({'Content-Type': 'application/json'})
        
      };
    } catch (e) {
     //this.log('error', e.toString());

     console.log(e.message);
    }
    return httpOptions;
  }  
}
