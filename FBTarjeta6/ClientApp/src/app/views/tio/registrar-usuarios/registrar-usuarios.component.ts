import { Component, OnInit } from '@angular/core';
import { Tio } from 'src/app/commons/models/tio';
import { TioService } from '../tio.service';
import { Router } from '@angular/router';

import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Usertoken } from 'src/app/models/usertoken';
import { TokenService } from '../../accederwebtoken/token.service';


@Component({
  selector: 'app-registrar-usuarios',
  templateUrl: './registrar-usuarios.component.html',
  styleUrls: ['./registrar-usuarios.component.css']
})
export class RegistrarUsuariosComponent implements OnInit {
  login: Usertoken | null;
  tio: Tio;
  nombre = '';
  email = 'zddfdfdsfd';
  password = '';
  registerForm: FormGroup;
  usuariologeado = false;
  constructor(
    private tioService: TioService, 
    private tokenService: TokenService, 
    private fb: FormBuilder, 
    private router: Router) {
      this.tio = new Tio("", "", "");
      this.registerForm = this.fb.group({ 
        id:0,
        nombre: ['', Validators.required], 
        email: ['', Validators.maxLength(32)],
        password: ['', Validators.required]
      }); 
      this.login = null;
      //this.login = this.store.select('login');
    if(localStorage.getItem('login')){
      const json: string  | null = localStorage.getItem('login');
      if(json != null){
        const usuario:Usertoken = JSON.parse(json);
        this.login = usuario;
        if(usuario.nombre != 'error'){
          this.usuariologeado = true;
        }else{
          this.usuariologeado = false; 
          console.log('location')
          //console.log(this.router.url)
          //console.log(this.activatedRoute.url);
          //this.router.navigate(['/login']);
        }
      }
    }
  }

  ngOnInit() {
  }

  async onCreate() {
    if(!this.registerForm.valid){
      return;
    }
    this.tio = new Tio(this.nombre, this.email, this.password);
    var response = await this.tioService.registrar(this.tio);
    if(response.status==201){
      const usuario:Tio = response.data;
      const usertoken: Usertoken = {
        token: "",
        id: usuario.id,
        nombre: "error",
        email: usuario.email,
        role: "",
        status: 404
      };
      this.tokenService.setUser(usertoken);
      this.router.navigate(['/login']);
    }else{
      console.log('ocurrio un error')
    }
  }
}
