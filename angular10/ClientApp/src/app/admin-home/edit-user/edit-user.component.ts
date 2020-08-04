import { Component, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ActivatedRoute, Router } from '@angular/router';
import { UserModel } from '../../models/UserModel';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import * as _ from 'lodash';

@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.css']
})
export class EditUserComponent implements OnInit {

  selectedUser: UserModel;
  editForm: FormGroup;
  isLoading = false;

  imageError: string;
  isImageSaved: boolean;
  cardImageBase64: string;

  constructor(public modal: NgbActiveModal, private route: ActivatedRoute, private formBuilder: FormBuilder, private router: Router, private http: HttpClient) { }

  ngOnInit() {

    this.setForm()
  }

  onSubmit() {
    if (this.editForm.invalid || this.isLoading) {
      return;
    }
    this.isLoading = true;
    this.http.post(
      '/api/user/UpdateUser',
      this.editForm.value
    )
      .subscribe(
        data => {
          console.log(data);
          this.isLoading = false;
          this.modal.close('Yes');
        },
        error => {
          console.log(error);
          this.isLoading = false;
        }
      );
    //this.usersService.updateUser(this.editForm.value).subscribe(x => {
    //  this.isLoading = false;
    //  this.modal.close('Yes');
    //},
    //  error => {
    //    this.isLoading = false;
    //  });
  }

  get editFormData() { return this.editForm.controls; }

  private setForm() {
    console.log(this.selectedUser);

    this.editForm = this.formBuilder.group({
      userName: [this.selectedUser.userName],
      firstName: [this.selectedUser.firstName, Validators.required],
      passWord: [this.selectedUser.password],
      //email: [{ value: this.selectedUser.email, disabled: true }, [Validators.email, Validators.required]],
      userType: [this.selectedUser.userType, Validators.required],
      avatar: [this.selectedUser.avatar],
    });
  }
  fileChangeEvent(fileInput: any) {
    this.imageError = null;
    if (fileInput.target.files && fileInput.target.files[0]) {
      // Size Filter Bytes
      const max_size = 20971520;
      const allowed_types = ['image/png', 'image/jpeg'];
      const max_height = 15200;
      const max_width = 25600;

      if (fileInput.target.files[0].size > max_size) {
        this.imageError =
          'Maximum size allowed is ' + max_size / 1000 + 'Mb';

        return false;
      }

      if (!_.includes(allowed_types, fileInput.target.files[0].type)) {
        this.imageError = 'Only Images are allowed ( JPG | PNG )';
        return false;
      }
      const reader = new FileReader();
      reader.onload = (e: any) => {
        const image = new Image();
        image.src = e.target.result;
        image.onload = rs => {
          const img_height = rs.currentTarget['height'];
          const img_width = rs.currentTarget['width'];

          console.log(img_height, img_width);


          if (img_height > max_height && img_width > max_width) {
            this.imageError =
              'Maximum dimentions allowed ' +
              max_height +
              '*' +
              max_width +
              'px';
            return false;
          } else {
            const imgBase64Path = e.target.result;
            this.cardImageBase64 = imgBase64Path;
            this.isImageSaved = true;
            this.editForm.get('avatar').setValue(imgBase64Path);
            console.log(imgBase64Path);
            // this.previewImagePath = imgBase64Path;
          }
        };
      };

      reader.readAsDataURL(fileInput.target.files[0]);
    }
  }

  removeImage() {
    this.cardImageBase64 = null;
    this.isImageSaved = false;
  }
}
