import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from "@angular/common";


@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})


export class MenuComponent implements OnInit {
  nombre = '';
  email = 'zddfdfdsfd';
  password = '';
  usuariologeado = false;
  constructor(
    location: Location, 
    private router: Router) {
    
  }

  logout() {
    
  }

  ngOnInit() {
  }

}
