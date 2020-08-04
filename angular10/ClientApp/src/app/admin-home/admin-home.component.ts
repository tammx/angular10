import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserModel } from '../models/UserModel';
import { EditUserComponent } from './edit-user/edit-user.component';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-admin-home',
  templateUrl: './admin-home.component.html',
  styleUrls: ['./admin-home.component.css']
})
export class AdminHomeComponent implements OnInit {

  adminData: string;
  public arrUser: UserModel[] = [];

  constructor(private http: HttpClient, private modalService: NgbModal) { }

  ngOnInit() {
    this.loadData();
  }
  loadData() {
    this.http.post(
      '/api/user/GetUserByRole',
      { RoleId: "User" }
    )
      .subscribe(
        data => {
          console.log(data);
          this.arrUser = data as UserModel[];
          console.log(this.arrUser);

        },
        error => {
          console.log(error);
          alert('Không có dữ liệu');

        }
      );
  }
  editUser(userModel: UserModel) {
    const ref = this.modalService.open(EditUserComponent, { centered: true });
    ref.componentInstance.selectedUser = userModel;

    ref.result.then((yes) => {
      console.log("Yes Click");

      this.loadData();
    },
      (cancel) => {
        console.log("Cancel Click");

      })
  }
    
  
}    
