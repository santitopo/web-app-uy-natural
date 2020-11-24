import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { AdminsService } from 'src/app/services/admins.service';
import { Admin } from 'src/Models/Admin';

@Component({
  selector: 'app-adminstrator-actions',
  templateUrl: './adminstrator-actions.component.html',
  styleUrls: ['./adminstrator-actions.component.css']
})
export class AdminstratorActionsComponent implements OnInit {
  //AddAdmin variables
  hide = true;
  email = new FormControl('', [Validators.required, Validators.email]);
  adminName: string;
  adminSurname: string;
  adminEmail: string;
  adminPassword: string;

  //Delete/Modify Admin
  admins;
  selectedAdmin: Admin;
  selectedAdminName: string;
  selectedAdminSurname: string;
  selectedAdminEmail: string;
  selectedAdminPassword: string;


  constructor(private adminsService: AdminsService) { }

  ngOnInit(): void {

    this.adminsService.getAdmins().subscribe(
      res => {
        this.admins = res;
      },
      err => {
        alert('Ups algo salió mal...');
        console.log(err);
      });
      
  }

  getErrorMessage() {
    if (this.email.hasError('required')) {
      return 'You must enter a value';
    }

    return this.email.hasError('email') ? 'Not a valid email' : '';
  }

  //Verificar Mail!!
  addAdmin(): void {
    if(this.checkParameters()){
      const admin = new Admin(this.adminName, this.adminSurname,
        this.adminEmail, this.adminPassword);
  
      this.adminsService.addAdmin(admin).subscribe();
      
    }else{
      alert("Error: Ya existe un administrador con ese mail!");
    }
    
  }

  select(selectedAdmin: Admin): void{
    this.selectedAdminName = selectedAdmin.name;
    this.selectedAdminSurname = selectedAdmin.surname;
    this.selectedAdminEmail = selectedAdmin.mail;
    this.selectedAdminPassword = selectedAdmin.password;
  }
  
  modifyAdmin(): void{
    this.selectedAdmin.mail = this.selectedAdminEmail;
    this.selectedAdmin.name = this.selectedAdminName;
    this.selectedAdmin.surname = this.selectedAdminSurname;
    this.selectedAdmin.password = this.selectedAdminPassword;

    this.adminsService.modifyAdmin(this.selectedAdmin).subscribe();
  }

  deleteAdmin(): void{
    this.adminsService.deleteAdmin(this.selectedAdmin.id).subscribe();
  }

  checkParameters(): boolean{
    let ret = true;
    this.admins.forEach(object => {
      if(object.mail == this.adminEmail){
        alert("repetido");
        ret = false;
      }
    });
    return ret;
  }

}
