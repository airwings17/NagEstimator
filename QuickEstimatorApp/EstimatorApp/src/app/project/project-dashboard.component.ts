import { Component, OnInit,ViewChild } from '@angular/core';
import { EstimateService } from 'src/app/shared/estimate.service';
import {MatPaginator} from '@angular/material/paginator';
import {MatTableDataSource} from '@angular/material/table';
import { Project } from '../app.component';



@Component({
  selector: 'app-project-dashboard',
  templateUrl: './project-dashboard.component.html',
  styleUrls: ['./project-dashboard.component.css']
})
export class ProjectDashboardComponent implements OnInit {
  
  displayedColumns: string[] = ['Action','Id', 'ProjectName', 'CreatedBy', 'Modified'];
  
  dataSource = new MatTableDataSource<ProjectElement>(null);
  projectData :  ProjectElement[] =[];  
  element  : ProjectElement; 
  constructor(private estimateService: EstimateService) {}
 
  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  i:number=0;
 
  public array: any;
  //public displayedColumns = ['', '', '', '', ''];
  //public dataSource: any;    
  
  public pageSize = 10;
  public currentPage = 0;
  public totalSize = 0;

  public handlePage(e: any) {
    this.currentPage = e.pageIndex;
    this.pageSize = e.pageSize;
    this.iterator();
  }
  private iterator() {
    const end = (this.currentPage + 1) * this.pageSize;
    const start = this.currentPage * this.pageSize;
    const part = this.array.slice(start, end);
    this.dataSource = part;
  }

  ngOnInit() {     
   
    this.estimateService.getProjects().subscribe(
      data=>{  
            console.log('success');
            data.forEach(e => {
              this.element =new   ProjectElement();
              this.element.Action="Action";
              this.element.Id = e.Id;
              this.element.projectUrlName = e.projectUrlName; 
              this.element.ProjectName =  e.ProjectName;
              this.element.CreatedBy =  e.CreatedBy;
              this.element.Modified =  e.Modified;                

              this.projectData[this.i++]=this.element;
            });
            this.dataSource = new MatTableDataSource<ProjectElement>(this.projectData);
            this.dataSource.paginator = this.paginator;
            this.array = this.projectData;
            this.totalSize = this.array.length;
            this.iterator();
          }    
    );

    //this.paginator._changePageSize
  } 
}

export class  ProjectElement {
  Action:string
  Id: number;
  ProjectName: string;
  projectUrlName: string;
  CreatedBy: string;
  Modified: Date;
}



