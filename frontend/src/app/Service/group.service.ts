import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders } from '@angular/common/http';
import { from, Observable } from 'rxjs';
import { Group } from '../models/Group';


@Injectable({
  providedIn: 'root'
})
export class GroupService {

  
    group_url = "http://localhost:62426/api/Group"

    constructor(private groupHttp : HttpClient) { 
    
    }
  
    getGroups () {
      return this.groupHttp.get<Group>(this.group_url )
    }
    getGroupByID(groupId :any): Observable<any> {
      const url = `${this.group_url}/${groupId}`;
      return this.groupHttp.get<Group>(url);
    }


    addGroup(group :any ){
      return this.groupHttp.post<Group>(this.group_url,group )
    }
  
    deleteGroup(groupId: number): Observable<any> {
      const url = `${this.group_url}/${groupId}`;
      return this.groupHttp.delete<Group>(url);
    }
  
    updateGroup(groupId: number, group: any): Observable<any> {
      const url = `${this.group_url}/${groupId}`;
      return this.groupHttp.put<Group>(url, group);
    }
    
}