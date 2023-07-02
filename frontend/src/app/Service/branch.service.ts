import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders } from '@angular/common/http';
import { from, Observable } from 'rxjs';
import { Branch, GetBranch } from '../models/Branch';


@Injectable({
  providedIn: 'root'
})
export class BranchService {

  
    branch_url = "http://localhost:62426/api/branch"
 
  
    constructor(private branchHttp : HttpClient) { 
    
    }
  
    getBranchs() {
      return this.branchHttp.get<GetBranch>(this.branch_url )
    }
    getBranchByID(branchId :any): Observable<any> {
      const url = `${this.branch_url}/${branchId}`;
      return this.branchHttp.get<GetBranch>(url);
    }
    addBranch(branch :any ){
      console.log("from  branch service")
      return this.branchHttp.post(this.branch_url,branch )
   
    }
  
    deleteBranch(branchId: number): Observable<any> {
      const url = `${this.branch_url}/${branchId}`;
      return this.branchHttp.delete<Branch>(url);
    }
  
    updateBranch(branchId: number, branch: any): Observable<any> {
      const url = `${this.branch_url}/${branchId}`;
      return this.branchHttp.put(url, branch);
    }
    
}