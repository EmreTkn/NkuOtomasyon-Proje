import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { of, ReplaySubject } from 'rxjs';
import {map} from 'rxjs/operators';
import { environment } from 'src/environments/environment.prod';
import { IStudent } from '../shared/models/student';
import { HttpClient, HttpHeaders} from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class AccountService {

  baseUrl=environment.baseUrl;

  user:IStudent;

  private currentUserSource=new ReplaySubject<IStudent>(null);
  currentUser$=this.currentUserSource.asObservable();

  constructor(private http:HttpClient) { }


  login(value:any){ //pass ve sifre gelicek servar da kontrol sonra duruma agöre login veya haata mesajı
    return this.http.post(this.baseUrl + 'account/login',value).pipe(
      map((res:IStudent)=>{
        if(res){
          localStorage.setItem('token',res.token);
          this.currentUserSource.next(res);
        }
      })
      );
  }


  logOut(){
    localStorage.removeItem('token');
    this.currentUserSource.next(null);
  }

  register(value:any){
    return this.http.post(this.baseUrl + 'account/register-student',value).pipe(
      map((res:IStudent)=>{
        localStorage.setItem('token',res.token);
        this.currentUserSource.next(res);
      })
    )
  }

  loadCurrentUser(token:string){
    if(token===null){
      this.currentUserSource.next(null);
      return of(null);
    }

    return this.http.get(this.baseUrl+'account').pipe(
      map((res:IStudent)=>{
        if(res){
          localStorage.setItem('token',res.token);
          this.currentUserSource.next(res);
        }
      })
    )
  }
}
