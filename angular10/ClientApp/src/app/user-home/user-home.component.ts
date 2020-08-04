import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserModel } from '../models/UserModel';

@Component({
  selector: 'app-user-home',
  templateUrl: './user-home.component.html',
  styleUrls: ['./user-home.component.css']
})
export class UserHomeComponent implements OnInit {

  userData: string;
  public arrUser: UserModel[] = [];

  constructor(private http: HttpClient) { }

  ngOnInit() {
  }

  fetchUserData() {
    this.http.get('/api/user/GetUserData').subscribe(
      data => {
        this.userData = data.toString();
      },
      error => {
        this.userData = error;
      }
    );
    
  }
}     
